package screens;

import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;
import static com.codeborne.selenide.Selenide.page;

import com.codeborne.selenide.SelenideElement;

import constants.Timeout;

import org.openqa.selenium.By;

public class Dish1Screen {

    SelenideElement btnIngredients = $(By.id("dish1_ingredients_btn"));

    SelenideElement btnDishes = $(By.id("dish1_dishes_btn"));

    SelenideElement linkGitHub = $(By.id("imageGithub"));

    SelenideElement textSendFeedback = $(By.id("dish1_text_feedback"));

    SelenideElement textContacts = $(By.id("dish1_text_contacts"));

    public Dish1Screen(){
        btnIngredients.waitUntil(visible, Timeout.APP_TO_LOAD);
        linkGitHub.waitUntil(visible, Timeout.APP_TO_LOAD);
        btnDishes.waitUntil(visible, Timeout.APP_TO_LOAD);
        textContacts.waitUntil(visible, Timeout.APP_TO_LOAD);
        textSendFeedback.waitUntil(visible, Timeout.APP_TO_LOAD);
    }

    Ingredient1Screen clickIngredientsBtn(){
        btnIngredients.click();
        return page(Ingredient1Screen.class);
    }

    Dish4Screen clickDishesBtn(){
        btnDishes.click();
        return page(Dish4Screen.class);
    }

}
