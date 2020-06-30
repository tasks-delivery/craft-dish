package screens;

import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;
import static com.codeborne.selenide.Selenide.back;
import static com.codeborne.selenide.Selenide.page;

import com.codeborne.selenide.SelenideElement;

import constants.Timeout;
import utils.DeviceApiUtil;

import org.openqa.selenium.By;

public class Ingredient2Screen {

    private SelenideElement fieldIngredientName = $(By.id("ingredient2_field_ingredient_name"));

    private SelenideElement fieldIngredientWeight = $(By.id("ingredient2_field_ingredient_weight"));

    SelenideElement btnSave = $(By.id("ingredient2_btn_save"));

    public Ingredient2Screen(){
        fieldIngredientName.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        fieldIngredientWeight.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        btnSave.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
    }

    Ingredient2Screen inputData(String name, String description){
        fieldIngredientName.val(name);
        fieldIngredientWeight.val(description);
        DeviceApiUtil.hideKeyboard();
        return this;
    }

    Ingredient1Screen clickSaveBtn(){
        btnSave.click();
        return page(Ingredient1Screen.class);
    }

    public Ingredient1Screen backNavigation(){
        back();
        return page(Ingredient1Screen.class);
    }
}
