package config;

import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;

import java.net.MalformedURLException;

public interface DriverActions {

    @BeforeMethod
    void setUpDriver() throws MalformedURLException;

    @AfterMethod
    void closeDriver();
}
