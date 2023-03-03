using February2023.Pages;
using February2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace February2023.Tests
{
    [TestFixture]
    [Parallelizable]
    public class Employees_Tests : CommonDriver
    {
        // Page objects initialization
        EmployeePage employeePageObj = new EmployeePage();
        HomePage homePageobj = new HomePage();

     
        [Test]
        public void CreateEmployeeTest()
        {
        homePageobj.GoToEmployeesPage(driver);
        employeePageObj.CreateEmployee(driver);
        }

        [Test]
        public void EditEmployeeTest()
        {
            homePageobj.GoToEmployeesPage(driver);
            employeePageObj.EditEmployee(driver);
        }

        [Test]
        public void DeleteEmployeeTest()
        {
            homePageobj.GoToEmployeesPage(driver);
            employeePageObj.DeleteEmployee(driver);
        }


    }
}
