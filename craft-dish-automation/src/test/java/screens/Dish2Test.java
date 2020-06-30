package screens;

import static com.codeborne.selenide.Condition.text;
import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.closeWebDriver;
import static com.codeborne.selenide.Selenide.page;
import static org.testng.Assert.assertEquals;

import java.net.MalformedURLException;

import driver.DriverActions;
import utils.DeviceApiUtil;

import org.openqa.selenium.ScreenOrientation;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

public class Dish2Test extends BaseTest implements DriverActions {

    @Test
    public void createDish(){
        Dish1Screen dish1Screen = page(Dish1Screen.class);
        Dish4Screen dish4Screen = dish1Screen.clickDishesBtn();
        Dish2Screen dish2Screen = dish4Screen.clickPlusBtn();
        dish2Screen.btnSave.shouldHave(text(getText("save")));
        dish2Screen.inputData("test name", "test descr");
        dish2Screen.clickSaveBtn();
    }

    @Test
    public void backNavigation(){
        Dish1Screen dish1Screen = page(Dish1Screen.class);
        Dish4Screen dish4Screen = dish1Screen.clickDishesBtn();
        Dish2Screen dish2Screen = dish4Screen.clickPlusBtn();
        dish2Screen.backNavigation();
        dish2Screen.btnSave.shouldNotBe(visible);
    }

    @Test
    public void dishNameCannotBeEmpty(){
        Dish1Screen dish1Screen = page(Dish1Screen.class);
        Dish4Screen dish4Screen = dish1Screen.clickDishesBtn();
        Dish2Screen dish2Screen = dish4Screen.clickPlusBtn();
        dish2Screen.btnSave.click();
        dish2Screen.btnSave.shouldBe(visible);
    }

    @Test
    public void dishNameCannotBeContainsOnlySpaces(){
        Dish1Screen dish1Screen = page(Dish1Screen.class);
        Dish4Screen dish4Screen = dish1Screen.clickDishesBtn();
        Dish2Screen dish2Screen = dish4Screen.clickPlusBtn();
        dish2Screen.inputData("                              ", "");
        dish2Screen.btnSave.click();
        dish2Screen.btnSave.shouldBe(visible);
    }

    @Test
    public void landscapeMode(){
        Dish1Screen dish1Screen = page(Dish1Screen.class);
        Dish4Screen dish4Screen = dish1Screen.clickDishesBtn();
        dish4Screen.clickPlusBtn();
        assertEquals(DeviceApiUtil.changeRotate(ScreenOrientation.LANDSCAPE), ScreenOrientation.PORTRAIT);
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
