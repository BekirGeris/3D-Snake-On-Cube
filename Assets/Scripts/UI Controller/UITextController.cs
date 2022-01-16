using UnityEngine;
using Snake.Utiles;
using TMPro;
using UnityEngine.UIElements;

namespace Snake.UIController { 
    public class UITextController : MonoBehaviour
    {
        [Header("Button Text")]
        [SerializeField] private TextMeshProUGUI startBtn;
        [SerializeField] private TextMeshProUGUI sharePanelBtn;
        [SerializeField] private TextMeshProUGUI shareBtn;
        [SerializeField] private TextMeshProUGUI keepPlayingBtn;
        [SerializeField] private TextMeshProUGUI skipBtn;
        [SerializeField] private TextMeshProUGUI homePageBtn;
        [SerializeField] private TextMeshProUGUI againBtn;
        [SerializeField] private TextMeshProUGUI closeBtnFromSetting;
        [SerializeField] private TextMeshProUGUI closeBtnFromStore;
        [SerializeField] private TextMeshProUGUI buyBtn;

        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI sharePanelTxt;
        [SerializeField] private TextMeshProUGUI highScoreTxt;
        [SerializeField] private TextMeshProUGUI labelTextMusicTxt;
        [SerializeField] private TextMeshProUGUI labelTextSoundTxt;
        [SerializeField] private TextMeshProUGUI storeTitleTxt;
        [SerializeField] private TextMeshProUGUI priceTxt;

        [Header("Field Text")]
        [SerializeField] private TextMeshProUGUI shareNameHint;

        // Start is called before the first frame update
        void Start()
        {
            setUIStrings();
        }

        public void setUIStrings()
        {
            //Button texts
            startBtn.text = RuntimeHelper.selectStringByLanguage("Baþla", "Start");
            sharePanelBtn.text = RuntimeHelper.selectStringByLanguage("Rekoru Paylaþ", "Share High Score");
            shareBtn.text = RuntimeHelper.selectStringByLanguage("Paylaþ", "Share");
            keepPlayingBtn.text = RuntimeHelper.selectStringByLanguage("Devam ET", "Keep Playing");
            skipBtn.text = RuntimeHelper.selectStringByLanguage("Geç", "Skip");
            homePageBtn.text = RuntimeHelper.selectStringByLanguage("Ana Sayfa", "Home Page");
            againBtn.text = RuntimeHelper.selectStringByLanguage("Tekrar", "Again");
            closeBtnFromSetting.text = RuntimeHelper.selectStringByLanguage("Kapat", "Close");
            closeBtnFromStore.text = RuntimeHelper.selectStringByLanguage("Kapat", "Close");
            buyBtn.text = RuntimeHelper.selectStringByLanguage("Al", "Buy");

            //Texts
            sharePanelTxt.text = RuntimeHelper.selectStringByLanguage("Rekoru Paylaþ", "Share High Score");
            highScoreTxt.text = RuntimeHelper.selectStringByLanguage("Rekor: ", "High Score: ");
            labelTextMusicTxt.text = RuntimeHelper.selectStringByLanguage("Müzik", "Music");
            labelTextSoundTxt.text = RuntimeHelper.selectStringByLanguage("Sesler", "Sound");
            storeTitleTxt.text = RuntimeHelper.selectStringByLanguage("Karakterini Seç", "Choose Your Character");
            priceTxt.text = RuntimeHelper.selectStringByLanguage("Fiyat", "Price");

            //Field Texts
            shareNameHint.text = RuntimeHelper.selectStringByLanguage("Ad giriniz...", "Enter Name...");
        }

        public void setLanguageTURKISH()
        {
            RuntimeHelper.setLanguage(Constants.TURKISH);
        }

        public void setLanguageENGLISH()
        {
            RuntimeHelper.setLanguage(Constants.ENGLISH);
        }

    }
}