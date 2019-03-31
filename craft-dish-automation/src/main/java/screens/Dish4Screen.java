package screens;

import com.codeborne.selenide.SelenideElement;
import org.openqa.selenium.By;

import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;

public class Dish4Screen extends BaseScreen {

    private SelenideElement fieldSearch = $(By.id("dish4_search_field"));

    private SelenideElement iconOpenSearch = $(By.id("dish4_search_icon"));

    public SelenideElement floadBtnPlus(){
        return $(By.id("fab"));
    }

    public SelenideElement arrowBack(){
        return $(By.id("dish4_back_arrow"));
    }

    public SelenideElement iconCloseSearch(){
        return $(By.id("dish4_close_search_icon"));
    }

    public Dish4Screen(){
        arrowBack().waitUntil(visible, waitForLoadScreen());
        iconOpenSearch.waitUntil(visible, waitForLoadScreen());
        floadBtnPlus().waitUntil(visible, waitForLoadScreen());
    }

    public void searchDish(String dishName){
        iconOpenSearch.click();
        fieldSearch.val(dishName);
    }

}
