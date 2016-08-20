using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 
using System.Data.Entity;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer<CompanyContext>(new DropCreateDatabaseAlways<CompanyContext>());
            
           //    CreateDB Example
            Console.Write("===================");
            Console.Write(" Create DB Example ");
            Console.Write("===================" + Environment.NewLine);
            Examples.CreateDB();
            Console.Clear();

            // Audit Example
            Console.Write("===================");
            Console.Write("   Audit Example   ");
            Console.Write("===================" + Environment.NewLine);
            Examples.Audit();
            Console.Clear();

            //// Validation Example
            Console.Write("===================");
            Console.Write(" Validation Example ");
            Console.Write("===================" + Environment.NewLine);
            Examples.Validation();
            Console.Clear();

            //// Concurrency Example
            Console.Write("===================");
            Console.Write(" Concurrency Example ");
            Console.Write("===================" + Environment.NewLine);
            Examples.FirstWins();
            Console.Write(Environment.NewLine);
            Examples.LastWins();
        }
    }
}
