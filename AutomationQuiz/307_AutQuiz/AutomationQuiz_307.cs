using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _307_AutQuiz
{
    public class AutomationQuiz_307
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            var path = "https://ultimateqa.com/";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(path);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void GoToPreComplicatedPage1()
        {
            var searchButton = driver.FindElement(By.XPath("//button[@class=\"et_pb_menu__icon et_pb_menu__search-button\"]"));
            searchButton.Click();            
            var inputText = driver.FindElement(By.XPath("//input[@class=\"et_pb_menu__search-input\"]"));
            inputText.SendKeys("Complicated Page");
            inputText.Submit();
        }

        [Test]
        public void GoToPreComplicatedPage2()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            var complicatedPageHref = driver.FindElement(By.XPath("//h2/a[@href=\"https://ultimateqa.com/complicated-page/\"]"));
            complicatedPageHref.Click();
            Assert.IsTrue(driver.Url == "https://ultimateqa.com/complicated-page/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Quit();

        }
    }
}
