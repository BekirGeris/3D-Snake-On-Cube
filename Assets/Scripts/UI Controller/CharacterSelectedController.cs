using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Snake.UIController;
using Snake.Toast;
using Snake.Utiles;

public class CharacterSelectedController : MonoBehaviour
{

    [SerializeField] private GamePanelController gamePanelController;

    [SerializeField] private List<GameObject> chactarImages;
    [SerializeField] private List<TextMeshProUGUI> buys;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private GameObject selectedEffect;

    private int selectedImageNoForSale = 1;

    // Start is called before the first frame update
    void Start()
    {
        init();
        buying();
    }

    public void init()
    {
        for (var i = 1; i <= 10; i++)
        {
            if (i == PlayerPrefs.GetInt(i.ToString(), -1))
            {
                buys[i - 1].text = RuntimeHelper.selectStringByLanguage("Satýn Alýndý", "Purchased");
            }
            else
            {
                buys[i - 1].text = RuntimeHelper.selectStringByLanguage("Satýn Al ", "Buy ") + i * 100;
            }

            if (i == PlayerPrefs.GetInt("selectImage", -1))
            {
                selectedEffect.transform.position = chactarImages[i - 1].transform.position;
            }
        }
    }

    public void selectImage(int imageNo)
    {
        for (var i = 1; i <= 10; i++)
        {
            if (imageNo == PlayerPrefs.GetInt(i.ToString(), -1))
            {
                PlayerPrefs.SetInt("selectImage", imageNo);
                Debug.Log("selectImage" + PlayerPrefs.GetInt("selectImage", -1));
                init();
                return;
            }
        }
        selectedImageNoForSale = imageNo;
        price.text = imageNo * 100 + "";
        gamePanelController.openBuyingPanel();
    }

    public void buying()
    {
        PlayerPrefs.SetInt(selectedImageNoForSale.ToString(), selectedImageNoForSale);
        PlayerPrefs.SetInt("selectImage", selectedImageNoForSale);
        Debug.Log("selectImage" + PlayerPrefs.GetInt("selectImage", -1));
        init();
    }
}
