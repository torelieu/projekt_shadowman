using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenuOnKey : MonoBehaviour
{
    
    public Animator menuAnimator;
    private bool a = false;
    public GameObject menuBtny;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && a == false)
        {
            menuAnimator.SetTrigger("ShowMenu");
            a = true;
            StartCoroutine(BtnyShow());
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && a == true)
        {
            menuAnimator.SetTrigger("DisMenu");
            a = false;
            StartCoroutine(BtnyDis());
        }
    }

    IEnumerator BtnyShow()
    {
        yield return new WaitForSeconds(0.2f);
        menuBtny.SetActive(true);
    }
    IEnumerator BtnyDis()
    {
        yield return new WaitForSeconds(0.1f);
        menuBtny.SetActive(false);
    }
}
