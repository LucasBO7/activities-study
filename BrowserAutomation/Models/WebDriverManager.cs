using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BrowserAutomation.Models
{
    public class WebDriverManager
    {
        private static IWebDriver _instance;

        public static IWebDriver Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ChromeDriver();
                }
                return _instance;
            }
        }
    }
}
