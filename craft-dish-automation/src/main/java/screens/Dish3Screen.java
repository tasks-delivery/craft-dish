package screens;

import com.codeborne.selenide.SelenideElement;
import org.openqa.selenium.By;

import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;
import static com.codeborne.selenide.Selenide.back;
import static com.codeborne.selenide.Selenide.page;

public class Dish3Screen extends BaseScreen {

    SelenideElement textSuccessCreated(){
        return $(By.id("dish3_text1"));
    }

    SelenideElement textSuccess(){
        return $(By.id("dish3_success_text"));
    }

    SelenideElement btnSkip(){
        if(driverProvider().getCapabilities().getCapability("locale").toString().contains("ru")){
            return $(By.id("dish3_ru_btn_skip"));
        }else {
            return $(By.id("dish3_btn_skip"));
        }
    }

    SelenideElement btnAttach(){
        if(driverProvider().getCapabilities().getCapability("locale").toString().contains("ru")){
            return $(By.id("dish3_ru_btn_attach"));
        }else {
            return $(By.id("dish3_btn_attach"));
        }
    }

    public Dish3Screen(){
        SelenideElement iconSuccess = $(By.id("dish3_success_img"));
        iconSuccess.waitUntil(visible, waitForLoadScreen());
        textSuccess().waitUntil(visible, waitForLoadScreen());
        textSuccessCreated().waitUntil(visible, waitForLoadScreen());
        btnAttach().waitUntil(visible, waitForLoadScreen());
        btnSkip().waitUntil(visible, waitForLoadScreen());
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
