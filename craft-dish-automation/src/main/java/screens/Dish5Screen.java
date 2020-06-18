package screens;

import com.codeborne.selenide.SelenideElement;
import org.openqa.selenium.By;

import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;
import static com.codeborne.selenide.Selenide.back;
import static com.codeborne.selenide.Selenide.page;

public class Dish5Screen extends BaseScreen {

    SelenideElement textPreviewPhoto(){
        return $(By.id("dish5_preview_text"));
    }

    SelenideElement btnSave(){
        return $(By.id("dish5_btn_save"));
    }

    public Dish5Screen(){
        SelenideElement areaPreviewPhoto = $(By.id("dish5_icon_area"));
        areaPreviewPhoto.waitUntil(visible, waitForLoadScreen());
        SelenideElement iconPhoto = $(By.id("dish5_photo_icon"));
        iconPhoto.waitUntil(visible, waitForLoadScreen());
        SelenideElement iconUpload = $(By.id("dish5_share_icon"));
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
