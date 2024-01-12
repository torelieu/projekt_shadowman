using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenuOnKey : MonoBehaviour
{
    public GameObject panel;
    public Animator menuAnimator;
    private bool a = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && a == false)
        {
            
            // Trigger the animation when the Escape key is pressed
            menuAnimator.SetTrigger("ShowMenu");
            a = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && a == true)
        {
            menuAnimator.SetTrigger("DisMenu");
            a = false;
            
        }

       
    }

    public void DisablePanel()
    {
        panel.SetActive(false);
    }

    public void EnablePanel()
    {
        panel.SetActive(true);
    }
}
