using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LcdManager : MonoBehaviour {
    public static LcdManager lcd;
    public Color FalseColor;
    public Color DefualtColor;
    private TextMesh LcdTxt;
    private Text MoveLeftText;
    private Animation anim;
    private Animation anim2;
    void Awake()
    {
        lcd = this;
        MoveLeftText = GameObject.Find("MoveLeft").transform.GetChild(0).GetComponent<Text>();
        LcdTxt = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>();
        anim = gameObject.GetComponent<Animation>();
        anim2 = GameObject.Find("Top circle").GetComponent<Animation>();
    }
	public void UpdateLcd(string TextToShow)
    {
        LcdTxt.text = TextToShow;
    }
    public void UpdateMoveLeft(int MoveLeft)
    {
        MoveLeftText.text = MoveLeft.ToString();
    }
    public void NoMoreMoveLeft()
    {
        StartCoroutine(wait());
    }
    public void Win()
    {
        anim.Play("Win");
        anim2.Play("WinText");
    }
    IEnumerator wait()
    {
        MoveLeftText.color = FalseColor;
        AduioManager.Audio.NoMoveLef();
        yield return new WaitForSeconds(0.3f);
        MoveLeftText.color = DefualtColor;
    }
}
