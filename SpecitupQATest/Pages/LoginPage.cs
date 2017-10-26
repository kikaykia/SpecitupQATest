using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SpecitupQATest.Pages;

namespace SpecitupQATest.Pages
{
    public class LoginPage
    {

        #region attributes

        private IWebDriver _driver;



        [FindsBy(How = How.Id, Using = "EmailAddress")]
        [CacheLookup]
        private IWebElement EmailAddress { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        [CacheLookup]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn-primary")]
        [CacheLookup]
        private IWebElement Submit { get; set; }

        #endregion

        #region constructor

        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        #endregion

        #region methods

        public void LoginToApplication()
        {
            //OPTION #1:
            //EmailAddress.SendKeys("kiara.imbong+demohomesv3@gmail.com");
            //Password.SendKeys("qa12345");
            //Submit.Submit();

            //OPTION #2:
            BaseClass.EnterText(BaseClass.SelectorType.Id, "EmailAddress", "kiara.imbong+demo1@gmail.com");
            BaseClass.EnterText(BaseClass.SelectorType.Id, "Password", "qa12345");

            //Console.Write("The username is:" + BaseClass.GetText(_driver, "EmailAddress", PropertyType.Id));
            //Console.Write("The password is:" + BaseClass.GetText(_driver, "Password", PropertyType.Id));

            BaseClass.Click(BaseClass.SelectorType.ClassName,"btn-primary");
        }

        //Check if user is directed to the homepage
        public void CheckHomepage()
        {
            
        }

        #endregion

    }
}
