using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlighItem : MonoBehaviour
{
    public Color highlightColor = Color.yellow;
    private Color originalColor;

    private void Start()
    {
        // Save the original color when the script starts
        originalColor = GetComponent<Image>().color;

        // Unhighlight all slots at the beginning
        Unhighlight();
    }

    public void Highlight()
    {
        // Change the color to the highlight color when the slot is highlighted
        GetComponent<Image>().color = highlightColor;
    }

    public void Unhighlight()
    {
        // Reset the color to the original color when the slot is unhighlighted
        GetComponent<Image>().color = originalColor;
    }
}
