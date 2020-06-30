package utils;

import com.codeborne.selenide.WebDriverRunner;

import io.appium.java_client.android.AndroidDriver;

import org.apache.log4j.Logger;
import org.openqa.selenium.ScreenOrientation;
import org.openqa.selenium.WebDriverException;

public class DeviceApiUtil {

    private static final Logger log = Logger.getLogger(DeviceApiUtil.class.getName());

    public static void hideKeyboard(){
        AndroidDriver driver = (AndroidDriver) WebDriverRunner.getWebDriver();
        driver.hideKeyboard();
    }

    public static String getLocale(){
        AndroidDriver driver = (AndroidDriver) WebDriverRunner.getWebDriver();
        return driver.getCapabilities().getCapability("locale").toString();
    }

    public static String getSessionLanguage(){
        AndroidDriver driver = (AndroidDriver) WebDriverRunner.getWebDriver();
        return driver.getSessionDetail("language").toString();
    }

    public static ScreenOrientation changeRotate(ScreenOrientation orientation){
        AndroidDriver driver = (AndroidDriver) WebDriverRunner.getWebDriver();
        try {
            driver.rotate(orientation);
        }catch (WebDriverException e){
            return driver.getOrientation();
        }
        log.info("Orientation is: " + driver.getOrientation());
        return driver.getOrientation();
    }
}
