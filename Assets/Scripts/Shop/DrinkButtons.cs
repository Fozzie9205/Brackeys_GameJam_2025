using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkButtons : MonoBehaviour
{
    private DrinkManager dm;

    private void Awake()
    {
        dm = FindFirstObjectByType<DrinkManager>();
    }
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int drinkIndex = i;
            Button btn = transform.GetChild(i).GetComponent<Button>();
            btn.onClick.AddListener(() => dm.UnlockDrink(drinkIndex));
        }
    }
}
