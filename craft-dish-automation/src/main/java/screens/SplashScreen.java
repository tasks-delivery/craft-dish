package screens;

import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;

import com.codeborne.selenide.SelenideElement;

import constants.Timeout;

import org.openqa.selenium.By;

public class SplashScreen {

    SelenideElement welcomeText = $(By.id("splash_screen_welcome_text"));

    SelenideElement progressBar = $(By.id("spash_screen_progress_bar"));

    public SplashScreen(){
        progressBar.waitUntil(visible, Timeout.APP_TO_LOAD);
        welcomeText.waitUntil(visible, Timeout.APP_TO_LOAD);
    }
}
