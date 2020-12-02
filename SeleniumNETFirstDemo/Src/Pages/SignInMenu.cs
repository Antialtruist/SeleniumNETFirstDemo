using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumNETFirstDemo.Src.Pages
{
    public class SignInMenu
    {
        private IWebDriver driver;
        //private WebDriverWait wait;

        public SignInMenu(IWebDriver driver)
        {
            this.driver = driver;
            //wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
            //PageFactory.InitElements(this.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".MuiDialogActions-root>button:nth-child(2)")]
        public IWebElement signIn { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".MuiButton-outlined")]
        public IWebElement signInOut { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement email { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement password { get; set; }

        public void authoriseUser(string email, string pass)
        {
            clickSignInOut();
            clickEmail();
            setEmail(email);
            clickPassword();
            setPassword(pass);
            ClickSignIn();
        }

        private void ClickSignIn() => signIn.Click();

        private void setPassword(string value) => password.SendKeys(value);

        private void clickPassword() => password.Click();

        private void setEmail(string value) => email.SendKeys(value);

        private void clickEmail() => email.Click();

        private void clickSignInOut() => signInOut.Click();
    }
}
