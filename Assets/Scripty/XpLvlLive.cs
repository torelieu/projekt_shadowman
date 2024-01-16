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
        yield return new WaitForSeconds(5f); // Simulace �asu pro spln�n� questu

        xp += 100;
        money += 30;

        LevelUp();

        UpdateUI();
    }

    void LevelUp()
    {
<<<<<<< HEAD
        int xpNeeded = 200 + (level - 1) * 100; // V�po�et pot�ebn�ch XP pro level up
        
=======
        int xpNeeded = 200 + (level - 1) * 100; //V�po�et pot�ebn�ch XP pro level up
>>>>>>> 77b9a5795366c5f54885d1a91709df55c603db2c

        if (xp >= xpNeeded && level <= 10)
        {
            level++;
            xp -= xpNeeded;
<<<<<<< HEAD
            money += 70;

            // M��ete p�idat dal�� vlastnosti p�i level up, nap��klad zv��en� �ivot�, s�ly, apod.
=======
>>>>>>> 77b9a5795366c5f54885d1a91709df55c603db2c
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
