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
        protected ApplicationManager app;

        [OneTimeSetUp]
        public void SetupTest()
        {
            app = ApplicationManager.GetInstance();

        }

       



    }
}
