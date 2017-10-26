using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
//using Selenium_Test.Pages;
using NUnit.Framework;
using SpecitupQATest;
using SpecitupQATest.Pages;

namespace SpecitupQATest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    //[Test]
    public class UnitTest1
    {
        public UnitTest1()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        #region variables
        //ChromeDriver _browser = new ChromeDriver("C:\\Users\\kiara\\Documents\\SPEC\\automation\\");
        #endregion

        [SetUp]
        public void Initialize()
        {
            BrowserFactory.InitBrowser("Chrome");
            BrowserFactory.LoadApplication("https://specitupv3test.cloudapp.net/Account/Login");
        }
        
        [Test]
        public void TestMethod1()
        {
            //var driver = PropertiesCollection.driver.Url;
            var loginPage = new LoginPage(PropertiesCollection.driver);
            loginPage.LoginToApplication();

            //PropertiesCollection.driver. .WebDriver.attachToSession(executor, session_id);

            var baseClassPage = new BaseClass();
            baseClassPage.NavigateToMenus("Manage", "Sales Types");
            //

            var homeDashboardPage = new HomeDashBoardPage(PropertiesCollection.driver);
            //homeDashboardPage.ClickAutoOptionsLink();

        }

        // This closes the driver down after the test has finished.  
        [TearDown]
        public void TearDown()
        {
            BrowserFactory.CloseAllDrivers();
            //Console.WriteLine("Closed the browser.");

        }
    }
}
