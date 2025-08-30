using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiscuitUIManager : MonoBehaviour
{
    private BiscuitManager bm;
    public BiscuitButtonVisuals[] buttonVisuals;
    void Awake()
    {
        bm = FindFirstObjectByType<BiscuitManager>();
    }

    public void RefreshButtons()
    {
        for (int i = 0; i < buttonVisuals.Length; i++)
        {
            bool isUnlocked = bm.biscuits[i].unlocked;
            bool isSelected = (bm.biscuits[i] == bm.currentBiscuit);
            buttonVisuals[i].UpdateVisuals(isUnlocked, isSelected);
        }
    }
}
