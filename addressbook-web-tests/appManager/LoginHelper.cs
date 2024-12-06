using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {  

   

    public LoginHelper(ApplicationManager manager) : base(manager)
        {
       
        }

        public void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Click();
            Type(By.Name("user"), account.Username);
                       
            driver.FindElement(By.Name("pass")).Click();
            Type(By.Name("pass"), account.Password);
            // driver.FindElement(By.Name("pass")).Clear();
            // driver.FindElement(By.Name("pass")).SendKeys(account.Password);

            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }





    }
}
