using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace MVC02.Tests.Controllers
{
    public class InterfacePeopulseUtility
    {
        public const char Seperator = ';';
        private const string AdditionalCostsName = "-AdditionalCosts.csv";
        private const string SuppliesName = "-Supplies.csv";
        private const string MissionAttendancesName = "-MissionAttendances.csv";
        private const string SortedQuantitiesName = "-SortedQuantities.csv";
        private const string StaffAttendancesName = "-StaffAttendances.csv";
        public const string Running = "running";
        public const string Processed = "processed";
        public const string Error = ".errr";
        public const string Done = "Done";
        public const string FormatDate = "yyyy-MM-dd";
        public const string FormatDateTime = "yyyy-MM-dd HH:mm";
        public const string TempFolder = "temp";
        public const string RunningFolder = "running";
        public const string DoneFolder = "done";
        /// <summary>
        /// Return the configured FTP directory 
        /// </summary>
        /// <returns>Absolute path of FTP directory </returns>
        public static string FtpRootDirectory()
        {
            return ConfigurationManager.AppSettings["antifog.jobs.peopulse.data.directory"];
        }
        
        /// <summary>
        /// Delete the file.status if it exists, then rename current file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="status"></param>
        public static void UpdateFileStatus(string filename, string status)
        {
            var root = FtpRootDirectory();
            var newFile = root + status + "/" + filename.Substring(root.Length);
            if (status == Running)
            {
                File.Delete(newFile);
                File.Move(filename, newFile);
            } else if (status == Processed)
            {
                File.Delete(newFile);
                var oldFile = root + Running + "/" + filename.Substring(root.Length);
                File.Move(oldFile, newFile);
            }
        }

        #region FileNames
        public static string AdditionalCostsFileName(DateTime date)
        {
            return FtpRootDirectory() + date.ToString(FormatDate) + AdditionalCostsName;
        }

        public static string SuppliesFileName(DateTime date)
        {
            return FtpRootDirectory() + date.ToString(FormatDate) + SuppliesName;
        }

        public static string MissionAttendancesFileName(DateTime date)
        {
            return FtpRootDirectory() + date.ToString(FormatDate) + MissionAttendancesName;
        }

        public static string SortedQuantitiesFileName(DateTime date)
        {
            return FtpRootDirectory() + date.ToString(FormatDate) + SortedQuantitiesName;
        }

        public static string StaffAttendancesFileName(DateTime date)
        {
            return FtpRootDirectory() + date.ToString(FormatDate) + StaffAttendancesName;
        }

       
        #endregion

        #region DateTime
        /// <summary>
        /// Convert string yyyy-MM-dd to date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ConvertDate(string date)
        {
            if (String.IsNullOrWhiteSpace(date)) throw new PeopulseDataException("Date is required !");
            try
            {
                return DateTime.ParseExact(date, FormatDate, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new PeopulseDataException(String.Format("Input {0} but date format is {1}", date, FormatDate));
            }
            
             
        }
        public static DateTime? ConvertDateNullAble(string date)
        {
            
            if (!String.IsNullOrWhiteSpace(date))
                try
                {
                    return DateTime.ParseExact(date, FormatDate, CultureInfo.InvariantCulture);
                }
                catch (Exception e)
                {

                    Console.Out.WriteLine(String.Format("Input {0} but date format is {1}", date, FormatDate));
                }
            return null;
           
        }
        /// <summary>
        /// /// Convert string yyyy-MM-dd HH:mm to datetime
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime ConvertDateTime(string datetime)
        {
            return DateTime.ParseExact(datetime, FormatDateTime, CultureInfo.InvariantCulture);
        }

        public static Gender ReadGender(String g)
        {
            if (String.IsNullOrWhiteSpace(g)) throw new PeopulseFieldRequiredException("Gender is required !");
            if("F".Equals(g.ToUpper())) return Gender.Female;
            if ("M".Equals(g.ToUpper())) return Gender.Male;
            throw new PeopulseDataException("Gender is required M/F  !");
        }

        public static EmployeeType ReadEmployeeType(String g)
        {
            if (String.IsNullOrWhiteSpace(g)) throw new PeopulseFieldRequiredException("EmployeeType is required !");
            switch (g.ToUpper())
            {
                case "E": case "H": case "S":
                    return EmployeeType.External;
                case "I": return EmployeeType.Internal;
                default: throw new PeopulseDataFormatException("EmployeeType is required E/I/H/S  !");
            }
            
        }


        //public static ContractType ReadContractType(String g, StaffContext staffContext)
        //{
        //    EmployeeType etype = ReadEmployeeType(g);

        //    if (etype == EmployeeType.External){

        //       return staffContext.ContractTypes.GetAll().Single(ct => ct.ContractCode == "INTERIM");
        //    } 
        //    if (etype == EmployeeType.Internal)
        //    {
        //        return staffContext.ContractTypes.GetAll().Single(ct => ct.ContractCode == "I");
        //    }
        //    throw new PeopulseDataFormatException("EmployeeType is required E/I/H/S  !");
        //}

        //public static StaffType ReadStaffType(String g)
        //{
        //    if (String.IsNullOrWhiteSpace(g)) throw new PeopulseFieldRequiredException("StaffType is required !");
        //    switch (g.ToUpper())
        //    {
        //        case "E": return StaffType.ExternalWorker;
        //        case "H": return StaffType.Host;
        //        case "S": return StaffType.Subcontractor;
        //        case "I": return StaffType.TrigoWorker;
        //        default: throw new PeopulseDataFormatException("StaffTyp is required E/I/H/S  !");
        //    }

        //}
        #endregion

        internal static decimal ConvertDataNumeric(string p)
        {
            if (String.IsNullOrWhiteSpace(p)) throw new PeopulseDataException("Hourly Rate is required !");
            try
            {
                return Decimal.Parse(p);
            }
            catch (Exception)
            {

                throw new PeopulseDataFormatException("Hourly Rate is wrong format !");
            }
            
        }
    }
}
