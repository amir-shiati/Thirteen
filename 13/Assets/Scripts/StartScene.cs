using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;

public class StartScene : MonoBehaviour {
    public Color FadeColor;
    public float DampTime;
    public void StartLevel()
    {
        int Level = SaveGame.Load<int>("Level");
        string LevelToStart = Level.ToString();
        Initiate.Fade(LevelToStart, FadeColor, DampTime);
    }
}
