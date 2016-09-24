using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC01.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MVC01.Tests.Controllers
{
    [TestClass]
     public class StoreControllerTest
    {
      
        [TestMethod]
        public void Index() {
            StoreController scontrol = new StoreController();
            ViewResult vr = scontrol.Index() as ViewResult;
            Assert.IsNotNull(vr);


        }
    }
}
