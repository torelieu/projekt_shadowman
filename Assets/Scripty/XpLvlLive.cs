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



    [SerializeField] private Text xpText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text moneyText;

    void Start()
    {

    }

    private void Update()
    {
        UpdateUI();
    }

    public void AcceptQuest()
    {
        StartCoroutine(QuestCoroutine());
    }

    private IEnumerator QuestCoroutine()
    {
        // Perform initialization or setup for the quest

        // Wait for the quest to be completed or timeout
        yield return new WaitForSeconds(7f);

        if (Health.kills >= 1)
        {
            CompleteQuest();
        }
        else
        {
            Debug.Log("You quest have expired!");
        }
            
    }
    public void CompleteQuest()
    {
        xp += 100;
        money += 150;
        LevelUp();
    }

    public void UpdateUI()
    {
        xpText.text = "XP: " + xp.ToString();
        levelText.text = "Level: " + level.ToString();
        moneyText.text = money.ToString();
    }

    void LevelUp()
    {
        int xpNeeded = 200 + (level - 1) * 100; //V�po�et pot�ebn�ch XP pro level up

        if (xp >= xpNeeded && level <= 10)
        {
            level++;
            xp -= xpNeeded;
            money += 100;

            // M��ete p�idat dal�� vlastnosti p�i level up, nap��klad zv��en� �ivot�, s�ly, apod.
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
