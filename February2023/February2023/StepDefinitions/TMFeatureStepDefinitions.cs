using February2023.Pages;
using February2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace February2023.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tmPageObj = new TMPage();

        [Given(@"I logged into turnup portal successfully")]
        public void GivenILoggedIntoTurnupPortalSuccessfully()
        {
            // Open chrome browser
            driver = new ChromeDriver();

            // Login page object initialization and definition
            loginPageObj.LoginActions(driver);
        }

        [When(@"I navigate to Time and Material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            // TM page object initialization and definition
            homePageObj.GoToTMPage(driver);
        }

        [When(@"I create a new time and material record")]
        public void WhenICreateANewTimeAndMaterialRecord()
        {
            tmPageObj.CreateTM(driver);
        }

        [Then(@"The record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            string newCode = tmPageObj.GetCode(driver);
            string newDescription = tmPageObj.GetDescription(driver);
            string newPrice = tmPageObj.GetPrice(driver);

            Assert.That(newCode == "February2023", "Actual code and expected code do not match.");
            Assert.That(newDescription == "Feb23", " Actual description and expected description do not match.");
            Assert.That(newPrice == "$12.00", " Actual price and expected price do not match.");
        }

        //[When(@"I update '([^']*)' on an existing time and material record")]
        //public void WhenIUpdateOnAnExistingTimeAndMaterialRecord(string description)
        //{
        //    tmPageObj.EditTM(driver, description);
        //}

        //[Then(@"The record should have the updated '([^']*)'")]
        //public void ThenTheRecordShouldHaveTheUpdated(string description)
        //{

        //}

        [When(@"I update '([^']*)', '([^']*)', '([^']*)' on an existing time and material record")]
        public void WhenIUpdateOnAnExistingTimeAndMaterialRecord(string description, string code, string price)
        {
            tmPageObj.EditTM(driver, description, code, price);

        }

        [Then(@"The record should have the updated '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdated(string description, string code, string price)
        {
            string editedDescription = tmPageObj.GetEditedDescription(driver);
            string editedCode = tmPageObj.GetEditedCode(driver);
            string editedPrice = tmPageObj.GetEditedPrice(driver);

            Assert.That(editedDescription == description, "Actual description and expected description do not match.");
            Assert.That(editedCode == code, "Actual code and expected code do not match.");
            Assert.That(editedPrice == price, "Actual price and expected price do not match.");

        }

    }
}
