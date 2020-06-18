package screens;

import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;

import com.codeborne.selenide.SelenideElement;

import constants.Timeout;

import org.openqa.selenium.By;

public class SplashScreen {

    public SplashScreen(){
        progressBar().waitUntil(visible, Timeout.APP_TO_LOAD);
        welcomeText().waitUntil(visible, Timeout.APP_TO_LOAD);
    }

    SelenideElement welcomeText(){
        return $(By.id("splash_screen_welcome_text"));
    }

    SelenideElement progressBar(){
        return $(By.id("spash_screen_progress_bar"));
    }

}
