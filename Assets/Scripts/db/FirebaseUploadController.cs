using Firebase.Extensions;
using Firebase.Database;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Snake.Toast;
using Snake.Data;
using Snake.Utiles;
using Snake.UIController;
using System;

public class FirebaseUploadController : MonoBehaviour
{
    List<HighScore> data;
    //FirebaseFirestore db;
    DatabaseReference reference;

    [SerializeField] private TextMeshProUGUI shareNameEditText;
    [SerializeField] private GameData gameData;
    [SerializeField] private GamePanelController gamePanelController;
    [SerializeField] private ShowToast showToast;
    [SerializeField] private Timer timer;
    [SerializeField] private FirebaseDownloadController firebaseDownloadController;

    // Start is called before the first frame update
    void Start()
    {
        data = new List<HighScore>();

        reference = FirebaseDatabase.DefaultInstance.RootReference;
     
        //db = FirebaseFirestore.DefaultInstance;

    }

    public void Update()
    {
        if(timer.getTime() >= 5000)
        {
            timer.clearTimer();
            gamePanelController.closeSharePanel();
            showToast.MyShowToastMethod(RuntimeHelper.selectStringByLanguage("Rekor Paylaþýlamadý!", "High Score Not Shared!"));
        }
    }

    public void addHighScore()
    {
        string highScoreName = shareNameEditText.text;
        if (highScoreName.Length <= 1)
        {
            showToast.MyShowToastMethod(RuntimeHelper.selectStringByLanguage("Ýsim boþ olamaz!", "Name cannot be empty!"));
        }
        else if(highScoreName.Length > 7)
        {
            showToast.MyShowToastMethod(RuntimeHelper.selectStringByLanguage("Ad 6 karakterden uzun olamaz!", "The name cannot be longer than 6 characters"));
        }
        else
        {
            timer.StartTimer();
            gamePanelController.openShareCircleBar();

            shareHigScore();
        }
    }

    public void shareHigScore()
    {
        if (PlayerPrefs.GetString("UUID", "null") == "null")
        {
            Guid myuuid = Guid.NewGuid();
            PlayerPrefs.SetString("UUID", myuuid.ToString());
        }
        string highScoreName = shareNameEditText.text.ToString();
        int highScore = gameData.HighScore;
        string uuid = PlayerPrefs.GetString("UUID", "null");
        HighScore hs = new HighScore(uuid, highScoreName, highScore);
        string json = JsonUtility.ToJson(hs);
        isHgNameOkay(uuid, highScoreName, 
            () => {

                reference.Child("users").Child(uuid).SetRawJsonValueAsync(json).ContinueWithOnMainThread(task => {
                    showToast.MyShowToastMethod(RuntimeHelper.selectStringByLanguage("Rekor Paylaþýldý!", "High Score Shared!"));
                    gamePanelController.closeSharePanel();
                    PlayerPrefs.SetInt("highScoreIsCurrent", 0); //hg güncel
                    timer.clearTimer();
                    firebaseDownloadController.loadData();
                });

            },
            () => {

                showToast.MyShowToastMethod(RuntimeHelper.selectStringByLanguage("Hata! Ad uygun deðil.", "Error! Name is not available."));
                gamePanelController.closeShareCircleBar();
                timer.clearTimer();
            });
    }

    public void isHgNameOkay(string uuid, string highScoreName, Action onSuccess, Action onFailure)
    {
        FirebaseDatabase.DefaultInstance
            .GetReference("users")
            .GetValueAsync()
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.Log("IsFaulted");
                }
                else if (task.IsCompleted)
                {
                    bool flag = false;
                    bool isHaveUUID = false;
                    bool isHaveName = false;
                    data.Clear();
                    DataSnapshot snapshot = task.Result;

                    foreach (var dataSnapshot in snapshot.Children)
                    {
                        data.Add(new HighScore(dataSnapshot.Child("uuid").Value.ToString(), 
                            dataSnapshot.Child("highScoreName").Value.ToString(), 
                            double.Parse(dataSnapshot.Child("highScore").Value.ToString())));
                    }

                    foreach (var hg in data)
                    {
                        if (uuid.Equals(hg.uuid))
                        {
                            isHaveUUID = true;
                        }

                        if (highScoreName == hg.highScoreName)
                        {
                            isHaveName = true;
                        }

                        if (uuid == hg.uuid && highScoreName == hg.highScoreName)
                        {
                            flag = true;
                        }
                    }

                    if (isHaveUUID)
                    {
                        if (!isHaveName)
                        {
                            flag = true;
                            deleteOldHighScore(uuid);
                        }
                    }

                    if (isHaveUUID == false && isHaveName == false)
                    {
                        flag = true;
                    }

                    if (flag)
                    {
                        onSuccess();
                    }
                    else
                    {
                        onFailure();
                    }
                }
            });
    }

    private void deleteOldHighScore(string uuid)
    {
        Debug.Log(uuid);
        reference.Child("users").Child(uuid).RemoveValueAsync();
    }
}
