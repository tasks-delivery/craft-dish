package screens;

import static com.codeborne.selenide.Condition.text;
import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.closeWebDriver;
import static com.codeborne.selenide.Selenide.page;
import static org.testng.Assert.*;

import java.net.MalformedURLException;

import driver.DriverActions;
import utils.Action;

import org.openqa.selenium.ScreenOrientation;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

public class Ingredient2ScreenTest extends BaseTest implements DriverActions {

    @Test
    public void createIngredient(){
        Ingredient2Screen ingredient2Screen = page(Dish1Screen.class).clickIngredientsBtn()
            .clickPlusBtn().inputData("test name", "test descr");
        ingredient2Screen.btnSave.shouldHave(text(getText("save")));
        ingredient2Screen.clickSaveBtn();
    }

    @Test
    public void ingredientNameCannotBeEmpty() {
        Ingredient2Screen ingredient2Screen = page(Dish1Screen.class).clickIngredientsBtn().clickPlusBtn();
        ingredient2Screen.btnSave.click();
        ingredient2Screen.btnSave.shouldBe(visible);
    }

    @Test
    public void ingredientNameCannotBeContainsOnlySpaces(){
        Ingredient2Screen ingredient2Screen = page(Dish1Screen.class).clickIngredientsBtn()
            .clickPlusBtn().inputData("                              ", "");
        ingredient2Screen.btnSave.click();
        ingredient2Screen.btnSave.shouldBe(visible);
    }

    @Test
    public void landscapeMode(){
        page(Dish1Screen.class).clickIngredientsBtn().clickPlusBtn();
        assertEquals(Action.changeRotate(ScreenOrientation.LANDSCAPE), ScreenOrientation.PORTRAIT);
    }

    @Test
    public void backNavigation(){
        page(Dish1Screen.class).clickIngredientsBtn().clickPlusBtn()
            .backNavigation().floatBtnPlus().shouldBe(visible);
    }

    @BeforeMethod
    @Override
    public void setUpDriver() throws MalformedURLException {
        setUp();
    }

    @AfterMethod
    @Override
    public void closeDriver() {
        closeWebDriver();
    }

}