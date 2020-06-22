package screens;

import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;
import static com.codeborne.selenide.Selenide.$$;
import static com.codeborne.selenide.Selenide.back;
import static com.codeborne.selenide.Selenide.page;

import com.codeborne.selenide.ElementsCollection;
import com.codeborne.selenide.SelenideElement;

import constants.Timeout;

import org.openqa.selenium.By;

public class Ingredient1Screen {

    private SelenideElement fieldSearch = $(By.id("ingredient1_search_field"));

    private SelenideElement iconOpenSearch = $(By.id("ingredient1_search_icon"));

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
        floatBtnPlus().waitUntil(visible, Timeout.SCREEN_TO_LOAD);
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
