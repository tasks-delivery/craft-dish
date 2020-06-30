package screens;

import static com.codeborne.selenide.CollectionCondition.texts;
import static com.codeborne.selenide.Condition.text;
import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.closeWebDriver;
import static com.codeborne.selenide.Selenide.page;
import static org.testng.Assert.assertEquals;

import java.net.MalformedURLException;

import driver.DriverActions;
import models.Ingredient;
import utils.Action;
import utils.RandomUtil;

import org.openqa.selenium.ScreenOrientation;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

public class Ingredient1ScreenTest extends BaseTest implements DriverActions {

    private Dish1Screen dish1Screen;

    private Ingredient1Screen ingredient1Screen;

    private Ingredient ingredient1 = new Ingredient("testName" + RandomUtil.getRandomStringWith(10), "213");
    private Ingredient ingredient2 = new Ingredient("testName" + RandomUtil.getRandomStringWith(10), "213");
    private Ingredient ingredient3 = new Ingredient("different" + RandomUtil.getRandomStringWith(10), "213");

    private void preconditions(){
        dish1Screen = page(Dish1Screen.class);
        ingredient1Screen = dish1Screen.clickIngredientsBtn();
        createIngredient(ingredient1);
        createIngredient(ingredient2);
        createIngredient(ingredient3);
    }

    @Test
    public void ingredientNameCannotBeMore30Symbolds(){
        ingredient1 = new Ingredient(RandomUtil.getRandomStringWith(31), "213");
        dish1Screen = page(Dish1Screen.class);
        ingredient1Screen = dish1Screen.clickIngredientsBtn();
        createIngredient(ingredient1);
        assertEquals(ingredient1Screen.ingredientNamesList.shouldHaveSize(1).first().getText().length(), 30);
    }

    @Test
    public void searchIngredientByName(){
        preconditions();
        ingredient1Screen.ingredientNamesList.shouldHaveSize(3)
            .shouldHave(texts(ingredient1.getName(), ingredient2.getName(), ingredient3.getName()));
        ingredient1Screen.ingredientWeightList
            .shouldHave(texts(ingredient1.getWeight(), ingredient2.getWeight(), ingredient3.getWeight()));
        ingredient1Screen.searchIngredient(ingredient1.getName());
        ingredient1Screen.ingredientNamesList.shouldHaveSize(1)
            .findBy(text(ingredient1.getName())).shouldBe(visible);
    }

    @Test
    public void searchIngredientByNameContext(){
        preconditions();
        ingredient1Screen.ingredientNamesList.shouldHaveSize(3);
        ingredient1Screen.searchIngredient("test");
        ingredient1Screen.ingredientNamesList.shouldHaveSize(2)
            .findBy(text(ingredient3.getName())).shouldNotBe(visible);
        ingredient1Screen.iconCloseSearch.click();
        ingredient1Screen.ingredientNamesList.shouldHaveSize(3);
    }

    @Test
    public void backNavigation(){
        Dish1Screen dish1Screen = page(Dish1Screen.class);
        Ingredient1Screen ingredient1Screen = dish1Screen.clickIngredientsBtn();
        ingredient1Screen.androidBackNavigation();
        ingredient1Screen.arrowBack.shouldNotBe(visible);
        ingredient1Screen.floatBtnPlus.shouldNotBe(visible);
    }

    @Test
    public void backArrowNavigation(){
        Dish1Screen dish1Screen = page(Dish1Screen.class);
        Ingredient1Screen ingredient1Screen = dish1Screen.clickIngredientsBtn();
        ingredient1Screen.backNavigation();
        ingredient1Screen.arrowBack.shouldNotBe(visible);
        ingredient1Screen.floatBtnPlus.shouldNotBe(visible);
    }

    @Test
    public void landscapeMode(){
        Dish1Screen dish1Screen = page(Dish1Screen.class);
        dish1Screen.clickIngredientsBtn();
        assertEquals(Action.changeRotate(ScreenOrientation.LANDSCAPE), ScreenOrientation.PORTRAIT);
    }

    private void createIngredient(Ingredient ingredient){
        Ingredient2Screen ingredient2Screen = ingredient1Screen.clickPlusBtn();
        ingredient2Screen.inputData(ingredient.getName(), ingredient.getWeight());
        ingredient2Screen.clickSaveBtn();
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