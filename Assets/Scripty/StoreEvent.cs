using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreEvent : MonoBehaviour
{
    public Button goldenSwordButton;
    public Button diamondSwordButton;
    public GameObject sword;
    public GameObject goldenSword;
    public GameObject diamondSword;
    public static bool diamondSwordSelected = false;
    public static bool goldenSwordSelected = false;

    void Start()
    {
        Button goldenSwordbtn = goldenSwordButton.GetComponent<Button>();
        Button diamonSwordbtn = diamondSwordButton.GetComponent<Button>();
        goldenSwordbtn.onClick.AddListener(BuyGoldenSword);
        diamonSwordbtn.onClick.AddListener(BuyDiamondSword);
    }

    void BuyGoldenSword()
    {
        if (XpLvlLive.money >= 500)
        {
            XpLvlLive.money -= 500;
            sword.SetActive(false);
            goldenSword.SetActive(true);
            diamondSword.SetActive(false);
            goldenSwordSelected = true;
        }
    }
    void BuyDiamondSword()
    {
        if (XpLvlLive.money >= 1500)
        {
            XpLvlLive.money -= 1500;
            sword.SetActive(false);
            goldenSword.SetActive(false);
            diamondSword.SetActive(true);
            diamondSwordSelected = true;
            goldenSwordSelected = false;
        }
    }
}
