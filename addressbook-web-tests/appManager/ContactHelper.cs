using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressbookTests
{
    public class ContactHelper :HelperBase
    {

        

        public ContactHelper(IWebDriver driver) : base(driver)
        {
           
        }

        public void SelectContact(int index)
        {
            driver.FindElement(By.XPath("//tr[" + index + "]/td/input")).Click();
        }




        public void DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
        }
        //------------------------------------------------------------------------



        public void InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
        }


        public void SubminContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        public void ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }








    }
}
