using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrinkManager : MonoBehaviour
{
    private ScoreManager scoreManager;
    private DrinkUIManager drinkUIManager;
    private DrinkSpriteManager spriteManager;

    public Drink[] drinks;
    public Drink currentDrink;

    private void Awake()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
        drinkUIManager = FindFirstObjectByType<DrinkUIManager>();
        spriteManager = FindFirstObjectByType<DrinkSpriteManager>();
    }
    void Start()
    {
        drinks[0].unlocked = true;
        currentDrink = drinks[0];

        drinkUIManager.RefreshButtons();
    }

    public bool UnlockDrink(int i)
    {
        //Call function when we want the player to unlock a drink
        Drink d = drinks[i];

        if (!d.unlocked && scoreManager.crumbs >= d.price)
        {
            scoreManager.crumbs -= d.price;
            d.unlocked = true;
            currentDrink = d;
        }

        if (d.unlocked)
        {
            SetCurrentDrink(i);
            return true;
        }

        Debug.Log("You don't have enough crumbs");
        return false;
    }

    public void SetCurrentDrink(int i)
    {
        //Call function whe player selects a drink
        if (drinks[i].unlocked)
        {
            currentDrink = drinks[i];
            Debug.Log("Selected: " + currentDrink.name);
        }

        drinkUIManager.RefreshButtons();
        spriteManager.UpdateDrinkSprite();
    }
}
