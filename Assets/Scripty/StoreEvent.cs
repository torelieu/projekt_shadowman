using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreEvent : MonoBehaviour
{
    public Button goldenSwordButton;
    public Button diamondSwordButton;

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
        }
    }
    void BuyDiamondSword()
    {
        if (XpLvlLive.money >= 1500)
        {
            XpLvlLive.money -= 1500;
        }
    }
}
