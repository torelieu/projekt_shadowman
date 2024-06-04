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

    public Text timeText;

    public Text killText;

    private int c = 0;

    string textCompleted = "Quest Completed Succesfuly";



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
        Health.kills = 0;

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
        float totalTime1 = 60f;
        float remainingTime1 = totalTime1;

        while (remainingTime1 > 0)
        {
            timeText.text = "Kill 5 Enemies: " + Mathf.Ceil(remainingTime1) + " seconds";
            yield return new WaitForSeconds(1f);
            remainingTime1 -= 1f;
        }

        if (Health.kills >= 5)
        {
            CompleteQuest();
            killText.text = "Kill 10 Enemies";
            timeText.text = textCompleted;
        }
        else
        {
            timeText.text = "Your quest has expired!";
        }
    }
    private IEnumerator QuestCoroutine2()
    {
        float totalTime2 = 120f;
        float remainingTime2 = totalTime2;

        while (remainingTime2 > 0)
        {
            timeText.text = "Kill 10 Enemies: " + Mathf.Ceil(remainingTime2) + " seconds";
            yield return new WaitForSeconds(1f);
            remainingTime2 -= 1f;
        }

        if (Health.kills >= 10)
        {
            CompleteQuest();
            killText.text = "Kill 25 Enemies";
            timeText.text = textCompleted;
        }
        else
        {
            timeText.text = "Your quest has expired!";
        }
    }
    private IEnumerator QuestCoroutine3()
    {
        float totalTime3 = 240f;
        float remainingTime3 = totalTime3;

        while (remainingTime3 > 0)
        {
            timeText.text = "Kill 25 Enemies: " + Mathf.Ceil(remainingTime3) + " seconds";
            yield return new WaitForSeconds(1f);
            remainingTime3 -= 1f;
        }

        if (Health.kills >= 25)
        {
            CompleteQuest();
            killText.text = "Kill 50 Enemies";
            timeText.text = textCompleted;
        }
        else
        {
            timeText.text = "Your quest has expired!";
        }

    }
    private IEnumerator QuestCoroutine4()
    {

        float totalTime4 = 360f;
        float remainingTime4 = totalTime4;

        while (remainingTime4 > 0)
        {
            timeText.text = "Kill 50 Enemies: " + Mathf.Ceil(remainingTime4) + " seconds";
            yield return new WaitForSeconds(1f);
            remainingTime4 -= 1f;
        }

        if (Health.kills >= 50)
        {
            CompleteQuest();
            killText.text = "Kill 100 Enemies";
            timeText.text = textCompleted;
        }
        else
        {
            timeText.text = "Your quest has expired!";
        }

    }
    private IEnumerator QuestCoroutine5()
    {
        float totalTime4 = 500f;
        float remainingTime4 = totalTime4;

        while (remainingTime4 > 0)
        {
            timeText.text = "Kill 100 Enemies: " + Mathf.Ceil(remainingTime4) + " s";
            yield return new WaitForSeconds(1f);
            remainingTime4 -= 1f;
        }

        if (Health.kills >= 100)
        {
            CompleteQuest();
            killText.text = "All quests has been completed..";
        }
        else
        {
            timeText.text = "Your quest has expired!";
        }
    }
    public void CompleteQuest()
    {
        xp += 300;
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
        int xpNeeded = 100 + (level - 1) * 100; //Výpoèet potøebných XP pro level up

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
