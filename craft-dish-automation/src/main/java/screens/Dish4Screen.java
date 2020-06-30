package screens;

import static com.codeborne.selenide.Condition.text;
import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;
import static com.codeborne.selenide.Selenide.$$;
import static com.codeborne.selenide.Selenide.back;
import static com.codeborne.selenide.Selenide.page;

import com.codeborne.selenide.ElementsCollection;
import com.codeborne.selenide.SelenideElement;

import constants.Timeout;

import org.openqa.selenium.By;

public class Dish4Screen {

    private SelenideElement fieldSearch = $(By.id("dish4_search_field"));

    private SelenideElement iconOpenSearch = $(By.id("dish4_search_icon"));

    SelenideElement floatBtnPlus = $(By.id("fab"));

    SelenideElement arrowBack = $(By.id("dish4_back_arrow"));

    SelenideElement iconCloseSearch = $(By.id("dish4_close_search_icon"));

    public Dish4Screen(){
        arrowBack.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        iconOpenSearch.waitUntil(visible,Timeout.SCREEN_TO_LOAD);
        floatBtnPlus.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
    }

    ElementsCollection dishNamesList(){
        return $$(By.id("dish4_dish_name"));
    }

    Dish6Screen openDishByName(String name){
        dishNamesList().findBy(text(name)).click();
        return page(Dish6Screen.class);
    }

    ElementsCollection dishDescriptionsList(){
        return $$(By.id("dish4_dish_description"));
    }

    Dish1Screen androidBackNavigation(){
        back();
        return page(Dish1Screen.class);
    }

    public Dish1Screen backNavigation(){
        arrowBack.click();
        return page(Dish1Screen.class);
    }

    Dish4Screen searchDish(String dishName){
        iconOpenSearch.click();
        fieldSearch.val(dishName);
        return this;
    }

    Dish2Screen clickPlusBtn(){
        floatBtnPlus.click();
        return  page(Dish2Screen.class);
    }

}
