using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask.Helpers
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    class TabsManipulator
    {
        public static void OpenNewTabAndOpenUrl(IWebDriver driver, IWebElement element)
        {

            Actions newTab = new Actions(driver);
            newTab
                .KeyDown(OpenQA.Selenium.Keys.Control)
                .KeyDown(OpenQA.Selenium.Keys.Shift)
                .Click(element).KeyUp(OpenQA.Selenium.Keys.Control).KeyUp(OpenQA.Selenium.Keys.Shift)
                .Build()
                .Perform();

            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }
    }
}
