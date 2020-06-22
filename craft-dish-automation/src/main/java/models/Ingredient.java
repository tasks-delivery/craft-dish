package models;

import lombok.AllArgsConstructor;
import lombok.Data;

@Data
@AllArgsConstructor
public class Ingredient {

    private String name;

    private String weight;

    private String weightUnit;

    public Ingredient(String name, String weight){
        this.name = name;
        this.weight = weight;
    }
}
