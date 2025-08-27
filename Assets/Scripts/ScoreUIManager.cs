using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUIManager : MonoBehaviour
{
    public BiscuitManager bm;
    public TMP_Text crumbsText;
    void Start()
    {
        if (bm == null)
        {
            bm = FindFirstObjectByType<BiscuitManager>();
        }
    }

    void Update()
    {
        crumbsText.text = "Crumbs: " + bm.crumbs;
    }
}
