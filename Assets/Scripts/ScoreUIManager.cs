using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUIManager : MonoBehaviour
{
    private ScoreManager scoreManager;

    public TMP_Text crumbsText;
    private void Awake()
    {
        if (scoreManager == null)
        {
            scoreManager = FindFirstObjectByType<ScoreManager>();
        }
    }

    void Update()
    {
        crumbsText.text = "Crumbs: " + scoreManager.crumbs;
    }
}
