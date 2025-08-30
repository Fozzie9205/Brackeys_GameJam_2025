using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkUIManager : MonoBehaviour
{
    private DrinkManager dm;
    public DrinkButtonVisuals[] buttonVisuals;
    void Awake()
    {
        dm = FindFirstObjectByType<DrinkManager>();
    }

    public void RefreshButtons()
    {
        for (int i = 0; i < buttonVisuals.Length; i++)
        {
            bool isUnlocked = dm.drinks[i].unlocked;
            bool isSelected = (dm.drinks[i] == dm.currentDrink);
            buttonVisuals[i].UpdateVisuals(isUnlocked, isSelected);
        }
    }
}
