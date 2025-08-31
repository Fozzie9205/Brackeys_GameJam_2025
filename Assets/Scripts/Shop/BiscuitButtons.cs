using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiscuitButtons : MonoBehaviour
{
    private BiscuitManager bm;

    private void Awake()
    {
        bm = FindFirstObjectByType<BiscuitManager>();
    }
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int biscuitIndex = i;
            Button btn = transform.GetChild(i).GetComponent<Button>();
            btn.onClick.AddListener(() =>
            {
                bm.UnlockBiscuit(biscuitIndex);
                AudioManager.Instance.Play("Click");
            });
        }
    }
}
