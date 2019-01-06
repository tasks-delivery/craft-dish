using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.PageObjects;

namespace AppiumBasicSetup.screen
{
    public class Dish1Screen
    {
        private AppiumDriver<AppiumWebElement> _driver;

        [FindsBy(How = How.Id, Using = "dish1_dishes_btn")]
        private IWebElement btn_dishes;

        [FindsBy(How = How.Id, Using = "dish1_ingredients_btn")]
        private IWebElement btn_ingredients;

        [FindsBy(How = How.Id, Using = "imageButton1")]
        private IWebElement btn_github;

        public IWebElement Btn_dishes { get => btn_dishes; }
        public IWebElement Btn_github { get => btn_github; }
        public IWebElement Btn_ingredients { get => btn_ingredients; }

        public Dish1Screen(AppiumDriver<AppiumWebElement> driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

    }

}
