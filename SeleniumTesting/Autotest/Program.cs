using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumDocs.GettingStarted;

public static class Program
{
    public static void Main()
    {
        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://localhost:5253");

        var title = driver.Title;

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

        var textBox = driver.FindElement(By.Name("main-header-image"));
        var submitButton = driver.FindElement(By.("button"));
            
        textBox.SendKeys("Selenium");
        submitButton.Click();
            
        var message = driver.FindElement(By.Id("message"));
        var value = message.Text;
            
        driver.Quit();
    }
}