using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RTAutomationTestingTest.UIAutomationExercise;

public class UISeleniumExercise
{
    [Test]
    public void SauceDemo()
    {
        IWebDriver driver = new ChromeDriver();
        // Access the sacuedemo website
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        
        // Login to the website
        driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
        driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        driver.FindElement(By.Id("login-button")).Submit();
        
        //Add the flee jacket to the basket
        driver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket")).Click();
        
        //Confirm and Assert that the jacket is added to the cart
        driver.FindElement(By.Id("shopping_cart_container")).Click();
        var inventory = driver.FindElement(By.ClassName("inventory_item_name"));
        Assert.That(inventory.Text,Is.EqualTo("Sauce Labs Fleece Jacket"));
        driver.FindElement(By.Id("checkout")).Click();
        
        // Fill in the checkout details
        driver.FindElement(By.Id("first-name")).SendKeys("Joe");
        driver.FindElement(By.Id("last-name")).SendKeys("Borg");
        driver.FindElement(By.Id("postal-code")).SendKeys("MLT1000");
        driver.FindElement(By.Id("continue")).Click();
        
        // Assert the iteam value, tax, and total
        var itemTotal = driver.FindElement(By.ClassName("summary_subtotal_label"));
        var totalTax = driver.FindElement(By.ClassName("summary_tax_label"));
        var total = driver.FindElement(By.CssSelector(".summary_info_label.summary_total_label")); //css selector was used since there was a space between the classes

        Assert.Multiple(() =>
        {
            Assert.That(itemTotal.Text, Is.EqualTo("Item total: $49.99"));
            Assert.That(totalTax.Text, Is.EqualTo("Tax: $4.00"));
            Assert.That(total.Text, Is.EqualTo("Total: $53.99"));
        });
        
        driver.FindElement(By.Id("finish")).Click();
        
        //Assert order completion
        var completionText = driver.FindElement(By.ClassName("complete-text"));
        var isCompletionDisplayed = driver.FindElement(By.XPath("//*[@id='checkout_complete_container']/div")).Displayed;

        Assert.Multiple(() =>
        {
            Assert.That(completionText.Text,
                Is.EqualTo("Your order has been dispatched, and will arrive just as fast as the pony can get there!"));
            Assert.That(isCompletionDisplayed, Is.EqualTo(true));
        });
        
        // It will end the process of the automation
        driver.Quit();
    }
    
}