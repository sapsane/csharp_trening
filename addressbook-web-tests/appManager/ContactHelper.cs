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

        

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
           
        }


        public ContactHelper CreateContact(ContactData contact) 
        {
            manager.Navigator.OpenContactsPage();

            InitContactCreation();
            FillContactForm(contact);
            SubminContactCreation();
            ReturnToContactsPage();

            return this;
        }


        public ContactHelper ModifyContact(int p, ContactData contact)
        {
            manager.Navigator.OpenContactsPage();
            SelectContact(p);
            InitContactModification();
            FillContactForm(contact);
            SubminContactModification();
            ReturnToContactsPage();
            return this;
        }

        public ContactHelper SubminContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("(//img[@alt=\'Edit\'])")).Click();
            return this;
        }

        public ContactHelper Delete(int p)
        {
            manager.Navigator.OpenContactsPage();
            SelectContact(p);
            DeleteContact();
            return this;
        }


        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//tr[" + index + "]/td/input")).Click();
            return this;
        }




        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
        //------------------------------------------------------------------------



        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            Type(By.Name("firstname"), contact.Firstname);
           // driver.FindElement(By.Name("firstname")).Clear();
           // driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            Type(By.Name("lastname"), contact.Lastname);
      
            return this;

        }


        public ContactHelper SubminContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }


  
    }
}
