package screens;

import config.DownloadService;
import org.testng.annotations.Test;

public class citesting {

    @Test
    public void core(){
        DownloadService downloadService = new DownloadService();
        downloadService.downloadApk();
    }

}
