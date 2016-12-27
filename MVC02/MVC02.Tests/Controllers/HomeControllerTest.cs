using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualBasic.FileIO;
using Microsoft.VisualBasic.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC02;
using MVC02.Controllers;

namespace MVC02.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FtpServer()
        {
            FTPClient c = new FTPClient("ftp://ftp.hostbuddy.com/", "antifogtest", "antifogtest", false);
            Assert.IsNotNull(c.DirectoryListing());
            foreach (var file in c.DirectoryListing())
            {
                System.Console.Out.WriteLine("================" + file);
                if (file.IndexOf(".csv") > -1)
                {
                    c.MoveFileFromServer(file, "done");
                }
            } 
            
        }

        [TestMethod]
        public void ReadCsvFile()
        {
            
            
            using (TextFieldParser parser = new TextFieldParser(@"C:\peopulse\Missions_20161124154501.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                int i = 0;
                List<PeopulseCsv> csvs = new List<PeopulseCsv>();
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] line = parser.ReadFields();
                    try
                    {
                        PeopulseCsv csv = new PeopulseCsv(line);
                        csvs.Add(csv);
                    }
                    catch (Exception e)
                    {
                        
                         Console.Out.WriteLine(String.Format("Error at line {0} with detail {1}",i,e.Message));
                    }
                   

                    //foreach (string field in line)
                    //{
                    //    //TODO: Process field
                    //}
                    i++;
                }
                Assert.AreEqual(10, i-1);
                Console.Out.WriteLine(csvs.ToString());
                Assert.AreEqual(6, csvs.Count);
            }
        }

    }
}
