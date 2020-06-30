package screens;

import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;
import static com.codeborne.selenide.Selenide.back;
import static com.codeborne.selenide.Selenide.page;

import com.codeborne.selenide.SelenideElement;

import constants.Timeout;
import utils.Action;

import org.openqa.selenium.By;

public class Dish3Screen {

    SelenideElement textSuccessCreated = $(By.id("dish3_text1"));

    SelenideElement textSuccess = $(By.id("dish3_success_text"));

    SelenideElement btnSkip(){
        if(Action.getLocale().contains("ru")){
            return $(By.id("dish3_ru_btn_skip"));
        }else {
            return $(By.id("dish3_btn_skip"));
        }
    }

    SelenideElement btnAttach(){
        if(Action.getLocale().contains("ru")){
            return $(By.id("dish3_ru_btn_attach"));
        }else {
            return $(By.id("dish3_btn_attach"));
        }
    }

    public Dish3Screen(){
        SelenideElement iconSuccess = $(By.id("dish3_success_img"));
        iconSuccess.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        textSuccess.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        textSuccessCreated.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        btnAttach().waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        btnSkip().waitUntil(visible, Timeout.SCREEN_TO_LOAD);
    }

    Dish5Screen clickAttachBtn(){
        btnAttach().click();
        return page(Dish5Screen.class);
    }

    Dish4Screen clickSkipBtn(){
        btnSkip().click();
        return page(Dish4Screen.class);
    }

    public Dish4Screen backNavigation(){
        back();
        return page(Dish4Screen.class);
    }

}
