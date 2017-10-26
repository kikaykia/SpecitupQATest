using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecitupQATest.Pages
{
    public class ManageModels
    {
        IWebElement value = null;

        #region CheckExportModel
        public void CheckExportModel(string modelName)
        {
            value = SpecitupQATest.Pages.BaseClass.GenericElement<IWebElement>(SpecitupQATest.Pages.BaseClass.SelectorType.ClassName, "rowgroup");

            //IWebElement table = WebBrowser.Current.FindElement(By.TagName("tbody"));

            ReadOnlyCollection<IWebElement> allRows = value.FindElements(By.TagName("tr"));

            for (int z = 0; z < allRows.Count; z++)
            {
                ReadOnlyCollection<IWebElement> cells = allRows[z].FindElements(By.TagName("td"));

                for (int y = 0; y < cells.Count; y++)
                {
                    var valueInfo = allRows[z].FindElements(By.TagName("td"))[y].Text;

                    if (valueInfo.Equals(modelName))
                    {
                        var selectCheckbox = allRows[z].FindElements(By.TagName("input"))[y - 1].FindElement(By.TagName("input"));
                        //var selectCheckbox = allRows[z].FindElements(By.TagName("td"))[y - 1];
                        selectCheckbox.Click();
                    }
                }
            }
        }
        #endregion

    }
}
