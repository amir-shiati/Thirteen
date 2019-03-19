using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonText : MonoBehaviour {
    public string buttonText;

	void Start ()
    {
        transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().text = buttonText;
	}
}
