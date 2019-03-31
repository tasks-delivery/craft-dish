package config;

import com.codeborne.selenide.Configuration;
import com.codeborne.selenide.WebDriverRunner;
import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.remote.MobileCapabilityType;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.apache.logging.log4j.core.LoggerContext;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.testng.annotations.BeforeSuite;

import java.io.File;
import java.net.MalformedURLException;
import java.net.URL;

import static com.codeborne.selenide.WebDriverRunner.setWebDriver;

public class BaseConfig {

    private static final Logger log = LogManager.getLogger(BaseConfig.class.getName());

    public String appName = "Craft_dish.Craft_dish";

    public AndroidDriver androidDriver;

    public AndroidDriver driverProvider(){
        return (AndroidDriver) WebDriverRunner.getWebDriver();
    }

    private String currentDir = System.getProperty("user.dir");

    private void setLogger(){
        LoggerContext context = (org.apache.logging.log4j.core.LoggerContext) LogManager.getContext(false);
        File file = new File("src/main/Resources/Log4j2.xml");
        context.setConfigLocation(file.toURI());
    }

    private static String lang = System.getProperty("lang");

    @BeforeSuite
    public void SetUpEnvironment(){
        setLogger();
        if (lang != null) {
            log.info("Tests are started on CI");
        }else {
            lang = System.setProperty("lang", "en");
        }
        log.info("Language is: " + getLang());
    }

    public String getLang() {
        return System.getProperty("lang");
    }

    private DesiredCapabilities setUpCaps(){
        DesiredCapabilities cap = new DesiredCapabilities();
        cap.setCapability(MobileCapabilityType.VERSION, "7.1");
        cap.setCapability("platformName", "Android");
        cap.setCapability("deviceName", "Emulator");
        cap.setCapability("clearSystemFiles",true);
        cap.setCapability("autoGrantPermissions", true);
        cap.setCapability("noSign", true);
        cap.setCapability("app", currentDir + "\\Craft_dish.Craft_dish-Signed.apk");
        cap.setCapability("language",getLang());
        cap.setCapability("locale",getLang());
        return cap;
    }

    public void setUp() throws MalformedURLException {
        androidDriver = new AndroidDriver(new URL("http://localhost:4800/wd/hub"), setUpCaps());
        setWebDriver(androidDriver);
        Configuration.timeout = 1000;
    }

    public int waitForLoadScreen(){
        return 10000;
    }

}
