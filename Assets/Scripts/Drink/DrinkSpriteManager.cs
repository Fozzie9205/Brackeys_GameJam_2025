using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkSpriteManager : MonoBehaviour
{
    private DrinkManager dm;
    public Sprite[] drinkSprites;

    public SpriteRenderer drinkSprite;
    private void Awake()
    {
        dm = FindFirstObjectByType<DrinkManager>();
    }

    void Start()
    {
        UpdateDrinkSprite();
    }

    public void UpdateDrinkSprite()
    {
        int drinkIndex = Array.IndexOf(dm.drinks, dm.currentDrink);

        if (drinkIndex >= 0 && drinkIndex < drinkSprites.Length)
        {
            drinkSprite.sprite = drinkSprites[drinkIndex];
        }
    }
}
