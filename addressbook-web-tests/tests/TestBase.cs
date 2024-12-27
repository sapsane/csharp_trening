using System;
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
        protected ApplicationManager app;

        [OneTimeSetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
           

        }

        //[OneTimeTearDown]
        //public void StopApplicationManager()
        //{
        //    ApplicationManager.GetInstance().Stop();

        //}


        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++) 
            {
                builder.Append( Convert.ToChar(32+ Convert.ToInt32(rnd.NextDouble()*65)));
            }
            return builder.ToString();
        }



    }
}
