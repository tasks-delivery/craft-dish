package screens;

import static com.codeborne.selenide.CollectionCondition.texts;
import static com.codeborne.selenide.Condition.text;
import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.closeWebDriver;
import static com.codeborne.selenide.Selenide.page;
import static org.testng.Assert.assertEquals;

import java.net.MalformedURLException;

import driver.DriverActions;
import models.Dish;
import utils.Action;
import utils.RandomUtil;

import org.openqa.selenium.ScreenOrientation;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

public class Dish4Test extends BaseTest implements DriverActions {

    private Dish1Screen dish1Screen;

    private Dish4Screen dish4Screen;

    private Dish dish1, dish2, dish3;

    private void preconditions(){
        dish1 = new Dish("testName" + RandomUtil.getRandomStringWith(10), "testDescr");
        dish2 = new Dish("testName" + RandomUtil.getRandomStringWith(10), "testDescr");
        dish3 = new Dish("different" + RandomUtil.getRandomStringWith(10), "testDescr");
        dish1Screen = page(Dish1Screen.class);
        dish4Screen = dish1Screen.clickDishesBtn();
        createDish(dish1);
        createDish(dish2);
        createDish(dish3);
    }

    @Test
    public void dishNameCannotBeMore30Symbolds(){
        dish1 = new Dish(RandomUtil.getRandomStringWith(31), "testDescr");
        dish1Screen = page(Dish1Screen.class);
        dish4Screen = dish1Screen.clickDishesBtn();
        createDish(dish1);
        assertEquals(dish4Screen.dishNamesList().shouldHaveSize(1).first().getText().length(), 30);
    }

    @Test
    public void searchDishByName(){
        preconditions();
        dish4Screen.dishNamesList().shouldHaveSize(3)
            .shouldHave(texts(dish1.getName(), dish2.getName(), dish3.getName()));
        dish4Screen.searchDish(dish1.getName());
        dish4Screen.dishNamesList().shouldHaveSize(1)
                .findBy(text(dish1.getName())).shouldBe(visible);
    }

    @Test
    public void searchDishByNameContext(){
        preconditions();
        dish4Screen.dishDescriptionsList().shouldHaveSize(3)
                .filterBy(text("testDescr")).shouldHaveSize(3);
        dish4Screen.dishNamesList().shouldHaveSize(3);
        dish4Screen.searchDish("test");
        dish4Screen.dishNamesList().shouldHaveSize(2)
                .findBy(text(dish3.getName())).shouldNotBe(visible);
        dish4Screen.iconCloseSearch().click();
        dish4Screen.dishNamesList().shouldHaveSize(3);
    }

    @Test
    public void backNavigation(){
        Dish1Screen dish1Screen = page(Dish1Screen.class);
        Dish4Screen dish4Screen = dish1Screen.clickDishesBtn();
        dish4Screen.androidBackNavigation();
        dish4Screen.arrowBack().shouldNotBe(visible);
        dish4Screen.floatBtnPlus().shouldNotBe(visible);
    }

    @Test
    public void backArrowNavigation(){
        Dish1Screen dish1Screen = page(Dish1Screen.class);
        Dish4Screen dish4Screen = dish1Screen.clickDishesBtn();
        dish4Screen.backNavigation();
        dish4Screen.arrowBack().shouldNotBe(visible);
        dish4Screen.floatBtnPlus().shouldNotBe(visible);
    }

    @Test
    public void landscapeMode(){
        Dish1Screen dish1Screen = page(Dish1Screen.class);
        dish1Screen.clickDishesBtn();
        assertEquals(Action.changeRotate(ScreenOrientation.LANDSCAPE), ScreenOrientation.PORTRAIT);
    }

    private void createDish(Dish dish){
        Dish2Screen dish2Screen = dish4Screen.clickPlusBtn();
        dish2Screen.inputData(dish.getName(), dish.getDescription());
        Dish3Screen dish3Screen = dish2Screen.clickSaveBtn();
        dish3Screen.clickSkipBtn();
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
