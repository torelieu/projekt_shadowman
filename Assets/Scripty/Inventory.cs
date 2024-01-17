using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject Sword;
    public GameObject GoldenSword;
    public GameObject DiamondSword;
    public GameObject Heal;
    public GameObject[] inventorySlots; // Array to hold your inventory slots
    public int highlightedSlotIndex = 0; // Index of the currently highlighted slot
    private bool slot1;
    private bool slot2;
    private bool nonSelected;
    private GameObject[] Swords;

    private void Start()
    {
        slot1 = true; 
        slot2 = false;
    }
    // Update is called once per frame
    void Update()
    {
        // Handle input for highlighting inventory slots
        HandleInput();

        // Update visual feedback for highlighted slot
        UpdateHighlight();

        if (slot1 == true)
        {
            Heal.SetActive(false);
            if (StoreEvent.goldenSwordSelected == false && StoreEvent.diamondSwordSelected == false) 
            { 
                Sword.SetActive(true);
                GoldenSword.SetActive(false);
                DiamondSword.SetActive(false);
            }
            else if (StoreEvent.goldenSwordSelected == true && StoreEvent.diamondSwordSelected == false)
            {
                Sword.SetActive(false);
                GoldenSword.SetActive(true);
                DiamondSword.SetActive(false);
            }
            else if (StoreEvent.goldenSwordSelected == false && StoreEvent.diamondSwordSelected == true)
            {
                Sword.SetActive(false);
                GoldenSword.SetActive(false);
                DiamondSword.SetActive(true);
            }
        }
        else if (slot2 == true)
        {
            Sword.SetActive(false);
            GoldenSword.SetActive(false);
            DiamondSword.SetActive(false);
            Heal.SetActive(true);
        }
    }

    void HandleInput()
    {
        
        // Change the highlighted slot index based on user input
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            highlightedSlotIndex = 0;
            slot1 = true;
            slot2 = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            highlightedSlotIndex = 1;
            slot1 = false;
            slot2 = true;
        }

        // Ensure the highlighted index stays within the bounds of the inventory array
        highlightedSlotIndex = Mathf.Clamp(highlightedSlotIndex, 0, inventorySlots.Length - 1);
    }

    void UpdateHighlight()
    {
        // Loop through all inventory slots and highlight the selected one
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            // Assuming you have some visual representation of each slot (e.g., a border or color change)
            if (i == highlightedSlotIndex)
            {
                // Highlight the current slot
                inventorySlots[i].GetComponent<HighlighItem>().Highlight();
            }
            else
            {
                // Remove highlight from other slots
                inventorySlots[i].GetComponent<HighlighItem>().Unhighlight();
            }
        }
    }

}
