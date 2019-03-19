using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnim : MonoBehaviour
{

    private Animation anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    public void goDown()
    {
        anim.Play();
    }
}
