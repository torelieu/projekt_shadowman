using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpLvlLive : MonoBehaviour
{
    public int xp = 0;
    public int level = 1;
    public int money = 0;

    public GameObject questBtn;

    public Text xpText;
    public Text levelText;
    public Text moneyText;

    void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            questBtn.SetActive(true);
        }
    }

    void UpdateUI()
    {
        xpText.text = "XP: " + xp.ToString();
        levelText.text = "Level: " + level.ToString();
        moneyText.text = "Money: $" + money.ToString();
    }

    public void AcceptQuest()
    {
        StartCoroutine(CompleteQuest());
        questBtn.SetActive(false);
    }

    IEnumerator CompleteQuest()
    {
        yield return new WaitForSeconds(5f); // Simulace èasu pro dojítí na místo

        xp += 100;
        money += 30;

        LevelUp();

        UpdateUI();
    }

    void LevelUp()
    {
        int xpNeeded = 200 + (level - 1) * 100; // Výpoèet potøebných XP pro level up
        

        if (xp >= xpNeeded && level <= 10)
        {
            level++;
            xp -= xpNeeded;
            money += 70;

            // Mùžete pøidat další vlastnosti pøi level up, napøíklad zvýšení životù, síly, apod.
            LevelUp();
        }
        else if (xp>= xpNeeded && level > 10)
        {
            level++;
            xp -= xpNeeded;
            money += 120;
        }
    }
}
