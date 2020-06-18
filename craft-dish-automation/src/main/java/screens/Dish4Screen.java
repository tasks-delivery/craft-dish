package screens;

import com.codeborne.selenide.ElementsCollection;
import com.codeborne.selenide.SelenideElement;
import org.openqa.selenium.By;

import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.*;

public class Dish4Screen extends BaseScreen {

    private SelenideElement fieldSearch = $(By.id("dish4_search_field"));

    private SelenideElement iconOpenSearch = $(By.id("dish4_search_icon"));

    SelenideElement floatBtnPlus(){
        return $(By.id("fab"));
    }

    SelenideElement arrowBack(){
        return $(By.id("dish4_back_arrow"));
    }

    SelenideElement iconCloseSearch(){
        return $(By.id("dish4_close_search_icon"));
    }

    public Dish4Screen(){
        arrowBack().waitUntil(visible, waitForLoadScreen());
        iconOpenSearch.waitUntil(visible, waitForLoadScreen());
        floatBtnPlus().waitUntil(visible, waitForLoadScreen());
    }

    ElementsCollection dishNamesList(){
        return $$(By.id("dish4_dish_name"));
    }

    ElementsCollection dishDescriptionsList(){
        return $$(By.id("dish4_dish_description"));
    }

    Dish1Screen androidBackNavigation(){
        back();
        return page(Dish1Screen.class);
    }

    public Dish1Screen backNavigation(){
        arrowBack().click();
        return page(Dish1Screen.class);
    }

    void searchDish(String dishName){
        iconOpenSearch.click();
        fieldSearch.val(dishName);
    }

    Dish2Screen clickPlusBtn(){
        floatBtnPlus().click();
        return  page(Dish2Screen.class);
    }

}
