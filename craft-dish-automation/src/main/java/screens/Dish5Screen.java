package screens;

import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;
import static com.codeborne.selenide.Selenide.back;
import static com.codeborne.selenide.Selenide.page;

import com.codeborne.selenide.SelenideElement;

import constants.Timeout;

import org.openqa.selenium.By;

public class Dish5Screen {

    SelenideElement textPreviewPhoto = $(By.id("dish5_preview_text"));

    SelenideElement btnSave = $(By.id("dish5_btn_save"));

    public Dish5Screen(){
        SelenideElement areaPreviewPhoto = $(By.id("dish5_icon_area"));
        areaPreviewPhoto.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        SelenideElement iconPhoto = $(By.id("dish5_photo_icon"));
        iconPhoto.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        SelenideElement iconUpload = $(By.id("dish5_share_icon"));
        iconUpload.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        textPreviewPhoto.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        btnSave.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
    }

    public Dish4Screen clickSaveBtn(){
        btnSave.click();
        return page(Dish4Screen.class);
    }

    public Dish3Screen backNavigation(){
        back();
        return page(Dish3Screen.class);
    }

}
