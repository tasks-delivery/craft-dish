package screens;

import static com.codeborne.selenide.Condition.text;
import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.closeWebDriver;
import static com.codeborne.selenide.Selenide.page;
import static org.testng.Assert.assertEquals;

import java.net.MalformedURLException;

import driver.DriverActions;
import models.Dish;
import utils.DeviceApiUtil;
import utils.RandomUtil;

import org.openqa.selenium.ScreenOrientation;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

public class Dish5Test extends BaseTest implements DriverActions {

    private Dish3Screen dish3Screen;

    private void preconditions(){
        Dish dish = new Dish("testName" + RandomUtil.getRandomStringWith(10), "testDescr");
        Dish1Screen dish1Screen = page(Dish1Screen.class);
        Dish4Screen dish4Screen = dish1Screen.clickDishesBtn();
        Dish2Screen dish2Screen = dish4Screen.clickPlusBtn();
        dish2Screen.inputData(dish.getName(), dish.getDescription());
        dish3Screen = dish2Screen.clickSaveBtn();
    }

    @Test
    public void backNavigation(){
        preconditions();
        Dish5Screen dish5Screen = dish3Screen.clickAttachBtn();
        dish5Screen.btnSave.shouldHave(text(getText("save")));
        dish5Screen.textPreviewPhoto.shouldHave(text(getText("text_preview_photo")));
        dish5Screen.backNavigation();
        dish5Screen.textPreviewPhoto.shouldNotBe(visible);
    }

    @Test
    public void landscapeMode(){
        preconditions();
        dish3Screen.clickAttachBtn();
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
