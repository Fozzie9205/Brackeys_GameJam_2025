using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BiscuitButtonVisuals : MonoBehaviour
{
    private Button button;

    public Color lockedColour = Color.grey;
    public Color unlockedColour = Color.white;
    public Color selectedColour = Color.green;

    public void Start()
    {
        button = GetComponent<Button>();
    }

    public void UpdateVisuals(bool isUnlocked, bool isSelected)
    {
        if (!isUnlocked)
        {
            button.image.color = lockedColour;
        }
        else if (isSelected)
        {
            button.image.color = selectedColour;
        }
        else
        {
            button.image.color = unlockedColour;
        }
    }
}
