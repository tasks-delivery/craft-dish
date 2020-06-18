package driver;

import java.net.MalformedURLException;

import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;

public interface DriverActions {

    @BeforeMethod
    void setUpDriver() throws MalformedURLException;

    @AfterMethod
    void closeDriver();
}
