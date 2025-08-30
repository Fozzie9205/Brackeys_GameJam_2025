using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private Win win;

    public int winScore;
    public int crumbs = 0;

    private void Awake()
    {
        win = FindFirstObjectByType<Win>();
    }

    void Update()
    {
        if (crumbs >= winScore)
        {
            win.WinScreen();
        }
    }
}
