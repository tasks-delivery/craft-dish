package screens;

import com.codeborne.selenide.SelenideElement;
import org.openqa.selenium.By;

import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.*;

public class Dish2Screen extends BaseScreen{

    private SelenideElement fieldDishName = $(By.id("dish_2_field_dish_name"));

    private SelenideElement fieldDishDescription = $(By.id("dish_2_field_dish_description"));

    SelenideElement btnSave(){
        return $(By.id("dish_2_btn_save"));
    }

    public Dish2Screen(){
        fieldDishName.waitUntil(visible, waitForLoadScreen());
        fieldDishDescription.waitUntil(visible, waitForLoadScreen());
        btnSave().waitUntil(visible, waitForLoadScreen());
    }

    void inputData(String name, String description){
        fieldDishName.val(name);
        fieldDishDescription.val(description);
        driverProvider().hideKeyboard();
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
