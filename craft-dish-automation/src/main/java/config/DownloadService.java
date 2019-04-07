package config;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStream;

import static io.restassured.RestAssured.given;

public class DownloadService {

    private static final Logger log = LogManager.getLogger(DownloadService.class.getName());

    private String appveyorApk = "http://ci.appveyor.com/api/projects/ordeh/craft-dish/artifacts/Craft_dish/bin/Release/Craft_dish.Craft_dish-Signed.apk";

    public void downloadApk() throws IOException {
        File outputApkFile = new File("Craft_dish.Craft_dish-Signed.apk");
        if (!outputApkFile.exists()) {
            log.info("Apk does not exist");
            byte[] response = given()
                    .get(appveyorApk).asByteArray();
            OutputStream outStream = new FileOutputStream(outputApkFile);
            outStream.write(response);
            outStream.close();
        }
        checkApkFile(outputApkFile);
    }

    private void checkApkFile(File outputApkFile){
        if (!outputApkFile.exists()) {
            log.info("Apk download completed successfully");
        }else {
            log.info("Apk download failed");
        }
    }

}
