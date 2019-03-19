using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletFromEndButton : MonoBehaviour {
    public void Delete()
    {
        if (SceneManager1.scenM.IsAllowed())
        {
            string current = SceneManager1.scenM.CurrentNum.ToString();
            string Final;
            if (current.Length > 1)
                 Final = current.Remove(current.Length - 1);
            else
                 Final = "0";
            if (Final == "-")
                Final = "0";
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
