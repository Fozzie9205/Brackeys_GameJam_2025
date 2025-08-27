using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiscuitManager : MonoBehaviour
{
    private BiscuitUIManager biscuitUIManager;

    public Biscuit[] biscuits;
    public Drink[] drinks;

    public Biscuit currentBiscuit;
    public Drink currentDrink;

    public int crumbs = 0;

    void Start()
    {
        if (biscuitUIManager == null)
        {
            biscuitUIManager = FindFirstObjectByType<BiscuitUIManager>();
        }

        biscuits[0].unlocked = true;
        drinks[0].unlocked = true;
        currentBiscuit = biscuits[0];
        currentDrink = drinks[0];

        biscuitUIManager.RefreshButtons();
    }

    public bool UnlockBiscuit(int i)
    {
        //Call function when we want the player to unlock a biscuit
        Biscuit b = biscuits[i];

        if (crumbs >= b.price)
        {
            crumbs -= b.price;
            b.unlocked = true;
            currentBiscuit = b;
        }

        if (b.unlocked)
        {
            SetCurrentBiscuit(i);
            return true;
        }

        Debug.Log("You don't have enough crumbs");
        return false;
    }

    public bool UnlockDrink(int i)
    {
        //Call function when we want the player to unlock a drink
        Drink d = drinks[i];
        if (!d.unlocked && crumbs >= d.price)
        {
            crumbs -= d.price;
            d.unlocked = true;
            currentDrink = d;
            return true;
        }
        return false;
    }

    public void SetCurrentBiscuit(int i)
    {
        //Call function when player selects a biscuit
        if (biscuits[i].unlocked)
        {
            currentBiscuit = biscuits[i];
            Debug.Log("Selected: " + currentBiscuit.name);
        }

        biscuitUIManager.RefreshButtons();
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
