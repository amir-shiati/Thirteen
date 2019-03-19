using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplicationButton : MonoBehaviour {

    public int Tomultiply;

    public void Multiplication()
    {
        if (SceneManager1.scenM.IsAllowed())
        {
            SceneManager1.scenM.CurrentNum *= Tomultiply;
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
