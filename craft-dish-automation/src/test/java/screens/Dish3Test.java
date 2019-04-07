package screens;

import config.DriverActions;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;

import java.net.MalformedURLException;

import static com.codeborne.selenide.Selenide.close;

public class Dish3Test extends BaseTest implements DriverActions {


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
