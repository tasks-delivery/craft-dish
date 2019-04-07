package screens;

import com.codeborne.selenide.SelenideElement;
import org.openqa.selenium.By;

import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;

public class Dish3Screen extends BaseScreen {

    private SelenideElement iconSuccess = $(By.id("dish3_success_img"));

    public Dish3Screen(){
        iconSuccess.waitUntil(visible, waitForLoadScreen());
    }

}
