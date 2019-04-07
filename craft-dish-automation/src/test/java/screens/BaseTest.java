package screens;

import config.BaseConfig;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.openqa.selenium.ScreenOrientation;
import org.openqa.selenium.WebDriverException;

import java.io.FileInputStream;
import java.util.Properties;

public class BaseTest extends BaseConfig {

    private static final Logger log = LogManager.getLogger(BaseTest.class.getName());

    public String getText(String text) {
        FileInputStream fileInputStream;
        Properties property = new Properties();
        try {
            switch (androidDriver.getSessionDetail("language").toString()) {
                case "en":
                    fileInputStream = new FileInputStream("src/main/resources/language_en.xml");
                    property.loadFromXML(fileInputStream);
                    break;
                case "ru":
                    fileInputStream = new FileInputStream("src/main/resources/language_ru.xml");
                    property.loadFromXML(fileInputStream);
                    break;
                case "null":
                    log.warn("Invalid language");
                    break;
                default:
                    break;
            }
        } catch (Exception ignored) {

        }
        return property.getProperty(text);
    }

    public ScreenOrientation changeRotate(ScreenOrientation orientation){
        try {
            driverProvider().rotate(orientation);
        }catch (WebDriverException e){
            return driverProvider().getOrientation();
        }
        log.info("Orientation is: " + driverProvider().getOrientation());
        return driverProvider().getOrientation();
    }

}
