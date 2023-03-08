using February2023.Pages;
using February2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace February2023.Tests
{
    [TestFixture]
    [Parallelizable]
    public class TM_Tests : CommonDriver
    {
        // Page objects initialization
        HomePage homePageObj = new HomePage();
        TMPage tmPageObj = new TMPage();


        [Test, Order(1), Description("Check if user is able to create Time record with valid data")]
        public void CreateTMTest()
        {
            // TM page object initialization and definition
            homePageObj.GoToTMPage(driver);
            tmPageObj.CreateTM(driver);
        }

        [Test, Order(2), Description("Check if user is able to edit an existing record with valid data")]
        public void EditTMTest()
        {
            homePageObj.GoToTMPage(driver);
            //tmPageObj.EditTM(driver);
        }

        [Test, Order(3), Description("Check if user is able to delete an existing Time record")]
        public void DeleteTMTest()
        {

            homePageObj.GoToTMPage(driver);
            tmPageObj.DeleteTM(driver);
        }
    }
}


