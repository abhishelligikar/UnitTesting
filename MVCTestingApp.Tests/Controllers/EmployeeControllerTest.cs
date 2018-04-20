using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCTestingApp.Controllers;
using System.Web.Mvc;
using EmployeeDAL.Models;
using System.Web.UI.WebControls;
using System.Net;
using Moq;
using EmployeeDAL.Repo;

namespace MVCTestingApp.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        public EmployeeControllerTest()
        {

        }

        [TestMethod]
        public void AddEmployeeTest()
        {
            Employee objEmployee = new Employee
            {
                EmployeeID = 1009,
                FirstName = "Navneet",
                LastName = "Huggi",
                EmpCode = "1336",
                Position = "IAS Aspirant",
                Office = "Bangalore"
            };
            var objmoq = new Mock<IEmployeeDAL>();
            objmoq.Setup(X => X.AddEmployee(objEmployee)).Returns(true);
            EmployeeController objEmployeeController = new EmployeeController(objmoq.Object);

            var result = (RedirectToRouteResult)objEmployeeController.Add(objEmployee);

            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }

        [TestMethod]
        public void EditEmployeeTest()
        {
            Employee objEmployee = new Employee
            {
                EmployeeID = 1009,
                FirstName = "Navneet",
                LastName = "Huggi",
                EmpCode = "1336",
                Position = "IAS Aspirant",
                Office = "Bangalore"
            };
            var objmoq = new Mock<IEmployeeDAL>();
            objmoq.Setup(X => X.EditEmployee(objEmployee)).Returns(true);
            EmployeeController objEmployeeController = new EmployeeController(objmoq.Object);

            var result = (RedirectToRouteResult)objEmployeeController.Edit(objEmployee);

            Assert.AreEqual("Index", result.RouteValues["Action"]);

        }

        [TestMethod]
        public void DeleteEmployeeTest()
        {
            int intEmployeeId = 1009;

            var objmoq = new Mock<IEmployeeDAL>();
            objmoq.Setup(X => X.DeleteEmployee(intEmployeeId)).Returns(true);
            EmployeeController objEmployeeController = new EmployeeController(objmoq.Object);

            var result = (RedirectToRouteResult)objEmployeeController.Delete(intEmployeeId);

            Assert.AreEqual("Index", result.RouteValues["Action"]);

        }

        [TestMethod]
        public void GetEmployeeTest()
        {
            IEnumerable<Employee> objList = new List<Employee>
            {
                new Employee {FirstName = "Abhishek",LastName = "Kulkarni" },
                new Employee{ FirstName = "Aditya", LastName = "Kulkarni"}
            };
            var objmoq = new Mock<IEmployeeDAL>();
            objmoq.Setup(X => X.GetEmployees()).Returns(objList);
            EmployeeController objEmployeeController = new EmployeeController(objmoq.Object);

            var result = objEmployeeController.GetEmployees() as ViewResult;
            //Assert.AreEqual(objList, objmoq);
            Assert.IsNotNull(result.Model);
            Assert.AreEqual("Index", result.ViewName);
            
           
        }
    }
}


