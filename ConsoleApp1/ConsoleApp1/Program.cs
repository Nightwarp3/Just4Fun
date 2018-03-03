using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // implement user profiles with interactive data and stuff as an app
            // maybe an app that sends out information via email then a separate app that can take input to find specific data
            ChromeDriver webDriver = InitializeChromeDriver();

            try
            {
                Dictionary<string, string> emissaries = GetEmissaries(webDriver);
                List<string> affixes = GetAffixes(webDriver);
                Dictionary<string, string> buildings = GetBuildings(webDriver);
            }
            finally
            {
                Console.WriteLine("\n\n\nPress enter to exit . . ");
                Console.ReadLine();
                webDriver.Quit();
            }
        }

        private static ChromeDriver InitializeChromeDriver()
        {
            ChromeDriver driver = new ChromeDriver(@"C:\");
            driver.Url = ("http://www.wowhead.com");

            return driver;
        }

        private static Dictionary<string, string> GetBuildings(ChromeDriver webDriver)
        {
            Dictionary<string, string> buildingDictionary = new Dictionary<string, string>();
            var buildingElements = webDriver.FindElementsByXPath("//div[@class='tiw-region tiw-region-US tiw-show']//tr[@class='tiw-bs-building']//div[@class='tiw-bs-status-name']/a");
            var progressElements = webDriver.FindElementsByXPath("//div[@class='tiw-region tiw-region-US tiw-show']//tr[@class='tiw-bs-building']//div[@class='tiw-bs-status-progress tiw-bs-status-progress-far' or @class='tiw-bs-status-progress']//span");
            var status = webDriver.FindElementsByXPath("//div[@class='tiw-region tiw-region-US tiw-show']//tr[@class='tiw-bs-building']//div[@class='imitation-heading heading-size-5']");

            Console.WriteLine("Legionfall Buildings:");
            for(int i = 0; i < buildingElements.Count; i++)
            {
                buildingDictionary.Add(buildingElements[i].Text, $"{progressElements[i].Text} {status[i].Text}" );
                Console.WriteLine($"{buildingElements[i].Text} - {progressElements[i].Text} {status[i].Text}");
            }

            return buildingDictionary;
        }

        private static List<string> GetAffixes(ChromeDriver webDriver)
        {
            List<string> affixList = new List<string>();
            var affixElements = webDriver.FindElementsByXPath("//table[@class='tiw-group tiw-group-type-misc tiw-group-mythicaffix']//td[@class='icon-both']/a");

            Console.WriteLine("\nAffixes:");
            foreach (IWebElement element in affixElements)
            {
                affixList.Add(element.Text);
                Console.WriteLine(element.Text);
            }

            return affixList;
        }

        private static Dictionary<string, string> GetEmissaries(ChromeDriver webDriver)
        {
            Dictionary<string, string> emissaryList = new Dictionary<string, string>();
            var emissaryElements = webDriver.FindElementsByXPath("//div[@class='tiw-region tiw-region-US tiw-show']//table[@class='tiw-group tiw-group-type-misc tiw-group-emissary']//td[@class='icon-none']/a");
            var emissaryTimeLeft = webDriver.FindElementsByXPath("//div[@class='tiw-region tiw-region-US tiw-show']//table[@class='tiw-group tiw-group-type-misc tiw-group-emissary']//tr/td[@class='tiw-line-ending-short' and .!='']");

            Console.WriteLine("\nEmissaries:");
            for (int i = 0; i < emissaryElements.Count; i++)
            {
                emissaryList.Add(emissaryElements[i].Text, emissaryTimeLeft[i].Text);
                Console.WriteLine($"{emissaryElements[i].Text} - {emissaryTimeLeft[i].Text}");
            }

            return emissaryList;
        }
    }
}
