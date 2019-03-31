package screens;

import com.codeborne.selenide.Condition;
import com.codeborne.selenide.SelenideElement;
import org.openqa.selenium.By;

import static com.codeborne.selenide.Selenide.$;

public class SplashScreen extends BaseScreen {

    public SplashScreen(){
        progressBar().waitUntil(Condition.visible, waitForLoadScreen());
        welcomeText().waitUntil(Condition.visible, waitForLoadScreen());
    }

    public SelenideElement welcomeText(){
        return $(By.id("splash_screen_welcome_text"));
    }

    public SelenideElement progressBar(){
        return $(By.id("spash_screen_progress_bar"));
    }

}
