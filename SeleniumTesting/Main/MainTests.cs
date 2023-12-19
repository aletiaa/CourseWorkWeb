using System.Xml.Serialization;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTesting.Main;

[TestClass]
public class MainTests
{
    [TestMethod]
    public void VerifyPageTitleText_ByTitle()
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
    public void VerifyMainHeaderText_ByTagName()
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

    [TestMethod]
    public void VerifyCartImage_ById()
    {
        //arrange
        var driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://localhost:5253");

        //act
        var cartImage = driver.FindElement(By.Id("Flat"));

        //assert
        Assert.IsNotNull(cartImage);
        Assert.AreEqual("svg", cartImage.TagName);
        Assert.AreEqual("20px", cartImage.GetAttribute("width"));
        Assert.AreEqual("20px", cartImage.GetAttribute("height"));
        Assert.AreEqual("white", cartImage.GetAttribute("fill"));
    }

    [TestMethod]
    public void VerifyCartImage_XPath_ById()
    {
        //arrange
        var driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://localhost:5253");

        //act
        var cartImage = driver.FindElement(By.XPath("//*[@id='Flat']"));

        //assert
        Assert.IsNotNull(cartImage);
        Assert.AreEqual("svg", cartImage.TagName);
        Assert.AreEqual("20px", cartImage.GetAttribute("width"));
        Assert.AreEqual("20px", cartImage.GetAttribute("height"));
        Assert.AreEqual("white", cartImage.GetAttribute("fill"));
    }

    [TestMethod]
    public void GetPagesLinks_Home_XPath()
    {
        //arrange
        var driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://localhost:5253");
        
        //act
        var homePageLink = driver.FindElement(By.XPath("//header/div/ul/li[1]"));

        //assert
        Assert.IsNotNull(homePageLink);
        Assert.AreEqual("Головна", homePageLink.Text);
    }
}