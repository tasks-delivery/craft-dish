package screens;

import com.codeborne.selenide.SelenideElement;
import org.openqa.selenium.By;

import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;
import static com.codeborne.selenide.Selenide.page;

public class Dish1Screen extends BaseScreen {

    SelenideElement btnIngredients(){
        return $(By.id("dish1_ingredients_btn"));
    }

    SelenideElement btnDishes(){
        return $(By.id("dish1_dishes_btn"));
    }

    SelenideElement linkGitHub(){
        return $(By.id("imageGithub"));
    }

    SelenideElement textSendFeedback(){
        return $(By.id("dish1_text_feedback"));
    }

    SelenideElement textContacts(){
        return $(By.id("dish1_text_contacts"));
    }

    public Dish1Screen(){
        btnIngredients().waitUntil(visible, waitForLoadScreen());
        linkGitHub().waitUntil(visible, waitForLoadScreen());
        btnDishes().waitUntil(visible, waitForLoadScreen());
        textContacts().waitUntil(visible, waitForLoadScreen());
        textSendFeedback().waitUntil(visible, waitForLoadScreen());
    }

    Dish4Screen clickDishesBtn(){
        btnDishes().click();
        return page(Dish4Screen.class);
    }

}
