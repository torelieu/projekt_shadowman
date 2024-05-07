using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class XpLvlLive : MonoBehaviour
{
    private int xp = 0;
    private int level = 1;
    public static int money = 0;

    public Text text;

    public Text killText;

    private int c = 0;



    [SerializeField] private Text xpText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text moneyText;

    void Start()
    {

    }

    private void Update()
    {
        UpdateUI();
        text.text = Convert.ToString(Health.kills);
    }

    public void AcceptQuest()
    {
        if (c == 0)
        {
            StartCoroutine(QuestCoroutine1());
        }
        if (c == 1)
        {
            StartCoroutine(QuestCoroutine2());
        }
        if (c == 2)
        {
            StartCoroutine(QuestCoroutine3());
        }
        if (c == 3)
        {
            StartCoroutine(QuestCoroutine4());
        }
        if (c == 4)
        {
            StartCoroutine(QuestCoroutine5());
        }
        if (c >= 5)
        {
            Debug.Log("You have already completed all quests!");
        }

    }

    private IEnumerator QuestCoroutine1()
    {
        yield return new WaitForSeconds(7f);

        if (Health.kills >= 1)
        {
            CompleteQuest();
            killText.text = "Kill 10 Enemies";
        }
        else
        {
            Debug.Log("Your quest have expired!");
        }
            
    }
    private IEnumerator QuestCoroutine2()
    {
        yield return new WaitForSeconds(7f);

        if (Health.kills >= 10)
        {
            CompleteQuest();
            killText.text = "Kill 25 Enemies";
        }
        else
        {
            Debug.Log("Your quest have expired!");
        }

    }
    private IEnumerator QuestCoroutine3()
    {
        yield return new WaitForSeconds(7f);

        if (Health.kills >= 25)
        {
            CompleteQuest();
            killText.text = "Kill 50 Enemies";
        }
        else
        {
            Debug.Log("Your quest have expired!");
        }

    }
    private IEnumerator QuestCoroutine4()
    {
        yield return new WaitForSeconds(7f);

        if (Health.kills >= 50)
        {
            CompleteQuest();
            killText.text = "Kill 100 Enemies";
        }
        else
        {
            Debug.Log("Your quest have expired!");
        }

    }
    private IEnumerator QuestCoroutine5()
    {
        yield return new WaitForSeconds(7f);

        if (Health.kills >= 100)
        {
            CompleteQuest();
            killText.text = "All Quests Completed";
        }
        else
        {
            Debug.Log("Your quest have expired!");
        }

    }
    public void CompleteQuest()
    {
        xp += 100;
        money += 150;
        LevelUp();
        c++;
    }

    public void UpdateUI()
    {
        xpText.text = "XP: " + xp.ToString();
        levelText.text = "Level: " + level.ToString();
        moneyText.text = money.ToString();
    }

    void LevelUp()
    {
        int xpNeeded = 200 + (level - 1) * 100; //Výpoèet potøebných XP pro level up

        if (xp >= xpNeeded && level <= 10)
        {
            level++;
            xp -= xpNeeded;
            money += 100;

            // Mùžete pøidat další vlastnosti pøi level up, napøíklad zvýšení životù, síly, apod.
            LevelUp();
        }
        if (xp>= xpNeeded && level > 10)
        {
            level++;
            xp -= xpNeeded;
            money += 150;

            LevelUp();
        }
    }
}
