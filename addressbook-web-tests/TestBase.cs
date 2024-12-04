﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }






        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }




        protected void Login (AccountData account)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }


        protected void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }




        protected void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//span[" + index + "]/input")).Click();
        }


        protected void RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }


        protected void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }


    
        //--------------------------------------------------------------

        protected void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        protected void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }



        protected void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }



        protected void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        //----------------------------------------
        protected void OpenContactsPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }


        protected void SelectContact(int index)
        {
            driver.FindElement(By.XPath("//tr[" + index + "]/td/input")).Click();
        }




        protected void DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
        }
        //------------------------------------------------------------------------



        protected void InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        protected void FillContactForm ( ContactData contact )
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
        }


        protected void SubminContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        protected void ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }



        










    }
}
