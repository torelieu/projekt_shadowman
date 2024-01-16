using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpLvlLive : MonoBehaviour
{
    private int xp = 0;
    private int level = 1;
    private int money = 0;

    [SerializeField] private GameObject questBtn;

    [SerializeField] private Text xpText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text moneyText;

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
        yield return new WaitForSeconds(5f); // Simulace èasu pro splnìní questu

        xp += 100;
        money += 30;

        LevelUp();

        UpdateUI();
    }

    void LevelUp()
    {
        int xpNeeded = 200 + (level - 1) * 100; //Výpoèet potøebných XP pro level up

        if (xp >= xpNeeded)
        {
            level++;
            xp -= xpNeeded;
            LevelUp();
        }
    }
}
