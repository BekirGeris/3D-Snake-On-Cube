using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Snake.Utiles;
using UnityEngine.UI;

public class MusicAndSoundStatus : MonoBehaviour
{
    [Header("Toggle")]
    [SerializeField] private Toggle toggleMusic;
    [SerializeField] private Toggle toggleSound;

    // Start is called before the first frame update
    void Start()
    {
        setToggleMusicAndSound();
    }

    public void setToggleMusicAndSound()
    {
        if (RuntimeHelper.getMusicStatus() == true)
        {
            toggleMusic.SetIsOnWithoutNotify(true);
        }
        else if (RuntimeHelper.getMusicStatus() == false)
        {
            toggleMusic.SetIsOnWithoutNotify(false);
        }

        if (RuntimeHelper.getSoundStatus() == true)
        {
            toggleSound.SetIsOnWithoutNotify(true);
        }
        else if (RuntimeHelper.getSoundStatus() == false)
        {
            toggleSound.SetIsOnWithoutNotify(false);
        }
    }

    public void setMusicStatus()
    {
        RuntimeHelper.setMusicStatus(!RuntimeHelper.getMusicStatus());
    }

    public void setSoundStatus()
    {
        RuntimeHelper.setSoundStatus(!RuntimeHelper.getSoundStatus());
    }
}
