using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace SeleniumNETFirstDemo.Src.Pages
{
    public class BasePage
    {
        public IWebDriver driver;
        public WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }
    }
}
