package screens;

import static com.codeborne.selenide.Condition.text;
import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;
import static com.codeborne.selenide.Selenide.$$;
import static com.codeborne.selenide.Selenide.$x;
import static com.codeborne.selenide.Selenide.back;
import static com.codeborne.selenide.Selenide.page;

import com.codeborne.selenide.ElementsCollection;
import com.codeborne.selenide.SelenideElement;

import constants.Timeout;

import org.openqa.selenium.By;

public class Ingredient1Screen {

    private SelenideElement fieldSearch = $(By.id("ingredient1_search_field"));

    private SelenideElement iconOpenSearch = $(By.id("ingredient1_search_icon"));

    ElementsCollection checkBox = $$(By.id("ingredient1_checkbox"));

    SelenideElement btnDelete = $(By.id("ingredient1_delete_button"));

    SelenideElement btnSelectAll = $(By.id("ingredient1_select_all_btn"));

    SelenideElement btnCancel = $(By.id("ingredient1_cancel_btn"));

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

    public Ingredient1Screen selectIngredientByName(String name){
        $x("//*[@id='ingredient1_checkbox' and (./preceding-sibling::* | ./following-sibling::*)[@text='"+name+"']]").click();

       //$x("//*[@id='ingredient1_checkbox' and (./preceding-sibling::* | ./following-sibling::*)[@text='"+name+"']]")
       //    .waitUntil(visible, Timeout.APP_TO_LOAD).click();
      //  $x("//*[@id='ingredient1_checkbox']//parent:://*[@class='android.widget.RelativeLayout' and ./*[@text='"+name+"']]").click();
       // ingredientNamesList().findBy(text(name)).parent().$(By.id("ingredient1_checkbox")).click();
        return this;
    }

    public Ingredient1Screen clickSelectAllBtn(){
        btnSelectAll.click();
        return this;
    }

    public Ingredient1Screen clickDeleteBtn(){
        btnDelete.click();
        return this;
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
