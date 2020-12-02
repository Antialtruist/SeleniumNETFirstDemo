using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumNETFirstDemo.Src.Pages;

namespace SeleniumNETFirstDemo.Test
{
    class EditProfilePageTest
    {
		private IWebDriver driver;
		private EditProfilePage editProfilePage;
		private SignInMenu signInMenu;
		private string email = "d.bozhevilnyi@gmail.com";
		private string pass = "131089";

		[SetUp]
		public void Setup()
		{
			editProfilePage = new EditProfilePage(driver);
			signInMenu = new SignInMenu(driver);
			//PageFactory.InitElements(driver, this);
			//PageFactory.InitElements(driver, editProfilePage);
			//PageFactory.InitElements(driver, signInMenu);
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
			driver.Url = "https://eventsexpress-qa.azurewebsites.net/home/events?page=1";
			driver.Manage().Window.Maximize();
			signInMenu.authoriseUser(email, pass);
			editProfilePage.clickEditProfileButton();
		}

		[Test]
		public void ChangeUsernameTest()
		{
			editProfilePage.changeUserName("Saul");
            Assert.AreEqual(editProfilePage.getClientSnackbarText(), "Username is changed");
		}

		[TearDown]
		public void closeBrowser()
		{
			driver.Close();
		}
	}
}
