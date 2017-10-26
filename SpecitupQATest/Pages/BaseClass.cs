using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecitupQATest.Pages
{
    public class BaseClass
    {
        IWebElement value = null;

        #region SelectorType
        public enum SelectorType
        {
            ClassName,
            CssSelector,
            Id,
            LinkText,
            PartialLinkText,
            Name,
            TagName,
            XPath
        }
        #endregion

        #region Element Control Finder
        public static IWebElement GenericElement<T>(SelectorType elementType, string propName) where T : IWebElement
        {
            IWebElement genericElement = null;

            if (elementType == SelectorType.Id)
                genericElement = PropertiesCollection.driver.FindElement(By.Id(propName));

            if (elementType == SelectorType.ClassName)
                genericElement = PropertiesCollection.driver.FindElement(By.ClassName(propName));

            if (elementType == SelectorType.Name)
                genericElement = PropertiesCollection.driver.FindElement(By.Name(propName));

            if (elementType == SelectorType.XPath)
                genericElement = PropertiesCollection.driver.FindElement(By.XPath(propName));

            if (elementType == SelectorType.TagName)
                genericElement = PropertiesCollection.driver.FindElement(By.TagName(propName));

            if (elementType == SelectorType.CssSelector)
                genericElement = PropertiesCollection.driver.FindElement(By.CssSelector(propName));

            if (elementType == SelectorType.LinkText)
                genericElement = PropertiesCollection.driver.FindElement(By.LinkText(propName));

            return genericElement;
        }

        #endregion

        #region SetMethods

        #region EnterText
        //Enter Text
        public static void EnterText(SelectorType elementtype, string element, string value)
        {
            GenericElement<IWebElement>(elementtype, element).SendKeys(value);
        }
        #endregion

        #region Click
        public static void Click(SelectorType elementtype, string element)
        {
            GenericElement<IWebElement>(elementtype, element).Click();
        }
        #endregion

        #region SelectDropDown
        public static void SelectDropDown(SelectorType elementtype, string element)
        {
            //, string value
            IWebElement dropDownElement = GenericElement<IWebElement>(elementtype, element);
            new SelectElement(dropDownElement).SelectByText(element);
        }
        #endregion

        #endregion

        #region GetMethods

        #region GetText
        public static string GetText(SelectorType elementtype, string element)
        {
            string value = null;

            value = GenericElement<IWebElement>(elementtype, element).GetAttribute("value");

            if (value != String.Empty)
                return value;
            else return value = string.Empty;
        }
        #endregion

        #region GetTextFromDropDown
        public static string GetTextFromDropDown(SelectorType elementtype, string element)
        {
            string value = null;

            IWebElement dropDownElement = GenericElement<IWebElement>(elementtype, element);
            
            value = new SelectElement(dropDownElement).AllSelectedOptions.SingleOrDefault().Text;
            
            if (value != String.Empty)
                return value;
            else return value = string.Empty;
        }
        #endregion

        #endregion

        #region ActionMethods

        #region NavigateToMenus
        /// <summary>
        /// This method will click the main menu and submenus.
        /// </summary>
        /// <param name="navMenu"></param>
        /// <param name="category"></param>
        public void NavigateToMenus(string navMenu, string category)
        {
            switch (navMenu)
            {
                case "Manage":
                    Click(SelectorType.Id, "menu-setup");
                    Click(SelectorType.LinkText, category);
                    break;

                case "Assign":
                    Click(SelectorType.Id, "menu-assess");
                    Click(SelectorType.LinkText, category);
                    break;

                case "Reports":
                    Click(SelectorType.Id, "menu-report");
                    Click(SelectorType.LinkText, category);
                    break;

                case "Sales":
                    Click(SelectorType.Id, "menu-sales");
                    Click(SelectorType.LinkText, category);
                    break;
            }
        }
        #endregion

        #region ManagePhases
        public void ManagePhases()
        {
            //IWebElement tableElement = driver.FindElement(By.XPath("/html/body/table"));

            value = GenericElement<IWebElement>(SelectorType.ClassName, "rowgroup");
            IList<IWebElement> tableRow = value.FindElements(By.TagName("tr"));
            IList<IWebElement> rowTD;
            foreach (IWebElement row in tableRow)
            {
                rowTD = row.FindElements(By.TagName("td"));
                
                if(rowTD.Count > 9)
                {
                    if(rowTD[8].Text.Equals("Suspended") && rowTD[10].Text.Equals("Publishing Failed"))
                    { }
                    //test failed
                }
            }

            //
        }
        #endregion

        #endregion
    }
}
