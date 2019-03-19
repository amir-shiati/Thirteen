using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNumToEndButton : MonoBehaviour
{
    public int ToAdd;

    public void AddToEnd()
    {
        if (SceneManager1.scenM.IsAllowed())
        {
            string toadd = ToAdd.ToString();
            string current = SceneManager1.scenM.CurrentNum.ToString();
            string Final = current + toadd;
            SceneManager1.scenM.CurrentNum = int.Parse(Final);
            SceneManager1.scenM.CurrentMoveLeft -= 1;
            LcdManager.lcd.UpdateMoveLeft(SceneManager1.scenM.CurrentMoveLeft);
            LcdManager.lcd.UpdateLcd(SceneManager1.scenM.CurrentNum.ToString());
        }
        else
        {
            LcdManager.lcd.NoMoreMoveLeft();
        }
    }
}
