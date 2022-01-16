using UnityEngine;
using Snake.Data;
using UnityEngine.Advertisements;
using Snake.Toast;
using Snake.Utiles;
using Snake.UIController;

namespace Snake.Reklam
{
    public class Reklam : MonoBehaviour, IUnityAdsListener
    {
        private string gameID = "4555769";
        private string devmEtReklam = "Rewarded_Android";
        private string banner = "Banner_Android";
        private bool testMode = false;
        private bool bannerActive = false;
        private bool flag;

        [SerializeField] private GameData gameData;
        [SerializeField] private GamePanelController gamePanelController;
        [SerializeField] private Timer timer;
        [SerializeField] private ShowToast showToast;

        void Start()
        {
            Advertisement.AddListener(this);
            Advertisement.Initialize(gameID, testMode);

            flag = true;
            timer.clearTimer();
        }

        private void Update()
        {
            if (!bannerActive)
            {
                bannerShow();
            }

            if(timer.getTime() > 3000 && flag)
            {
                timer.clearTimer();
                gamePanelController.openEndPanel();
                flag = false;
                showToast.MyShowToastMethod(RuntimeHelper.selectStringByLanguage("Reklam Gösterilemedi!", "Ad Failed to Show!"));
            }

            if(timer.getTime() < 1000 && timer.getTime() > 0)
            {
                flag = true;
                odulluReklamShow();
            }
        }

        public void odulluReklamShow()
        {
            if (Advertisement.IsReady(devmEtReklam))
            {
                timer.clearTimer();
                Advertisement.Show(devmEtReklam);
            }
        }

        public void bannerShow()
        {
            if (Advertisement.IsReady(banner))
            {
                Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
                Advertisement.Banner.Show(banner);
                bannerActive = true;
            }
        }

        public void bannerHide()
        {
            Advertisement.Banner.Hide();
        }

        public void OnUnityAdsReady(string placementId)
        {

        }

        public void OnUnityAdsDidError(string message)
        {

        }

        public void OnUnityAdsDidStart(string placementId)
        {

        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            if (placementId == devmEtReklam)
            {
                if (showResult == ShowResult.Finished)
                {
                    Debug.Log("AD " + placementId + " COMPLETE");
                    //reklam izlendimi 1 ise izlendi, 0 ise izlenmedi
                    PlayerPrefs.SetInt("reklam izlendimi", 1);
                    gamePanelController.openGamePanel();
                    gameData.GameState = true;
                }
                else if (showResult == ShowResult.Skipped)
                {
                    Debug.Log("Skipped");
                }
                else if (showResult == ShowResult.Failed)
                {
                    Debug.Log("Failed");
                }
                timer.clearTimer();
            }
        }
    }
}