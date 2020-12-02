using System;
using System.Collections.Generic;
using System.Text;
using NodaTime;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumNETFirstDemo.Src.Pages
{
    public class EditProfilePage
    {
		private IWebDriver driver;
        //private WebDriverWait wait;

        public EditProfilePage(IWebDriver driver)
		{
			//this.driver = driver;
			//wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
			//PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.CssSelector, Using = "#main>div>div:nth-child(1)")]
        public IWebElement changeAvatarField { get; set; }

		[FindsBy(How = How.CssSelector, Using = "img.pic")]
		public IWebElement occupiedAvatarField { get; set; }

		[FindsBy(How = How.CssSelector, Using = ".uk-button")]
		public IWebElement clearAvatarButton { get; set; }

		[FindsBy(How = How.CssSelector, Using = "#panel1bh-content div:nth-child(3)>button")]
		public IWebElement submitAvatarButton { get; set; }

		[FindsBy(How = How.CssSelector, Using = "input[type='file']")]
		public IWebElement uploaderAvatarComponent { get; set; }

		[FindsBy(How = How.CssSelector, Using = "#main>div>div:nth-child(2)")]
		public IWebElement usernameField { get; set; }

		[FindsBy(How = How.CssSelector, Using = "input[name='UserName']")]
		public IWebElement inputUsernameComponent { get; set; }

		[FindsBy(How = How.CssSelector, Using = "#panel1bh-content div:nth-child(2)>button:nth-child(1)")]
		public IWebElement submitUsernameButton { get; set; }

		[FindsBy(How = How.CssSelector, Using = "#main>div>div:nth-child(3)")]
		public IWebElement genderField { get; set; }

		[FindsBy(How = How.CssSelector, Using = "div[name=Gender] div:nth-child(2)")]
		public IWebElement chooseGenderDropDownList { get; set; }

		[FindsBy(How = How.CssSelector, Using = "#panel2bh-content div:nth-child(2)>button")]
		public IWebElement submitGenderButton { get; set; }

		[FindsBy(How = How.CssSelector, Using = "#main>div>div:nth-child(4)")]
		public IWebElement dateOfBirthField { get; set; }

		[FindsBy(How = How.CssSelector, Using = "div.react-datepicker__input-container>input")]
		public IWebElement inputDateOfBirthComponent { get; set; }

		[FindsBy(How = How.CssSelector, Using = "#panel3bh-content button:nth-child(1)")]
		public IWebElement submitDateOfBirthButton { get; set; }

		[FindsBy(How = How.CssSelector, Using = "#main>div>div:nth-child(5)")]
		public IWebElement favoriteCategoriesField { get; set; }

		[FindsBy(How = How.CssSelector, Using = ".rw-widget-container")]
		public IWebElement favoriteCategoriesDropDownList { get; set; }

		[FindsBy(How = How.CssSelector, Using = "li[role='option']")]
		public IWebElement favoriteCategoriesDropDownListElements { get; set; }

		[FindsBy(How = How.CssSelector, Using = "#panel4bh-content>div")]
		public IWebElement emptyFieldFavoriteCategories { get; set; }

		[FindsBy(How = How.XPath, Using = "//span[contains(text(),'Save')]")]
		public IWebElement favoriteCategoriesSaveButton { get; set; }

		[FindsBy(How = How.CssSelector, Using = "#main>div>div:nth-child(6)")]
		public IWebElement changePasswordField { get; set; }

		[FindsBy(How = How.CssSelector, Using = "input[name='oldPassword']")]
		public IWebElement inputCurrentPasswordComponent { get; set; }

		[FindsBy(How = How.CssSelector, Using = "input[name='newPassword']")]
		public IWebElement inputNewPasswordComponent { get; set; }

		[FindsBy(How = How.CssSelector, Using = "input[name='repeatPassword']")]
		public IWebElement repeatNewPasswordComponent { get; set; }

		[FindsBy(How = How.CssSelector, Using = "div.mt-2>button:nth-child(1)")]
		public IWebElement submitChangePasswordButton { get; set; }

		[FindsBy(How = How.CssSelector, Using = "div[role='alertdialog']")]
		public IWebElement clientSnackbar { get; set; }

		[FindsBy(How = How.CssSelector, Using = "button[title='Edit your profile']")]
		public IWebElement editProfileButton { get; set; }

		public void clickEditProfileButton() => editProfileButton.Click();

		public string getClientSnackbarText()
		{
			return clientSnackbar.Text;
		}

		public void clickOnChangeAvatarField() => changeAvatarField.Click();

		public void clickOnClearAvatarButton() => clearAvatarButton.Click();

		public void clickOnSubmitAvatarButton() => submitAvatarButton.Click();

		public void loadAvatar(string imagePath) => uploaderAvatarComponent.SendKeys(imagePath);

		public void changeAvatar(string imagePath)
		{
			clickOnChangeAvatarField();
			if (occupiedAvatarField.Enabled)
			{
				clickOnClearAvatarButton();
			}
			loadAvatar(imagePath);
			clickOnSubmitAvatarButton();
		}

		public void clickOnUsernameField() => usernameField.Click();

		public void setUsernameIntoInputComponent(string name) => inputUsernameComponent.SendKeys(name);

		public void clickOnSubmitUsernameButton() => submitUsernameButton.Click();

		public void changeUserName(string name)
		{
			clickOnUsernameField();
			setUsernameIntoInputComponent(name);
			clickOnSubmitUsernameButton();
		}

		public void clickOnGenderField() => genderField.Click();

		public void clickOnChooseGenderDropDownList() => chooseGenderDropDownList.Click();

		public void clickOnSubmitGenderButton() => submitGenderButton.Click();

		public void selectGender(string gender)
		{
			string genderXpath = string.Format("//div[contains(text(),'%s')]", gender);
			driver.FindElement(By.XPath(genderXpath)).Click();
		}

		public void chooseGender(string gender)
		{
			clickOnGenderField();
			clickOnChooseGenderDropDownList();
			selectGender(gender);
			clickOnSubmitGenderButton();
		}

		public void clickOnDateOfBirthField() => dateOfBirthField.Click();

		public void clickOnInputDateOfBirthComponent() => inputDateOfBirthComponent.Click();

		public void clickOnSubmitDateOfBirthButton() => submitDateOfBirthButton.Click();

		public void setDateOfBirth(LocalDate date)
		{
			clickOnDateOfBirthField();
			inputDateOfBirthComponent.SendKeys(Keys.Control + "a");
			inputDateOfBirthComponent.SendKeys(Keys.Delete);
			inputDateOfBirthComponent.SendKeys(date.Month + "/" + date.Day + "/" + date.Year);
			inputDateOfBirthComponent.SendKeys(Keys.Enter);
			clickOnSubmitDateOfBirthButton();
		}

		public void clickOnFavoriteCategoriesField() => favoriteCategoriesField.Click();

		public void clickOnFavoriteCategoriesDropDownList() => favoriteCategoriesDropDownList.Click();

		public void clickOnEmptyFieldFavoriteCategories() => emptyFieldFavoriteCategories.Click();

		public void clickOnFavoriteCategoriesSaveButton() => favoriteCategoriesSaveButton.Click();

		public void selectCategory(string category)
		{
			string categoryXpath = string.Format("//li[contains(text(),'%s')]", category);
			driver.FindElement(By.XPath(categoryXpath)).Click();
		}

		public void chooseFavoriteCategories(string category)
		{
			clickOnFavoriteCategoriesField();
			clickOnFavoriteCategoriesDropDownList();
			//wait.Until(ExpectedConditions.ElementIsVisible((By)favoriteCategoriesDropDownListElements);
			selectCategory(category);
			clickOnEmptyFieldFavoriteCategories();
			clickOnFavoriteCategoriesSaveButton();
		}

		public void clickOnChangePasswordField() => changePasswordField.Click();

		public void setCurrentPasswordComponent(string currentPassword) => inputCurrentPasswordComponent.SendKeys(currentPassword);

		public void setNewPasswordComponent(string newPassword) => inputNewPasswordComponent.SendKeys(newPassword);

		public void setRepeatNewPasswordComponent(string repNewPassword) => repeatNewPasswordComponent.SendKeys(repNewPassword);

		public void clickOnSubmitChangePasswordButton() => submitChangePasswordButton.Click();

		public void changePassword(string currentPassword, string newPassword, string repNewPassword)
		{
			clickOnChangePasswordField();
			setCurrentPasswordComponent(currentPassword);
			setNewPasswordComponent(newPassword);
			setRepeatNewPasswordComponent(repNewPassword);
			clickOnSubmitChangePasswordButton();
		}
	}
}
