package screens;

import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;
import static com.codeborne.selenide.Selenide.back;
import static com.codeborne.selenide.Selenide.page;

import com.codeborne.selenide.SelenideElement;

import constants.Timeout;
import utils.Action;

import org.openqa.selenium.By;

public class Dish2Screen {

    private SelenideElement fieldDishName = $(By.id("dish_2_field_dish_name"));

    private SelenideElement fieldDishDescription = $(By.id("dish_2_field_dish_description"));

    SelenideElement btnSave(){
        return $(By.id("dish_2_btn_save"));
    }

    public Dish2Screen(){
        fieldDishName.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        fieldDishDescription.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        btnSave().waitUntil(visible, Timeout.SCREEN_TO_LOAD);
    }

    void inputData(String name, String description){
        fieldDishName.val(name);
        fieldDishDescription.val(description);
        Action.hideKeyboard();
    }

    Dish3Screen clickSaveBtn(){
        btnSave().click();
        return page(Dish3Screen.class);
    }

    public Dish4Screen backNavigation(){
        back();
        return page(Dish4Screen.class);
    }

}
