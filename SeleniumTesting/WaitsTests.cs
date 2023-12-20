using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace SeleniumTesting
{
    
    [TestClass]
    public class WaitsTest
    {
        private ChromeDriver driver;

    [TestInitialize]
    public void Initialize()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/dynamic.html");
    }

    [TestCleanup]
    public void Cleanup()
    {
        driver.Close();
        driver.Quit();
    }

        [TestMethod]
        public void Fails()
        {
            driver.FindElement(By.Id("adder")).Click();

            Assert.ThrowsException<NoSuchElementException>(
                () => driver.FindElement(By.Id("box0"))
            );
        }

        [TestMethod]
        public void Sleep()
        {
            driver.FindElement(By.Id("adder")).Click();

            Thread.Sleep(1000);

            IWebElement added = driver.FindElement(By.Id("box0"));

            Assert.AreEqual("redbox", added.GetDomAttribute("class"));
        }

        [TestMethod]
        public void Implicit()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            
            driver.FindElement(By.Id("adder")).Click();

            IWebElement added = driver.FindElement(By.Id("box0"));

            Assert.AreEqual("redbox", added.GetDomAttribute("class"));
        }

        [TestMethod]
        public void Explicit()
        {
            IWebElement revealed = driver.FindElement(By.Id("revealed"));
            driver.FindElement(By.Id("reveal")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(d => revealed.Displayed);

            revealed.SendKeys("Displayed");
            Assert.AreEqual("Displayed", revealed.GetDomProperty("value"));
        }

        [TestMethod]
        public void ExplicitOptions()
        {
            IWebElement revealed = driver.FindElement(By.Id("revealed"));
            driver.FindElement(By.Id("reveal")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2))
            {
                PollingInterval = TimeSpan.FromMilliseconds(300),
            };
            wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));

            wait.Until(d => {
                revealed.SendKeys("Displayed");
                return true;
            });

            Assert.AreEqual("input", revealed.TagName);
        }
    }
}