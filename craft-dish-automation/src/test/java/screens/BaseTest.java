package screens;

import java.io.FileInputStream;
import java.util.Properties;

import driver.DriverConfig;
import utils.Action;

import org.apache.log4j.Logger;

public class BaseTest extends DriverConfig {

    private static final Logger log = Logger.getLogger(BaseTest.class.getName());

    String getText(String text) {
        FileInputStream fileInputStream;
        Properties property = new Properties();
        try {
            switch (Action.getSessionLanguage()) {
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

}
