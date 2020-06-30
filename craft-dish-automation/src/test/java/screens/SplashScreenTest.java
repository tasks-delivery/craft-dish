package screens;

import static com.codeborne.selenide.Condition.text;
import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.back;
import static com.codeborne.selenide.Selenide.closeWebDriver;
import static com.codeborne.selenide.Selenide.page;
import static org.testng.Assert.assertEquals;

import java.net.MalformedURLException;

import driver.DriverActions;
import utils.Action;

import org.openqa.selenium.ScreenOrientation;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

public class SplashScreenTest extends BaseTest implements DriverActions {

    @Test
    public void backNavigation(){
        SplashScreen splashScreen = page(SplashScreen.class);
        splashScreen.welcomeText.shouldHave(text(getText("welcome_text")));
        back();
        splashScreen.welcomeText.shouldNotBe(visible);
        splashScreen.progressBar.shouldNotBe(visible);
    }

    @Test
    public void landscapeMode(){
        page(SplashScreen.class);
        assertEquals(Action.changeRotate(ScreenOrientation.LANDSCAPE), ScreenOrientation.PORTRAIT);
    }

    @Override
    @BeforeMethod
    public void setUpDriver() throws MalformedURLException {
        setUp();
    }

    @Override
    @AfterMethod
    public void closeDriver(){
        closeWebDriver();
    }


}
