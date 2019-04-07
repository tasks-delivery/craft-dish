package screens;

import config.DriverActions;
import org.openqa.selenium.ScreenOrientation;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

import java.net.MalformedURLException;

import static com.codeborne.selenide.Condition.text;
import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.close;
import static com.codeborne.selenide.Selenide.page;
import static org.testng.Assert.assertEquals;

public class Dish2Test extends BaseTest implements DriverActions {

    @Test
    public void createDish(){
        Dish1Screen dish1Screen = page(Dish1Screen.class);
        Dish4Screen dish4Screen = dish1Screen.navigateToDish4();
        Dish2Screen dish2Screen = dish4Screen.navigateToDish2();
        dish2Screen.btnSave().shouldHave(text(getText("save")));
        dish2Screen.inputData("test name", "test descr");
        dish2Screen.navigateToDish3();
    }

    @Test
    public void backNavigation(){
        Dish1Screen dish1Screen = page(Dish1Screen.class);
        Dish4Screen dish4Screen = dish1Screen.navigateToDish4();
        Dish2Screen dish2Screen = dish4Screen.navigateToDish2();
        dish2Screen.backNavigation();
        dish2Screen.btnSave().shouldNotBe(visible);
    }

    @Test
    public void landscapeMode(){
        Dish1Screen dish1Screen = page(Dish1Screen.class);
        Dish4Screen dish4Screen = dish1Screen.navigateToDish4();
        dish4Screen.navigateToDish2();
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
