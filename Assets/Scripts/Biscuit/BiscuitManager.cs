using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiscuitManager : MonoBehaviour
{
    private ScoreManager scoreManager;
    private BiscuitUIManager biscuitUIManager;
    private BiscuitSpriteManager spriteManager;

    public Biscuit[] biscuits;
    public Biscuit currentBiscuit;

    private void Awake()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
        biscuitUIManager = FindFirstObjectByType<BiscuitUIManager>();
        spriteManager = FindFirstObjectByType<BiscuitSpriteManager>();
    }
    void Start()
    {
        biscuits[0].unlocked = true;
        currentBiscuit = biscuits[0];

        biscuitUIManager.RefreshButtons();
    }

    public bool UnlockBiscuit(int i)
    {
        //Call function when we want the player to unlock a biscuit
        Biscuit b = biscuits[i];

        if (!b.unlocked && scoreManager.crumbs >= b.price)
        {
            scoreManager.crumbs -= b.price;
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

    public void SetCurrentBiscuit(int i)
    {
        //Call function when player selects a biscuit
        if (biscuits[i].unlocked)
        {
            currentBiscuit = biscuits[i];
            Debug.Log("Selected: " + currentBiscuit.name);
        }

        biscuitUIManager.RefreshButtons();
        spriteManager.UpdateBiscuitSprite();
    }
}
