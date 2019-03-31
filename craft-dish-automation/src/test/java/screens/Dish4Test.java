package screens;

import config.DriverActions;
import org.openqa.selenium.ScreenOrientation;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

import java.net.MalformedURLException;

import static com.codeborne.selenide.Condition.*;
import static com.codeborne.selenide.Selenide.*;
import static org.testng.Assert.assertEquals;

public class Dish4Test extends BaseTest implements DriverActions {

    @Test
    public void backNavigation(){
        Dish1Screen dish1Screen = page(Dish1Screen.class);
        Dish4Screen dish4Screen = dish1Screen.navigateToDish4();
        back();
        dish4Screen.arrowBack().shouldNotBe(visible);
        dish4Screen.floadBtnPlus().shouldNotBe(visible);
    }

    @Test
    public void landscapeMode(){
        Dish1Screen dish1Screen = page(Dish1Screen.class);
        dish1Screen.navigateToDish4();
        assertEquals(changeRotate(ScreenOrientation.LANDSCAPE), ScreenOrientation.PORTRAIT);
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
