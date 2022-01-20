using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YonBtnController : MonoBehaviour
{
    public Sprite LeftUpSprite;
    public Sprite RightUpSprite;
    public Sprite LeftDownSprite;
    public Sprite RightDownSprite;

    public Image RightImage;
    public Image LeftImage;

    public bool rigtFlag = false;
    public bool leftFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        LeftImage.sprite = LeftUpSprite;
        RightImage.sprite = RightUpSprite;
    }

    public void leftDown()
    {
        LeftImage.sprite = LeftDownSprite;
    }

    public void rightDown()
    {
        RightImage.sprite = RightDownSprite;
    }

    public void leftUp()
    {
        LeftImage.sprite = LeftUpSprite;
    }

    public void rightUp()
    {
        RightImage.sprite = RightUpSprite;
    }
}
