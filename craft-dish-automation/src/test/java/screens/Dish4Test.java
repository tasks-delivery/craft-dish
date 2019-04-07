package screens;

import config.DataGenerator;
import config.DriverActions;
import models.Dish;
import org.openqa.selenium.ScreenOrientation;
import org.testng.Assert;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

import java.net.MalformedURLException;

import static com.codeborne.selenide.Condition.*;
import static com.codeborne.selenide.Selenide.*;
import static org.testng.Assert.assertEquals;

public class Dish4Test extends BaseTest implements DriverActions {

    private Dish1Screen dish1Screen;

    private Dish4Screen dish4Screen;

    private Dish2Screen dish2Screen;

    private Dish dish1, dish2, dish3;

    private void preconditions(){
        dish1 = new Dish("testName", "testDescr");
        dish1 = new DataGenerator().dish(dish1);
        dish2 = new Dish("testName", "testDescr");
        dish2 = new DataGenerator().dish(dish2);
        dish3 = new Dish("different", "testDescr");
        dish3 = new DataGenerator().dish(dish3);
        dish1Screen = page(Dish1Screen.class);
        dish4Screen = dish1Screen.clickDishesBtn();
        createDish(dish1);
        createDish(dish2);
        createDish(dish3);
    }

    @Test
    public void dishNameCannotBeMore30Symbolds(){
        dish1 = new Dish("testName", "testDescr");
        dish1 = new DataGenerator().dish(dish1);
        dish1.setName(dish1.getName() + "limited");
        dish1Screen = page(Dish1Screen.class);
        dish4Screen = dish1Screen.clickDishesBtn();
        createDish(dish1);
        Assert.assertEquals(dish4Screen.dishNamesList().shouldHaveSize(1).first().getText().length(), 30);
    }

    @Test
    public void searchDishByName(){
        preconditions();
        dish4Screen.dishNamesList().shouldHaveSize(3)
                .findBy(text(dish1.getName())).shouldBe(visible);
        dish4Screen.dishNamesList()
                .findBy(text(dish2.getName())).shouldBe(visible);
        dish4Screen.dishNamesList()
                .findBy(text(dish3.getName())).shouldBe(visible);
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
        assertEquals(changeRotate(ScreenOrientation.LANDSCAPE), ScreenOrientation.PORTRAIT);
    }

    private void createDish(Dish dish){
        dish2Screen = dish4Screen.clickPlusBtn();
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
        close();
    }
}
