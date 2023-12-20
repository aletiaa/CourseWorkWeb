using System.Xml.Serialization;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTesting.Main;

[TestClass]
public class MainTests
{
    private ChromeDriver driver;

    [TestInitialize]
    public void Initialize()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://localhost:5253");
    }

    [TestCleanup]
    public void Cleanup()
    {
        driver.Close();
        driver.Quit();
    }

    [TestMethod]
    public void VerifyPageTitleText_ByTitle()
    { 
        //act
        var pageTitle = driver.Title;
            
        //assert
        Assert.AreEqual("- BreadNMadBakery", pageTitle);
    }

    [TestMethod]
    public void VerifyMainHeaderText_ByTagName()
    {
        //arrange
        
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
    public void GetPagesLinks_Home_XPath_Direct_Path()
    {
        //arrange
        
        //act
        var homePageLink = driver.FindElement(By.XPath("//header/div/ul/li[1]"));

        //assert
        Assert.IsNotNull(homePageLink);
        Assert.AreEqual("Головна", homePageLink.Text);
    }

    [TestMethod]
    public void GetPagesLinks_About_Us_XPath_Text()
    {
        //arrange
        
        //act
        var aboutPageLink = driver.FindElement(By.XPath("//a[text()='Про нас']"));

        //assert
        Assert.IsNotNull(aboutPageLink);
        Assert.AreEqual("Про нас", aboutPageLink.Text);
    }

     [TestMethod]
    public void GetPagesLinks_Contacts_XPath_Starts_With()
    {
        //arrange
                
        //act
        var contactPageLink = driver.FindElement(By.XPath("//a[starts-with(text(), 'Конт')]"));

        //assert
        Assert.IsNotNull(contactPageLink);
        Assert.AreEqual("Контакти", contactPageLink.Text);
    }

    public void GetPagesLinks_Contacts_Not_Found_XPath_Starts_With()
    {
        //arrange
                
        //act
        var contactPageLink = driver.FindElement(By.XPath("//a[starts-with(text(), 'онт')]"));

        //assert
        Assert.IsNull(contactPageLink);
    }

    [TestMethod]
    public void GetPagesLinks_Contacts_XPath_Contains()
    {
        //arrange
        
        //act
        var contactPageLink = driver.FindElement(By.XPath("//a[contains(text(), 'онт')]"));

        //assert
        Assert.IsNotNull(contactPageLink);
        Assert.AreEqual("Контакти", contactPageLink.Text);
    }
}