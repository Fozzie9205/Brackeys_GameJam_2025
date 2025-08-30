using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrinkButtonVisuals : MonoBehaviour
{
    private Button button;

    public Color lockedColour = Color.grey;
    public Color unlockedColour = Color.white;
    public Color selectedColour = Color.green;

    public TMP_Text priceText;

    void Awake()
    {
        button = GetComponent<Button>();

        if (priceText == null)
        {
            priceText = GetComponentInChildren<TMP_Text>();
        }
    }

    public void UpdateVisuals(bool isUnlocked, bool isSelected)
    {
        if (!isUnlocked)
        {
            button.image.color = lockedColour;
            if (priceText != null) priceText.gameObject.SetActive(true);
        }
        else
        {
            button.image.color = isSelected ? selectedColour : unlockedColour;
            if (priceText != null) priceText.gameObject.SetActive(false);
        }
    }
}
