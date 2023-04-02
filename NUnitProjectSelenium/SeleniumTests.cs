using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V109.Input;

public class SeleniumTests
{

    IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

    [Test]
    public void TestForQAInWekipedia()
    {
        driver.Url = "https://wikipedia.org";
        driver.FindElement(By.CssSelector("input#searchInput")).Click();
        driver.FindElement(By.CssSelector("input#searchInput")).SendKeys("QA");
        driver.FindElement(By.CssSelector("input#searchInput")).SendKeys(Keys.Enter);

        Assert.AreEqual("https://en.wikipedia.org/wiki/QA", driver.Url);
    }

    [Test]
    public void SummatorOfNumbers()
    {
        driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
        driver.FindElement(By.CssSelector("input#number1")).SendKeys("15");
        //driver.FindElement(By.CssSelector("select#operation")).Click();
        driver.FindElement(By.XPath("//*[@id=\"operation\"]/option[2]")).Click();
        driver.FindElement(By.CssSelector("input#number2")).SendKeys("7");
        driver.FindElement(By.CssSelector("input#calcButton")).SendKeys(Keys.Enter);
        var resultText = driver.FindElement(By.CssSelector("div#result > pre")).Text;
        Assert.That(resultText, Is.EqualTo("22"));
    }

    [Test]
    public void SummatorOfInvalidNumbers()
    {
        driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
        driver.FindElement(By.CssSelector("input#number1")).SendKeys("Hello");
        //driver.FindElement(By.CssSelector("select#operation")).Click();
        driver.FindElement(By.XPath("//*[@id=\"operation\"]/option[2]")).Click();
        driver.FindElement(By.CssSelector("input#number2")).SendKeys("7");
        driver.FindElement(By.CssSelector("input#calcButton")).SendKeys(Keys.Enter);
        var resultText = driver.FindElement(By.CssSelector("div#result > i")).Text;
        Assert.That(resultText, Is.EqualTo("invalid input"));
        var pole1 = driver.FindElement(By.CssSelector("input#number1")).Text;
        Assert.IsEmpty(pole1);
    }
    [Test]
    public void Resetbutton()
    {
        driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
        driver.FindElement(By.CssSelector("input#number1")).SendKeys("15");
        driver.FindElement(By.XPath("//*[@id=\"operation\"]/option[2]")).Click();
        driver.FindElement(By.CssSelector("input#number2")).SendKeys("7");
        driver.FindElement(By.CssSelector("input#calcButton")).SendKeys(Keys.Enter);
        var resultText = driver.FindElement(By.CssSelector("div#result > pre")).Text;
        Assert.That(resultText, Is.EqualTo("22"));
        var pole1 = driver.FindElement(By.CssSelector("input[name='number1']")).GetAttribute("value");
        Assert.IsNotEmpty(pole1);
        var pole2 = driver.FindElement(By.CssSelector("input[name='number2']")).GetAttribute("value");
        Assert.IsNotEmpty(pole2);
        Assert.IsNotEmpty(resultText);
        driver.FindElement(By.CssSelector("input#resetButton")).Click();
        var pole11 = driver.FindElement(By.CssSelector("input[name='number1']")).GetAttribute("value");
        Assert.IsEmpty(pole11);
        var pole21 = driver.FindElement(By.CssSelector("input[name='number2']")).GetAttribute("value");
        Assert.IsEmpty(pole21);
        var resultTextReset = driver.FindElement(By.CssSelector("#result")).Text;
        Assert.IsEmpty(resultTextReset);
    }

}