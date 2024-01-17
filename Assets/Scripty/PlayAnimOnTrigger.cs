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
        SwingSword();
        if (StoreEvent.goldenSwordSelected)
        SwingGoldenSword();

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

    private void SwingSword()
    {
        if (Input.GetMouseButtonDown(0))
        {
            swordAnimator.SetTrigger("Click");
        }
    }
    private void SwingGoldenSword()
    {
        if (Input.GetMouseButtonDown(0))
        {
            goldenSwordAnimator.SetTrigger("Click2");
        }
    }
}
