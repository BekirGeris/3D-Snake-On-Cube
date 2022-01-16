using UnityEngine;

namespace Snake.Utiles
{
    public class RuntimeHelper
    {
        public static void setLanguage(string language)
        {
            PlayerPrefs.SetString("Language", language);
        }
        public static string getLanguage()
        {
            return PlayerPrefs.GetString("Language", "") == "" ? Application.systemLanguage.ToString() : PlayerPrefs.GetString("Language", "");
        }

        public static string selectStringByLanguage(string tr, string ing)
        {
            if(getLanguage() == Constants.TURKISH)
            {
                return tr;
            }
            else if(getLanguage() == Constants.ENGLISH)
            {
                return ing;
            }
            return ing;
        }

        public static void setMusicStatus(bool isOpen)
        {
            PlayerPrefs.SetInt("Music", isOpen == true ? 1 : 0);
        }

        public static void setSoundStatus(bool isOpen)
        {
            PlayerPrefs.SetInt("Sound", isOpen == true ? 1 : 0);
        }

        public static bool getMusicStatus()
        {
            return PlayerPrefs.GetInt("Music", 1) == 1 ? true : false;
        }

        public static bool getSoundStatus()
        {
            return PlayerPrefs.GetInt("Sound", 1) == 1 ? true : false;
        }

    }
}
