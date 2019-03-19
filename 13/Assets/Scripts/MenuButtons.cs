using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {
    public Color FadeColor;
    public float DampTime;
    public Sprite SoundOn;
    public Sprite SoundOff;

    private int Level;
    private bool Sound;
	void Start ()
    {
       // SaveGame.Save<bool>("Sound", true);
        Level = SaveGame.Load<int>("Level");
        Sound = SaveGame.Load<bool>("Sound");
        setSound();
        setLevel();
	}

	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit && hit.collider != null && hit.collider.GetComponent<ButtonAnim>() != null)
            {
                hit.collider.gameObject.GetComponent<ButtonAnim>().goDown();
                AduioManager.Audio.ButtonPress();
            }
            else
                return;

            if (hit.collider.name == "Play")
                StartLevel();

            if (hit.collider.name == "Sound")
                toggleSound();
        }
    }
    void setSound()
    {
        GameObject soundobj = GameObject.Find("Sound").transform.GetChild(0).transform.GetChild(1).gameObject;
        if (!Sound)
        {
            soundobj.GetComponent<SpriteRenderer>().sprite = SoundOn;
        }
        if (Sound)
        {
            soundobj.GetComponent<SpriteRenderer>().sprite = SoundOff;
        }
    }
    void setLevel()
    {
        GameObject PlayHint = GameObject.Find("Play").transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).gameObject;
        int LevelText = Level + 1;
        PlayHint.GetComponent<TextMesh>().text = LevelText.ToString();
    }
    void toggleSound()
    {
        Sound = !Sound;
        SaveGame.Save<bool>("Sound", Sound);
        setSound();
    }
    void StartLevel()
    {
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.2f);
        string LevelToStart = Level.ToString();
        Initiate.Fade(LevelToStart, FadeColor, DampTime);
    }
}
