package config;

import models.Dish;

import java.util.UUID;

public class DataGenerator {

    public Dish dish(Dish dish){
        String randomName = dish.getName() + UUID.randomUUID().toString();
        String result = "";
        if(randomName.length() > 29){
            result = randomName.substring(0, 29);
        }else {
            result = randomName;
        }
        dish.setName(result);
        return dish;
    }

}
