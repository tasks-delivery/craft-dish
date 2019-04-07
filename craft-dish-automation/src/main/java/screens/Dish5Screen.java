package screens;

import com.codeborne.selenide.SelenideElement;
import org.openqa.selenium.By;

import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;
import static com.codeborne.selenide.Selenide.back;
import static com.codeborne.selenide.Selenide.page;

public class Dish5Screen extends BaseScreen {

    private SelenideElement iconPhoto = $(By.id("dish5_photo_icon"));

    private SelenideElement iconUpload = $(By.id("dish5_share_icon"));

    private SelenideElement areaPreviewPhoto = $(By.id("dish5_icon_area"));

    public SelenideElement textPreviewPhoto(){
        return $(By.id("dish5_preview_text"));
    }

    public SelenideElement btnSave(){
        return $(By.id("dish5_btn_save"));
    }

    public Dish5Screen(){
        areaPreviewPhoto.waitUntil(visible, waitForLoadScreen());
        iconPhoto.waitUntil(visible, waitForLoadScreen());
        iconUpload.waitUntil(visible, waitForLoadScreen());
        textPreviewPhoto().waitUntil(visible, waitForLoadScreen());
        btnSave().waitUntil(visible, waitForLoadScreen());
    }

    public Dish4Screen clickSaveBtn(){
        btnSave().click();
        return page(Dish4Screen.class);
    }

    public Dish3Screen backNavigation(){
        back();
        return page(Dish3Screen.class);
    }

}
