using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionButton : MonoBehaviour {

    public int ToDivide;

    public void Division()
    {
        if (SceneManager1.scenM.IsAllowed())
        {
            SceneManager1.scenM.CurrentNum /= ToDivide;
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
