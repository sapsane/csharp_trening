using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public ContactHelper ModifyContact(ContactData toBeModify, ContactData contact)
        {
            manager.Navigator.OpenContactsPage();
            SelectContact2(toBeModify.Id);
            InitContactModification();
            FillContactForm(contact);
            SubminContactModification();
            ReturnToContactsPage();
            return this;
        }


        public ContactHelper SubminContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCashe = null;
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


        public ContactHelper Delete(ContactData contact)
        {
            manager.Navigator.OpenContactsPage();
            SelectContact2(contact.Id);
            DeleteContact();
            return this;
        }



        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//tr[" + (index+2) + "]/td/input")).Click();
            return this;
        }

        public ContactHelper SelectContact2(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            return this;
        }


        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCashe = null;
            return this;
        }
       



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
            contactCashe = null;
            return this;
        }

        public ContactHelper ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public bool IsContactPresent() 
        {
            manager.Navigator.OpenContactsPage();
            return  IsElementPresent(By.Name("selected[]"));
        
        }



        private List<ContactData> contactCashe = null;


        public List<ContactData> GetContactList()
        {
            if (contactCashe == null) 
            {
                contactCashe= new List<ContactData>();

                manager.Navigator.OpenContactsPage();
                ICollection<IWebElement> row = driver.FindElements(By.CssSelector("tr"));

                foreach (IWebElement row2 in row)
                {
                    IList<IWebElement> cells = row2.FindElements(By.TagName("td"));
                    if (!(cells.Count == 0))
                    {


                        //фамилия
                        string lastname = cells[1].Text;
                        //имя
                        string firstname = cells[2].Text;

                        string id = cells[0].FindElement(By.Name("selected[]")).GetDomAttribute("Value");

                        ContactData contact = new ContactData(firstname, lastname, id);
                        contactCashe.Add(contact);



                    }
                }


            }
            return new List<ContactData>(contactCashe);

        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenContactsPage();
            IList<IWebElement> cells= driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName=cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmail = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName, "")
            {
                Address = address,
                AllEmails = allEmail,
                AllPhones = allPhones,
             
            
            };


        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenContactsPage();
            
            InitContactModification2(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetDomAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetDomAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");


            string homePhone = driver.FindElement(By.Name("home")).GetDomAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetDomAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetDomAttribute("value");


            string email = driver.FindElement(By.Name("email")).GetDomAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetDomAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetDomAttribute("value");



         

            return new ContactData(firstName, lastName,"")
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };

        }

        public void InitContactModification2(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                  .FindElements(By.TagName("td"))[7]
                  .FindElement(By.TagName("a")).Click();
            
        }



        public void InitContactProperties(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                  .FindElements(By.TagName("td"))[6]
                  .FindElement(By.TagName("a")).Click();

        }

        public string GetContactInformationFromProperties(int index)
        {
            manager.Navigator.OpenContactsPage();
            InitContactProperties(index);
                      
            string content = driver.FindElement(By.CssSelector("div#content")).Text;

            return content;
                       

            

        }

      
    }

}
