using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask.Helpers
{
    class ElementPaths
    {
        public static string GetElementPath(string elementName)
        {
            if (elementName == "logo at the top") { elementName = "//a[@class='header__home']/img"; }

            if (elementName == "mobile menu button") { elementName = "//nav//a[text()='MENU']"; }
            if (elementName == "EN language flag for mobile") { elementName = "//nav//a[text()='EN']"; }
            if (elementName == "contacts button in mobile menu") { elementName = "//a[@class='header__menulink js-menulink' and text()='Contact']"; }

            if (elementName == "close cookies button") { elementName = "//div[@id='brick-43']//span"; }
            if (elementName == "EN language flag for desktop") { elementName = "//a[@class='header__menulink--function-nav' and text()='EN']"; }
            if (elementName == "Contacts button at the top desktop menu") { elementName = "//div[@class='header__function-nav']//a[text()='Contact']"; }
            
            return elementName;
        }
    }
}
