package screens;

import com.codeborne.selenide.Condition;
import com.codeborne.selenide.SelenideElement;
import org.openqa.selenium.By;

import static com.codeborne.selenide.Selenide.$;

public class Dish1Screen extends BaseScreen {

    public SelenideElement btnIngredients(){
        return $(By.id("dish1_ingredients_btn"));
    }

    public SelenideElement btnDishes(){
        return $(By.id("dish1_dishes_btn"));
    }

    public SelenideElement linkGitHub(){
        return $(By.id("imageGithub"));
    }

    public SelenideElement textSendFeedback(){
        return $(By.id("dish1_text_feedback"));
    }

    public SelenideElement textContacts(){
        return $(By.id("dish1_text_contacts"));
    }

    public Dish1Screen(){
        btnIngredients().waitUntil(Condition.visible, waitForLoadScreen());
        linkGitHub().waitUntil(Condition.visible, waitForLoadScreen());
        btnDishes().waitUntil(Condition.visible, waitForLoadScreen());
        textContacts().waitUntil(Condition.visible, waitForLoadScreen());
        textSendFeedback().waitUntil(Condition.visible, waitForLoadScreen());
    }

}
