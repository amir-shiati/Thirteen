using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AduioManager : MonoBehaviour {
    public static AduioManager Audio;

    private AudioSource ButtonPressAduio;
    private AudioSource NoMoveLeftAduio;
    private AudioSource WinAudio;

    void Awake()
    {
        Audio = this;
    }
    void Start ()
    {
        ButtonPressAduio = transform.GetChild(0).GetComponent<AudioSource>();
        NoMoveLeftAduio = transform.GetChild(1).GetComponent<AudioSource>();
        WinAudio = transform.GetChild(2).GetComponent<AudioSource>();
    }

    public void ButtonPress()
    {
        if(SceneManager1.scenM.Sound())
            ButtonPressAduio.Play();
    }

    public void NoMoveLef()
    {
        if (SceneManager1.scenM.Sound())
            NoMoveLeftAduio.Play();
    }
    public void Win()
    {
        if (SceneManager1.scenM.Sound())
            WinAudio.Play(); ;
    }

}
