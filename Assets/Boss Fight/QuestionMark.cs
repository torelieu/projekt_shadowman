using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionMark : MonoBehaviour
{
    public GameObject panel;
    public GameObject startPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    
    public void DisablePanel()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void RetryScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("FinalBoss");
    }
    public void QuitScene()
    {
        Application.Quit();
    }

    public void DisableStartPanel()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
