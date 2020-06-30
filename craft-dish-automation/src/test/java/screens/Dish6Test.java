package screens;

import static com.codeborne.selenide.Condition.attribute;
import static com.codeborne.selenide.Condition.text;
import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.closeWebDriver;
import static com.codeborne.selenide.Selenide.page;
import static java.util.Arrays.asList;
import static org.assertj.core.api.Java6Assertions.assertThat;
import static org.testng.Assert.assertEquals;

import java.net.MalformedURLException;
import java.util.Collections;
import java.util.List;

import driver.DriverActions;
import models.Dish;
import models.Ingredient;
import utils.DeviceApiUtil;
import utils.RandomUtil;

import org.openqa.selenium.ScreenOrientation;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

public class Dish6Test extends BaseTest implements DriverActions {

    private Dish dish = new Dish("testName" + RandomUtil.getRandomStringWith(10), "testDescr");
    private Ingredient ingredient1 = new Ingredient("testName" + RandomUtil.getRandomStringWith(10), "213");
    private Ingredient ingredient2 = new Ingredient("testName" + RandomUtil.getRandomStringWith(10), "213");

    @Test(description = "if clickable = true, Dish have not photo")
    public void dishDefaultPhoto(){
        Dish6Screen dish6Screen = createDish().clickDishesBtn().openDishByName(dish.getName());
        dish6Screen.dishDescription.shouldHave(text(dish.getDescription()));
        dish6Screen.dishName.shouldHave(text(dish.getName()));
        dish6Screen.dishPhoto.shouldNotHave(attribute("clickable", "true"));
    }

    @Test
    public void navigateToDish7ByEditIcon(){
        Dish7Screen dish7Screen = createDish().clickDishesBtn().openDishByName(dish.getName()).clickEditIcon();
        assertThat(dish7Screen).isInstanceOf(Dish7Screen.class);
    }

    @Test
    public void removeAllIngredientsFromDish(){
        createDish();
        createIngredient(ingredient1);
        createIngredient(ingredient2);
        Dish6Screen dish6Screen = addIngredientToDish(asList(ingredient2, ingredient1), dish)
            .clickDishesBtn().openDishByName(dish.getName())
            .removeIngredient()
            .selectIngredientByName(Collections.singletonList(ingredient1))
            .clickSelectAllBtn().clickDeleteBtn()
            .backNavigation()
            .clickDishesBtn()
            .openDishByName(dish.getName());
        dish6Screen.getIngredientByName(ingredient1.getName()).shouldNotBe(visible);
        dish6Screen.getIngredientByName(ingredient2.getName()).shouldNotBe(visible);
    }

    @Test
    public void removeOneIngredientFromDish(){
        createDish();
        createIngredient(ingredient1);
        Dish6Screen dish6Screen = addIngredientToDish(Collections.singletonList(ingredient1), dish)
            .clickDishesBtn().openDishByName(dish.getName())
            .removeIngredient()
            .selectIngredientByName(Collections.singletonList(ingredient1))
            .clickDeleteBtn()
            .backNavigation()
            .clickDishesBtn()
            .openDishByName(dish.getName());
        dish6Screen.getIngredientByName(ingredient1.getName()).shouldNotBe(visible);
    }

    @Test
    public void addIngredientToDish(){
        createDish();
        Dish6Screen dish6Screen = createIngredient(ingredient1).clickDishesBtn()
            .openDishByName(dish.getName()).addIngredient()
            .selectIngredientByName(Collections.singletonList(ingredient1)).clickAddBtn();
        dish6Screen.getIngredientByName(ingredient1.getName()).shouldBe(visible);
    }

    @Test
    public void backNavigationByArrow(){
        Object dish4Screen = createDish().clickDishesBtn()
            .openDishByName(dish.getName()).clickBackArrow();
        assertThat(dish4Screen).isInstanceOf(Dish4Screen.class);
    }

    @Test
    public void backNavigationByAndroidBtn(){
        Object dish4Screen = createDish().clickDishesBtn()
            .openDishByName(dish.getName()).clickAndroidBackBtn();
        assertThat(dish4Screen).isInstanceOf(Dish4Screen.class);
    }

    @Test
    public void landscapeMode(){
        createDish().clickDishesBtn().openDishByName(dish.getName());
        assertEquals(DeviceApiUtil.changeRotate(ScreenOrientation.LANDSCAPE), ScreenOrientation.PORTRAIT);
    }

    private Dish1Screen createDish(){
        return page(Dish1Screen.class).clickDishesBtn().clickPlusBtn()
            .inputData(dish.getName(), dish.getDescription()).clickSaveBtn().clickSkipBtn().backNavigation();
    }

    private Dish1Screen createIngredient(Ingredient ingredient){
        return new Dish1Screen().clickIngredientsBtn().clickPlusBtn()
            .inputData(ingredient.getName(), ingredient.getWeight()).clickSaveBtn().androidBackNavigation();
    }

    private Dish1Screen addIngredientToDish(List<Ingredient> ingredients, Dish dish){
        return new Dish1Screen().clickDishesBtn().openDishByName(dish.getName()).addIngredient()
            .selectIngredientByName(ingredients).clickAddBtn().clickAndroidBackBtn().backNavigation();
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