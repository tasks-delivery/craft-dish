package screens;

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

public class Dish3Test extends BaseTest implements DriverActions {

    private Dish2Screen dish2Screen;

    private void preconditions(){
        Dish dish = new Dish("testName" + RandomUtil.getRandomStringWith(10), "testDescr");
        Dish1Screen dish1Screen = page(Dish1Screen.class);
        Dish4Screen dish4Screen = dish1Screen.clickDishesBtn();
        dish2Screen = dish4Screen.clickPlusBtn();
        dish2Screen.inputData(dish.getName(), dish.getDescription());
    }

    @Test
    public void backNavigation(){
        preconditions();
        Dish3Screen dish3Screen = dish2Screen.clickSaveBtn();
        dish3Screen.btnSkip().shouldHave(text(getText("skip")));
        dish3Screen.btnAttach().shouldHave(text(getText("attach")));
        dish3Screen.textSuccessCreated().shouldHave(text(getText("text_dish_was_created_successfully")));
        dish3Screen.textSuccess().shouldHave(text(getText("success")));
        dish3Screen.backNavigation();
        dish3Screen.btnSkip().shouldNotBe(visible);
        dish3Screen.btnAttach().shouldNotBe(visible);
        dish3Screen.textSuccessCreated().shouldNotBe(visible);
        dish3Screen.textSuccess().shouldNotBe(visible);
    }

    @Test
    public void landscapeMode(){
        preconditions();
        dish2Screen.clickSaveBtn();
        assertEquals(Action.changeRotate(ScreenOrientation.LANDSCAPE), ScreenOrientation.PORTRAIT);;
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
