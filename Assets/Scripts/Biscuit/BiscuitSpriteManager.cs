using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiscuitSpriteManager : MonoBehaviour
{
    private BiscuitManager bm;
    public Sprite[] biscuitSprites;

    public SpriteRenderer biscuitSprite;
    private void Awake()
    {
        bm = FindFirstObjectByType<BiscuitManager>();
    }

    void Start()
    {
        UpdateBiscuitSprite();    
    }

    public void UpdateBiscuitSprite()
    {
        int biscuitIndex = Array.IndexOf(bm.biscuits, bm.currentBiscuit);

        if (biscuitIndex >= 0 && biscuitIndex < biscuitSprites.Length)
        {
            biscuitSprite.sprite = biscuitSprites[biscuitIndex];
        }
    }
}
