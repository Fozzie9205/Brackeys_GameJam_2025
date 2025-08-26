using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Drink
{
    public string name;
    public float scoreMultiplier = 1f;
    public float sogginess = 1f;
    public int price = 0;
    public bool unlocked = false;
}
