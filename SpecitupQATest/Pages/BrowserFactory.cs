using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecitupQATest.Pages
{
    class BrowserFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();

        public static IWebDriver Driver
        {
            get
            {
                return PropertiesCollection.driver;
            }
            private set
            {
                PropertiesCollection.driver = value;
            }
        }

        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (PropertiesCollection.driver == null)
                    {
                        PropertiesCollection.driver = new FirefoxDriver();
                        Drivers.Add("Firefox", Driver);
                    }
                    break;

                case "IE":
                    if (PropertiesCollection.driver == null)
                    {
                        PropertiesCollection.driver = new InternetExplorerDriver();
                        Drivers.Add("IE", Driver);
                    }
                    break;

                case "Chrome":
                    if (PropertiesCollection.driver == null)
                    {
                        PropertiesCollection.driver = new ChromeDriver();
                        Drivers.Add("Chrome", Driver);
                    }
                    break;
            }
        }

        public static void LoadApplication(string url)
        {
            PropertiesCollection.driver.Url = url;
        }

        public static void GetApplication()
        {
            //BrowserFactory.Driver.PageSource.GetType().;
        }

        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }

    }
}
