﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;


namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {  

   

    public LoginHelper(ApplicationManager manager) : base(manager)
        {
       
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn()) 
            {

                if (IsLoggedIn(account)) 
                {
                    return;
                }
                logout();

            }
            
            
            
            driver.FindElement(By.Name("user")).Click();
            Type(By.Name("user"), account.Username);
                       
            driver.FindElement(By.Name("pass")).Click();
            Type(By.Name("pass"), account.Password);
            // driver.FindElement(By.Name("pass")).Clear();
            // driver.FindElement(By.Name("pass")).SendKeys(account.Password);

            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }




       

        public void logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
           
        }



        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }



        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text == "(" + account.Username + ")";
        }




    }
}
