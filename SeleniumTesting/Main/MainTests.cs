using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTesting.Main;

[TestClass]
public class MainTests
{
    [TestMethod]
    public void PageTitleText()
    {
        //arrange
        var driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://localhost:5253");
            
        //act
        var pageTitle = driver.Title;
            
        //assert
        Assert.AreEqual("- BreadNMadBakery", pageTitle);

        driver.Quit();
    }
}