package screens;

import static com.codeborne.selenide.Condition.enabled;
import static com.codeborne.selenide.Condition.text;
import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.back;
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

public class Dish1Test extends BaseTest implements DriverActions {

    @Test
    public void backNavigation(){
        Dish1Screen dish1Screen = page(Dish1Screen.class);
        dish1Screen.btnDishes.shouldBe(enabled).shouldHave(text(getText("dishes_text")));
        dish1Screen.btnIngredients.shouldBe(enabled).shouldHave(text(getText("ingredients_text")));
        dish1Screen.linkGitHub.shouldBe(enabled);
        dish1Screen.textContacts.shouldHave(text(getText("contacts_text")));
        dish1Screen.textSendFeedback.shouldHave(text(getText("send_feedback_text")));
        back();
        dish1Screen.btnDishes.shouldNotBe(visible);
        dish1Screen.btnIngredients.shouldNotBe(visible);
        dish1Screen.linkGitHub.shouldNotBe(visible);
        dish1Screen.textContacts.shouldNotBe(visible);
        dish1Screen.textSendFeedback.shouldNotBe(visible);
    }

    @Test
    public void landscapeMode(){
        page(Dish1Screen.class);
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
