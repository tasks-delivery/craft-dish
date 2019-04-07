package screens;

import com.codeborne.selenide.SelenideElement;
import org.openqa.selenium.By;

import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;

public class Dish5Screen extends BaseScreen {

    private SelenideElement areaPreviewPhoto = $(By.id("dish5_preview_container"));

    public Dish5Screen(){
        areaPreviewPhoto.waitUntil(visible, waitForLoadScreen());
    }

}
