package config;

import io.restassured.http.ContentType;
import io.restassured.response.Response;

import static io.restassured.RestAssured.given;

public class DownloadService {

    private String appveyorApk = "http://ci.appveyor.com/api/projects/ordeh/craft-dish/artifacts/Craft_dish/bin/Release/Craft_dish.Craft_dish-Signed.apk";

    public void downloadApk(){
        Response response = given()

                .get(appveyorApk);

        System.out.println(response.getBody().asString());

    }

}
