using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumNETFirstDemo.Src.Pages;
using TechTalk.SpecFlow;

namespace SeleniumNETFirstDemo.Test.SpecFlowTests
{
    [Binding]
    public class ChangeUsernameSteps
    {
        private IWebDriver driver;
        private EditProfilePage editProfilePage;
        private SignInMenu signInMenu;
        private string email = "d.bozhevilnyi@gmail.com";
        private string pass = "131089";

        [Given(@"I have navigated to the Edit Profile page")]
        public void GivenIHaveNavigatedToTheEditProfilePage()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://eventsexpress-test.azurewebsites.net/home/events?page=1";
            driver.Manage().Window.Maximize();
            editProfilePage = new EditProfilePage(driver);
            signInMenu = new SignInMenu(driver);
            signInMenu.authoriseUser(email, pass);
            editProfilePage.clickEditProfileButton();
        }
        
        [Given(@"Changed my user name to ""(.*)""")]
        public void GivenChangedMyUserNameTo(string name)
        {
            editProfilePage.changeUserName(name);
        }
        
        [Then(@"should appear pop-up window ""(.*)""")]
        public void ThenShouldAppearPop_UpWindow(string message)
        {
            Assert.AreEqual(editProfilePage.getClientSnackbarText(), message);
            driver.Close();
        }
    }
}
