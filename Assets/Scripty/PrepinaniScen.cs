using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrepinaniScen : MonoBehaviour
{

    public void SceneSwitcher(string nazev)
    {
        SceneManager.LoadScene(nazev);
    }
}
