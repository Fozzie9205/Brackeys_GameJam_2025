using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrinkManager : MonoBehaviour
{
    private ScoreManager scoreManager;

    public Drink[] drinks;
    public Drink currentDrink;

    private void Awake()
    {
        if (scoreManager == null)
        {
            scoreManager = FindFirstObjectByType<ScoreManager>();
        }
    }
    void Start()
    {
        drinks[0].unlocked = true;
        currentDrink = drinks[0];
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
            return true;
        }
        return false;
    }

    public void SetCurrentDrink(int i)
    {
        //Call function whe player selects a drink
        if (drinks[i].unlocked)
        {
            currentDrink = drinks[i];
        }
    }
}
