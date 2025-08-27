using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiscuitManager : MonoBehaviour
{
    public Biscuit[] biscuits;
    public Drink[] drinks;

    public Biscuit currentBiscuit;
    public Drink currentDrink;

    public int crumbs = 0;

    void Start()
    {
        biscuits[0].unlocked = true;
        drinks[0].unlocked = true;
        currentBiscuit = biscuits[0];
        currentDrink = drinks[0];
    }

    public bool UnlockBiscuit(int i)
    {
        //Call function when we want the player to unlock a biscuit
        Biscuit b = biscuits[i];
        if (!b.unlocked && crumbs >= b.price)
        {
            crumbs -= b.price;
            b.unlocked = true;
            currentBiscuit = b;
            return true;
        }
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
        }
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
