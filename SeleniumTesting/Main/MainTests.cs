using System.Xml.Serialization;
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

    [TestMethod]
    public void MainHeaderText()
    {
        //arrange
        var driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://localhost:5253");
        var headerElement = driver.FindElement(By.TagName("header"));
        var paragraphElement = headerElement.FindElement(By.TagName("p"));

        //act
        var className = paragraphElement.GetAttribute("class");
        var paragraphText = paragraphElement.Text;

        //assert
        Assert.AreEqual("company-name", className);
        Assert.AreEqual("BREAD'N'MAD", paragraphText);
      
    }
}