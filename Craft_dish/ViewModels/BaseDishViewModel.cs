using Java.IO;

namespace Craft_dish.ViewModels
{
    public class BaseDishViewModel
    {

        public BaseDishViewModel()
        {

        }

        public static File FindDishPhoto(string photo_path)
        {
            if (photo_path != null && photo_path != "")
            {
                File imgFile = new File(photo_path);
                if (imgFile.Exists())
                {
                    return imgFile;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }

        }

    }

}