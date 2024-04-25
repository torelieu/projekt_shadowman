using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayAnimOnTrigger : MonoBehaviour
{
    
    [SerializeField] private Animator menuAnimator;
    [SerializeField] private Animator swordAnimator;
    public Animator goldenSwordAnimator;
    private bool a = false;

    private void Update()
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
