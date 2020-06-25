package screens;

import static com.codeborne.selenide.Condition.attribute;
import static com.codeborne.selenide.Condition.text;
import static com.codeborne.selenide.Selenide.closeWebDriver;
import static com.codeborne.selenide.Selenide.page;
import static org.assertj.core.api.Java6Assertions.assertThat;
import static org.testng.Assert.assertEquals;

import java.net.MalformedURLException;

import driver.DriverActions;
import models.Dish;
import models.Ingredient;
import utils.Action;
import utils.RandomUtil;

import org.openqa.selenium.ScreenOrientation;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

public class Dish6Test extends BaseTest implements DriverActions {

    private Dish dish = new Dish("testName" + RandomUtil.getRandomStringWith(10), "testDescr");
    private Ingredient ingredient1 = new Ingredient("testName" + RandomUtil.getRandomStringWith(10), "213");

    @Test(description = "if clickable = true, Dish have not photo")
    public void dishDefaultPhoto(){
        preconditions();
        Dish6Screen dish6Screen = new Dish4Screen().openDishByName(dish.getName());
        dish6Screen.dishDescription.shouldHave(text(dish.getDescription()));
        dish6Screen.dishName.shouldHave(text(dish.getName()));
        dish6Screen.dishPhoto.shouldNotHave(attribute("clickable", "true"));
    }

    @Test
    public void navigateToDish7ByEditIcon(){
        preconditions();
        Object dish7Screen = new Dish4Screen().openDishByName(dish.getName()).clickEditIcon();
        assertThat(dish7Screen).isInstanceOf(Dish7Screen.class);
    }

    @Test
    public void removeAllIngredientsFromDish(){
        preconditions();
        Ingredient1Screen ingredient1Screen = new Dish4Screen().openDishByName(dish.getName()).removeIngredient();

    }

    @Test
    public void removeOneIngredientFromDish(){
        preconditions();
        Object ingredient1Screen = new Dish4Screen().openDishByName(dish.getName()).removeIngredient();
        assertThat(ingredient1Screen).isInstanceOf(Ingredient1Screen.class);
    }

    @Test
    public void addIngredientToDish(){
        Ingredient1Screen ingredient1Screen = createIngredient(ingredient1).clickDishesBtn()
            .openDishByName(dish.getName()).addIngredient();
        ingredient1Screen.selectIngredientByName(ingredient1.getName());

        System.out.println("t");
    }

    @Test
    public void backNavigationByArrow(){
        preconditions();
        Object dish4Screen = new Dish4Screen().openDishByName(dish.getName()).clickBackArrow();
        assertThat(dish4Screen).isInstanceOf(Dish4Screen.class);
    }

    @Test
    public void backNavigationByAndroidBtn(){
        preconditions();
        Object dish4Screen = new Dish4Screen().openDishByName(dish.getName()).clickAndroidBackBtn();
        assertThat(dish4Screen).isInstanceOf(Dish4Screen.class);
    }

    @Test
    public void landscapeMode(){
        preconditions();
        new Dish4Screen().openDishByName(dish.getName());
        assertEquals(Action.changeRotate(ScreenOrientation.LANDSCAPE), ScreenOrientation.PORTRAIT);
    }

    private Dish4Screen preconditions(){
        return page(Dish1Screen.class).clickDishesBtn().clickPlusBtn()
            .inputData(dish.getName(), dish.getDescription()).clickSaveBtn().clickSkipBtn();
    }

    private Dish1Screen createIngredient(Ingredient ingredient){
        return preconditions().backNavigation().clickIngredientsBtn().clickPlusBtn()
            .inputData(ingredient.getName(), ingredient.getWeight()).clickSaveBtn().androidBackNavigation();
    }


    @BeforeMethod
    @Override
    public void setUpDriver() throws MalformedURLException {
        setUp();
    }

    @AfterMethod
    @Override
    public void closeDriver() {
        closeWebDriver();
    }

}