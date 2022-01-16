using UnityEngine;
using Snake.Data;
using Snake.Utiles;
using UnityEngine.UI;

namespace Snake.UIController
{ 
    public class GamePanelController : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject gameSelectPanel;
        [SerializeField] private GameObject buyingPanel;
        [SerializeField] private GameObject settingPanel;
        [SerializeField] private GameObject adsPanel;
        [SerializeField] private GameObject endPanel;
        [SerializeField] private GameObject sharePanel;
        [SerializeField] private GameObject gamePanel;

        [Header("Circle Bars")]
        [SerializeField] private GameObject adsCircleBar;
        [SerializeField] private GameObject shareCircleBar;

        [Header("Game Data")]
        [SerializeField] private GameData gameData;

        [Header("Toggle")]
        [SerializeField] private Toggle toggleTR;
        [SerializeField] private Toggle toggleEN;

        private void Start()
        {
            setToggleLanguage();
            openMenuPanel();
        }

        public void openMenuPanel()
        {
            menuPanel.SetActive(true);
            adsPanel.SetActive(false);
            endPanel.SetActive(false);
            sharePanel.SetActive(false);
            gamePanel.SetActive(false);
            stopeGame();
        }
        public void openAdsPanel()
        {
            menuPanel.SetActive(false);
            adsPanel.SetActive(true);
            endPanel.SetActive(false);
            sharePanel.SetActive(false);
            gamePanel.SetActive(false);
            stopeGame();
        }
        public void openEndPanel()
        {
            menuPanel.SetActive(false);
            adsPanel.SetActive(false);
            endPanel.SetActive(true);
            sharePanel.SetActive(false);
            gamePanel.SetActive(false);
            stopeGame();
        }
        public void openSharePanel()
        {
            menuPanel.SetActive(true);
            adsPanel.SetActive(false);
            endPanel.SetActive(false);
            sharePanel.SetActive(true);
            gamePanel.SetActive(false);
        }

        public void closeSharePanel()
        {
            openMenuPanel();
            shareCircleBar.SetActive(false);
        }
        public void openGamePanel()
        {
            menuPanel.SetActive(false);
            adsPanel.SetActive(false);
            endPanel.SetActive(false);
            sharePanel.SetActive(false);
            gamePanel.SetActive(true);
            adsCircleBar.SetActive(false);
            resumeGame();
        }

        public void openGameSelectPanel()
        {
            menuPanel.SetActive(false);
            gameSelectPanel.SetActive(true);
        }

        public void closeGameSelectPanel()
        {
            menuPanel.SetActive(true);
            gameSelectPanel.SetActive(false);
        }

        public void openSettingPanel()
        {
            menuPanel.SetActive(false);
            settingPanel.SetActive(true);
        }

        public void closeSettingPanel()
        {
            menuPanel.SetActive(true);
            settingPanel.SetActive(false);
        }

        public void openBuyingPanel()
        {
            buyingPanel.SetActive(true);
        }

        public void closeBuyingPanel()
        {
            buyingPanel.SetActive(false);
        }

        public void openAdsCircleBar()
        {
            adsCircleBar.SetActive(true);
        }

        public void openShareCircleBar()
        {
            shareCircleBar.SetActive(true);
        }

        public void closeAdsCircleBar()
        {
            adsCircleBar.SetActive(false);
        }

        public void closeShareCircleBar()
        {
            shareCircleBar.SetActive(false);
        }

        public void stopeGame()
        {
            gameData.GameState = false;
        }

        public void resumeGame()
        {
            gameData.GameState = true;
        }

        private void setToggleLanguage()
        {
            if(RuntimeHelper.getLanguage() == Constants.TURKISH)
            {
                toggleTR.SetIsOnWithoutNotify(true);
                toggleEN.SetIsOnWithoutNotify(false);
            }
            else if (RuntimeHelper.getLanguage() == Constants.ENGLISH)
            {
                toggleTR.SetIsOnWithoutNotify(false);
                toggleEN.SetIsOnWithoutNotify(true);
            }
        }

        public void onClickToggleTR()
        {
            RuntimeHelper.setLanguage(Constants.TURKISH);
            setToggleLanguage();
        }

        public void onClickToggleEN()
        {
            RuntimeHelper.setLanguage(Constants.ENGLISH);
            setToggleLanguage();
        }

    }
}