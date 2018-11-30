using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mvc.Controllers;
using Mvc.Models;

namespace UnitTestMvc
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    EmployeeController ec = new EmployeeController();
        //    var x = ec.Index();
        //}

        [TestMethod]
        public void InsertEmployeeTest()
        {
            EmployeeController ec = new EmployeeController();

            var emp = new MvcEmployeeModel();
            emp.FirstName = "test";
            emp.LastName = "TestDemo";
            emp.Salary = 90888;
            emp.EmpCode = 1001;

            //Inser Employee
            ec.AddOrEdit(emp);

            //get list of employee
            var response = ec.Index();

            var temp = (ViewResult)response;
            var list = (List<MvcEmployeeModel>)temp.Model;
            var testEmployee = list[list.Count - 1];
            Assert.AreEqual(testEmployee.FirstName, emp.FirstName);
            Assert.IsInstanceOfType(response, typeof(ViewResult));

            //Delete inserted emp
            ec.Delete(testEmployee.Id);
        }
    }
}
