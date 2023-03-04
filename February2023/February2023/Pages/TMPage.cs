using February2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace February2023.Pages
{
    public class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {
            // Click on Create New button
            Thread.Sleep(1500);

            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();
            Thread.Sleep(1000);

            // Select Time option from TypeCode dropdown list
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();
            Thread.Sleep(1000);

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            // Input code into Code textbox
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("February2023");

            // Input description into Description textbox
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("Feb23");

            // Input Price per Unit into price per unit textbox
            IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextbox.SendKeys("12");

            // Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(2000);

            // Check if new Time record has been created
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(5000);

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));

            Assert.That(newCode.Text == "February2023", "Actual code and expected code do not match.");
            Assert.That(newDescription.Text == "Feb23", " Actual description and expected description do not match.");


            //if (newCode.Text == "February2023")
            //{
            //    Assert.Pass("New Time record created successfully!");
            //}
            //else
            //{
            //    Assert.Fail("Record hasn't been created!");
            //}
        }

        public void EditTM(IWebDriver driver)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 3);

            // Click on Edit Buttonto make changes to type Code
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement recordToBeEdited = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (recordToBeEdited.Text == "February2023")
            {

                IWebElement LastRecordEdit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                LastRecordEdit.Click();
            }
            else
            {
                Assert.Fail("Record to be edited not found.");
            }


            // edit code textbox 
            IWebElement editCodeTextbox = driver.FindElement(By.Id("Code"));
            editCodeTextbox.Clear();
            editCodeTextbox.SendKeys("123456");
            Thread.Sleep(1500);

            //Identify and Click on Save Button
            IWebElement SaveButton = driver.FindElement(By.Id("SaveButton"));
            SaveButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 3);

            //Identify and Click on Last Page Button Page
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]")).Click();
            Thread.Sleep(1500);

            IWebElement lastEditedRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(lastEditedRecord.Text == "123456", "Record hasn't been edited.");

        }

        public void DeleteTM(IWebDriver driver)
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 3);

            //Identify and Click on Last Page Button Page
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span")).Click();
            Thread.Sleep(1000);

            IWebElement recordToBeDeleted = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (recordToBeDeleted.Text == "123456")
            {
                //Find and click on delete button for last record
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteButton.Click();
            }
            else
            {
                Assert.Fail("Record to be deleted not found.");
            }

            //Acceptance on Pop up to delete record
            driver.SwitchTo().Alert().Accept();

            driver.Navigate().Refresh();
            Thread.Sleep(2000);

            IWebElement lastRecordDelete = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(lastRecordDelete.Text != "123456", "Record hasn't been deleted");
        }
    }
    
}
