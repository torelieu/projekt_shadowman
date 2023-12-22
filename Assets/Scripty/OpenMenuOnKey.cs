using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenuOnKey : MonoBehaviour
{
    public Image Menu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.GetComponent<Animator>().Play("idk");
        }
    }
}
