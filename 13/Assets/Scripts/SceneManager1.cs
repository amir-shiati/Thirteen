using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using UnityEngine.SceneManagement;

public class SceneManager1 : MonoBehaviour
{
    public static SceneManager1 scenM;
    public int StartNum;
    public int MoveLeft;
    [Space]
    public int HintLeft;
    public int CurrentNum;
    public int CurrentMoveLeft;

    private bool Win = false;
    void Awake()
    {
        SaveGame.Save<int>("Hint", 300);
        scenM = this;
        // SaveGame.Save<int>("Level", 0);
       // PlayerPrefs.SetString("isfirsttime", "");
        string isfirttime = PlayerPrefs.GetString("isfirsttime");
        if(isfirttime != "isfirsttime")
        {
            SaveGame.Save<int>("Hint", 3);
            PlayerPrefs.SetString("isfirsttime" , "isfirsttime");
        }      
    }

    void Start()
    {
        if(SceneManager.GetActiveScene().name != "Menu")
            ResetData();

        CurrentNum = StartNum;
        CurrentMoveLeft = MoveLeft;
        HintLeft = SaveGame.Load<int>("Hint");
        if (SceneManager.GetActiveScene().name != "Menu")
            setHint();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
           
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit && hit.collider != null && hit.collider.GetComponent<ButtonAnim>() != null)
            {
                hit.collider.gameObject.GetComponent<ButtonAnim>().goDown();
                if(CurrentMoveLeft > 0 && !Win)
                {
                    AduioManager.Audio.ButtonPress();
                }
            }
            else
                return;
               
            //+++++++++++   Add +++++++++++++
            if (hit.collider.name == "Add" && !Win)
                hit.collider.gameObject.GetComponent<AddButton>().Add();
            //+++++++++++   Mines +++++++++++++
            if(hit.collider.name == "Mines" && !Win)
                hit.collider.gameObject.GetComponent<MinesButton>().Mines();
            //+++++++++++   multiplication   +++++++++++++
            if (hit.collider.name == "Multiplication" && !Win)
                hit.collider.gameObject.GetComponent<MultiplicationButton>().Multiplication();
            //+++++++++++   Division   +++++++++++++
            if (hit.collider.name == "Division" && !Win)
                hit.collider.gameObject.GetComponent<DivisionButton>().Division();
            //+++++++++++   AddNumToEnd   +++++++++++++
            if (hit.collider.name == "AddNumToEnd" && !Win)
                hit.collider.gameObject.GetComponent<AddNumToEndButton>().AddToEnd();
            //+++++++++++   DeleteFromEnd   +++++++++++++
            if (hit.collider.name == "DeleteFromEnd" && !Win)
                hit.collider.gameObject.GetComponent<DeletFromEndButton>().Delete();
            //+++++++++++   ReverseNum   +++++++++++++
            if (hit.collider.name == "ReverseNum" && !Win)
                hit.collider.gameObject.GetComponent<ReversNumButton>().Reverse();
            //+++++++++++   Mirror   +++++++++++++
            if (hit.collider.name == "Mirror" && !Win)
                hit.collider.gameObject.GetComponent<MirrorButton>().Mirros();
            //+++++++++++   Hint   +++++++++++++
            if (hit.collider.name == "Hint" && !Win)
                hit.collider.gameObject.GetComponent<HintManager>().GiveHint();
            //+++++++++++   Ac   +++++++++++++
            if (hit.collider.name == "Ac" && !Win)
                ResetData();

            if (hit.collider.name == "Menu")
                MenuStart();

            if (hit.collider.GetComponent<ButtonAnim>() != null)
            {
                WinCheck();
            }
        }
    }
    void WinCheck()
    {
        if (CurrentNum == 13f && !Win)
        {
            Win = true;
            int Level = SaveGame.Load<int>("Level");
            Level++;
            SaveGame.Save<int>("Level" , Level);
            StartCoroutine(wait());
        }
    }
    void ResetData()
    {
        CurrentNum = StartNum;
        CurrentMoveLeft = MoveLeft;
        LcdManager.lcd.UpdateLcd(CurrentNum.ToString());
        LcdManager.lcd.UpdateMoveLeft(CurrentMoveLeft);
    }
    void MenuStart()
    {
        Color color = new Color();
        ColorUtility.TryParseHtmlString("#4B4B4BFF", out color);
        Initiate.Fade("Menu", color, 1.3f);
    }
    public void setHint()
    {
        GameObject.Find("Hint").transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().text = HintLeft.ToString();
    }

    public  bool IsAllowed()
    {
        if (CurrentMoveLeft > 0 && !Win)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Sound()
    {
        bool Sound1;
        Sound1 = SaveGame.Load<bool>("Sound");
        if (!Sound1)
            return true;
        else
            return false;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.2f);
        LcdManager.lcd.Win();
        AduioManager.Audio.Win();
    }
}
