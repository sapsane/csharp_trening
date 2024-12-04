﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper :  HelperBase
    {
       
        private string baseURL;

        public NavigationHelper(ApplicationManager manager,string baseURL) : base(manager)
        {
            
            this.baseURL=baseURL;
        }


        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void OpenContactsPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }





    }
}
