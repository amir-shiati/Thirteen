using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons1 : MonoBehaviour
{
    public string TextToShow;
    void Start()
    {
        transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().text = TextToShow;
    }
}
