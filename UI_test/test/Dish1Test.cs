using AppiumBasicSetup.screen;
using NUnit.Framework;

namespace AppiumBasicSetup.test
{
    public class Dish1Test : ConciseApi
    {

        [SetUp()]
        public void preconditions()
        {
            waitAppLoading();
        }

        [Test()]
        public void SmokeTestForDish1Screen()
        {           
            Dish1Screen dish1 = new Dish1Screen(driver);           
            Assert.True(dish1.Btn_dishes.Displayed);
            Assert.True(dish1.Btn_ingredients.Displayed);
            Assert.AreEqual("Dishes", dish1.Btn_dishes.Text);
            Assert.AreEqual("Ingredients", dish1.Btn_ingredients.Text);
            Assert.True(dish1.Btn_github.Displayed);
        }
       
        [Test()]
        public void backNavigation()
        {
            Dish1Screen dish1 = new Dish1Screen(driver);       
            driver.Navigate().Back();
            Assert.False(IsElementPresent(dish1.Btn_ingredients));
            Assert.False(IsElementPresent(dish1.Btn_dishes));       
            Assert.False(IsElementPresent(dish1.Btn_github));  
        }

    }
}
