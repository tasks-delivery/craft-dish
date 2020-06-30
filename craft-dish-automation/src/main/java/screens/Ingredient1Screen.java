package screens;

import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;
import static com.codeborne.selenide.Selenide.$$;
import static com.codeborne.selenide.Selenide.$x;
import static com.codeborne.selenide.Selenide.back;
import static com.codeborne.selenide.Selenide.page;

import java.util.List;

import com.codeborne.selenide.ElementsCollection;
import com.codeborne.selenide.SelenideElement;

import constants.Timeout;
import models.Ingredient;

import org.openqa.selenium.By;

public class Ingredient1Screen {

    private SelenideElement fieldSearch = $(By.id("ingredient1_search_field"));

    private SelenideElement iconOpenSearch = $(By.id("ingredient1_search_icon"));

    private SelenideElement btnDelete = $(By.id("ingredient1_delete_button"));

    private SelenideElement btnSelectAll = $(By.id("ingredient1_select_all_btn"));

    private SelenideElement btnCancel = $(By.id("ingredient1_cancel_btn"));

    private SelenideElement btnAdd = $(By.id("ingredient1_add_button"));

    SelenideElement floatBtnPlus(){
        return $(By.id("fab"));
    }

    ElementsCollection ingredientWeightList(){
        return $$(By.id("ingredient1_weight"));
    }

    ElementsCollection ingredientNamesList(){
        return $$(By.id("ingredient1_name"));
    }

    SelenideElement arrowBack(){
        return $(By.id("ingredient1_back_arrow"));
    }

    SelenideElement iconCloseSearch(){
        return $(By.id("ingredient1_close_search_icon"));
    }

    public Ingredient1Screen(){
        arrowBack().waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        iconOpenSearch.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
    }

    Ingredient1Screen selectIngredientByName(List<Ingredient> ingredients){
        for (Ingredient ingredient : ingredients){
            $x("//*[@text='"+ingredient.getName()+"']//..//android.widget.CheckBox").click();
        }
        return this;
    }

    Ingredient1Screen clickSelectAllBtn(){
        btnSelectAll.click();
        return this;
    }

    Ingredient1Screen clickDeleteBtn(){
        btnDelete.click();
        return this;
    }

    Dish6Screen clickAddBtn(){
        btnAdd.click();
        return page(Dish6Screen.class);
    }

    public Ingredient1Screen clickCancelBtn(){
        btnCancel.click();
        return this;
    }

    Ingredient2Screen clickPlusBtn(){
        floatBtnPlus().click();
        return page(Ingredient2Screen.class);
    }

    void searchIngredient(String ingredientName){
        iconOpenSearch.click();
        fieldSearch.val(ingredientName);
    }

    Dish1Screen androidBackNavigation(){
        back();
        return page(Dish1Screen.class);
    }

    public Dish1Screen backNavigation(){
        arrowBack().click();
        return page(Dish1Screen.class);
    }
}
