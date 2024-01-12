using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenuOnKey : MonoBehaviour
{
    
    public Animator menuAnimator;
    private bool a = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && a == false)
        {
            menuAnimator.SetTrigger("ShowMenu");
            a = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && a == true)
        {
            menuAnimator.SetTrigger("DisMenu");
            a = false;
        }
    }
}
