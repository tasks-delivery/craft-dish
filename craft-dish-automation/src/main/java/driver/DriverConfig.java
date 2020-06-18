package driver;

import static com.codeborne.selenide.WebDriverRunner.setWebDriver;

import java.io.IOException;
import java.net.MalformedURLException;
import java.net.URL;

import com.codeborne.selenide.Configuration;

import constants.Timeout;
import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.remote.MobileCapabilityType;
import utils.DownloadUtil;

import org.apache.log4j.Logger;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.testng.annotations.BeforeSuite;

public class DriverConfig {

    private static final Logger log = Logger.getLogger(DriverConfig.class.getName());

    private String currentDir = System.getProperty("user.dir");

    private static String lang = System.getProperty("lang");

    public String appName = "Craft_dish.Craft_dish";

    @BeforeSuite
    public void setUpEnvironment() throws IOException {
        if (lang != null) {
            DownloadUtil downloadUtil = new DownloadUtil();
            downloadUtil.downloadApk();
            log.info("Tests are started on CI");
        }else {
            lang = System.setProperty("lang", "en");
        }
        log.info("Language is: " + getLang());
    }

    private String getLang() {
        return System.getProperty("lang");
    }

    private DesiredCapabilities setUpCaps(){
        DesiredCapabilities cap = new DesiredCapabilities();
        cap.setCapability(MobileCapabilityType.VERSION, "7.1");
        cap.setCapability("platformName", "Android");
        cap.setCapability("deviceName", "emulator-5554");
        cap.setCapability("clearSystemFiles",true);
        cap.setCapability("autoGrantPermissions", true);
        cap.setCapability("noSign", true);
        cap.setCapability("app", currentDir + "/Craft_dish.Craft_dish-Signed.apk");
        cap.setCapability("language",getLang());
        cap.setCapability("locale",getLang());
        return cap;
    }

    public void setUp() throws MalformedURLException {
        AndroidDriver androidDriver = new AndroidDriver(new URL("http://localhost:4800/wd/hub"), setUpCaps());
        setWebDriver(androidDriver);
        Configuration.timeout = Timeout.APP_TO_LOAD;
    }
}