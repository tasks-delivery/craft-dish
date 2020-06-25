package screens;

import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;
import static com.codeborne.selenide.Selenide.back;
import static com.codeborne.selenide.Selenide.page;

import com.codeborne.selenide.SelenideElement;

import constants.Timeout;

import org.openqa.selenium.By;

public class Dish6Screen {

    private SelenideElement editIcon = $(By.id("dish6_edit_icon"));
    private SelenideElement arrowBack = $(By.id("dish6_back_arrow"));
    SelenideElement dishPhoto = $(By.id("dish6_photo_icon"));
    private SelenideElement minusIcon = $(By.id("dish6_minus_icon"));
    private SelenideElement plusIcon = $(By.id("dish6_plus_icon"));
    SelenideElement dishDescription = $(By.id("dish6_dish_description_text"));
    SelenideElement dishName = $(By.id("dish6_dish_name_text"));

    public Dish6Screen(){
        editIcon.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        arrowBack.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        dishPhoto.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        minusIcon.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        plusIcon.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        dishDescription.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
        dishName.waitUntil(visible, Timeout.SCREEN_TO_LOAD);
    }

    public Ingredient1Screen addIngredient(){
        plusIcon.click();
        return page(Ingredient1Screen.class);
    }

    public Ingredient1Screen removeIngredient(){
        minusIcon.click();
        return page(Ingredient1Screen.class);
    }

    Dish4Screen clickBackArrow(){
        back();
        return page(Dish4Screen.class);
    }

    Dish4Screen clickAndroidBackBtn(){
        back();
        return page(Dish4Screen.class);
    }

    public Dish7Screen clickEditIcon(){
        editIcon.click();
        return page(Dish7Screen.class);
    }
}
