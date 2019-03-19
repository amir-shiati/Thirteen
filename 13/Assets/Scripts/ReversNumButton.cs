using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversNumButton : MonoBehaviour {
    private bool negetive = false;
    public void Reverse()
    {
        if (SceneManager1.scenM.IsAllowed())
        {
            string current = SceneManager1.scenM.CurrentNum.ToString();
            if (current.ToLower().Contains("-"))
            {
                current = current.Trim(new char[] { '-' });
                negetive = true;
            }
            char[] currentLetter = current.ToCharArray();
            char[] finalLetter = new char[currentLetter.Length];
            int letterscount = currentLetter.Length;
            for (int i = 0; i < currentLetter.Length; i++)
            {
                finalLetter[i] = currentLetter[letterscount - 1];
                letterscount -= 1;
            }
            string Final = "";
            for (int i = 0; i < finalLetter.Length; i++)
            {
                Final = Final + finalLetter[i];
            }
            SceneManager1.scenM.CurrentNum = int.Parse(Final);
            if(negetive)
                SceneManager1.scenM.CurrentNum *= -1;
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
