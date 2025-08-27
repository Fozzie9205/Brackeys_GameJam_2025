using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiscuitButtons : MonoBehaviour
{
    public BiscuitManager bm;
    void Start()
    {
        if (bm == null)
        {
            bm = FindFirstObjectByType<BiscuitManager>();
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            int biscuitIndex = i;
            Button btn = transform.GetChild(i).GetComponent<Button>();
            btn.onClick.AddListener(() => bm.UnlockBiscuit(biscuitIndex));
        }
    }
}
