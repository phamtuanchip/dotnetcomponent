using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Infrastructure;

namespace CodeFirst
{
    public class Examples
    {
        public static void CreateDB()
        {
            using (var db = new CompanyContext())
            {
                // Get the Department, add it if not existing
                var department = db.Departments.FirstOrDefault(d => d.Name == "IT");
                if (department == null)
                {
                    department = new Department { Name = "IT" };
                    db.Departments.Add(department);
                }

                // Add a new Manager
                Console.Write("Please enter manager name: ");
                var managerName = Console.ReadLine();

                var manager = new Manager
                {
                    ManagerCode = "JDO",
                    Name = managerName,
                    Department = department
                };
                db.Managers.Add(manager);

                // Add a new collaborator
                Console.Write("Please enter collaborator name: ");
                var collaboratorName = Console.ReadLine();

                var collaborator = new Collaborator { Name = collaboratorName, Department = department, Manager = manager };
                db.Collaborators.Add(collaborator);

                int recordsAffected = 0;

                recordsAffected = db.SaveChanges();

                Console.WriteLine("{0} entities were saved to the database.", recordsAffected);

                // Query the Manager of the IT department
                var allManagers = db.Managers.Where(m => m.Department.Name == "IT");

                Console.WriteLine("The Manager of the IT department in database:");
                var managerIT = allManagers.FirstOrDefault();

                if (managerIT != null)
                {
                    Console.WriteLine(" - {0}", managerIT.Name);
                }


                // Query all Collaborators in the IT department
                var allCollaborators = db.Collaborators.Where(m => m.Department.Name == "IT");

                Console.WriteLine("All Collaborators in the IT department in database:");
                foreach (var item in allCollaborators)
                {
                    Console.WriteLine(" - {0}", item.Name);
                }

                Console.ReadKey();
            }
        }

        public static void Audit()
        {
            using (var context = new CompanyContext())
            {
                var manager = context.Managers.Find("JDO");

                // Change value directly in the DB
                using (var contextDB = new CompanyContext())
                {
                    contextDB.Database.ExecuteSqlCommand(
                        "UPDATE managers SET Name = Name + '_DB' WHERE ManagerCode = 'JDO'");
                }

                // Change the current value in memory
                manager.Name = manager.Name + "_Memory";

                string value = context.Entry(manager).Property(m => m.Name).OriginalValue;
                Console.WriteLine(string.Format("Original Value : {0}", value));

                value = context.Entry(manager).Property(m => m.Name).CurrentValue;
                Console.WriteLine(string.Format("Current Value : {0}", value));

                value = context.Entry(manager).GetDatabaseValues().GetValue<string>("Name");
                Console.WriteLine(string.Format("DB Value : {0}", value));

                Console.ReadKey();
            }

        }

        public static void Validation()
        {
            using (var context = new CompanyContext())
            {
                var manager = new Manager() { Name = string.Empty };
                context.Managers.Add(manager);

                var validationErrors = context.GetValidationErrors()
                    .Where(vr => !vr.IsValid)
                    .SelectMany(vr => vr.ValidationErrors);

                foreach (var error in validationErrors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                Console.ReadKey();
            }
        }

        public static void FirstWins()
        {
            using (var context = new CompanyContext())
            {
                var manager = context.Managers.Find("JDO");
                Console.WriteLine("Initial Value: " + manager.Name);
                
                // Change the DB value
                using (var contexDB = new CompanyContext())
                {
                    contexDB.Database.ExecuteSqlCommand(
                        "UPDATE managers SET Name = 'FirstWins' WHERE ManagerCode = 'JDO'");
                    Console.WriteLine("DB Updated Value: FirstWins");
                }

                // Change the memory value
                manager.Name = "NewName";
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    // Not possible to perform change because of differences between original and DB value
                    //ex.GetEntry(context).Reload();
                }

                manager = context.Managers.Find("JDO");
                Console.WriteLine("Final Value: " + manager.Name);
                Console.ReadKey();
            }
        }

        public static void LastWins()
        {
            using (var context = new CompanyContext())
            {
                bool savedChanges = false;

                var manager = context.Managers.Find("JDO");
                Console.WriteLine("Initial Value: " + manager.Name);

                // Change the DB value
                using (var contexDB = new CompanyContext())
                {
                    contexDB.Database.ExecuteSqlCommand(
                        "UPDATE managers SET Name = 'LastWins' WHERE ManagerCode = 'JDO'");
                    Console.WriteLine("DB Updated Value: LastWins");
                }
                
                manager.Name = "NewName";

                while (!savedChanges)
                {
                    try
                    {
                        context.SaveChanges();
                        savedChanges = true;
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        // Update original value with DB value
                       // var entry = ex.GetEntry(context);
                        //entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                    }

                } 

                manager = context.Managers.Find("JDO");
                Console.WriteLine("Final Value: " + manager.Name);
                Console.ReadKey();
            }
        }
    }
}
