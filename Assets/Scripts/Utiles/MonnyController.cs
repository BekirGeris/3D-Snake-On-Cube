using UnityEngine;
using TMPro;

public class MonnyController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI monnyTxt;

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    public void init()
    {
        monnyTxt.text = getMonny() + "";
    }

    public void setMonny(int monny)
    {
        PlayerPrefs.SetInt("Monny", monny);
    }

    public int getMonny()
    {
        return PlayerPrefs.GetInt("Monny", 0);
    }

    public void decreaseMonny(int decrease)
    {
        setMonny(getMonny() - decrease);
        init();
    }

    public void increaseMonny(int increase)
    {
        setMonny(getMonny() + increase);
        init();
    }

}
