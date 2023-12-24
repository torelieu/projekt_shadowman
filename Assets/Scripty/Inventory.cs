using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventorySlots; // Array to hold your inventory slots
    public int highlightedSlotIndex = 0; // Index of the currently highlighted slot

    // Update is called once per frame
    void Update()
    {
        // Handle input for highlighting inventory slots
        HandleInput();

        // Update visual feedback for highlighted slot
        UpdateHighlight();
    }

    void HandleInput()
    {
        // Change the highlighted slot index based on user input
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            highlightedSlotIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            highlightedSlotIndex = 1;
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
