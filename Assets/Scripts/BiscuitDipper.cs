using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class BiscuitDipper : MonoBehaviour
{
    public BiscuitManager bm;
    private Biscuit currentBiscuit;
    private Drink currentDrink;

    private float holdTime;
    private float pointsThisDip;

    private float baseIntegrity = 10f;
    private float currentIntegrity;

    private bool isDipping = false;

    public float baseRate;

    void Start()
    {
        currentBiscuit = bm.currentBiscuit;
        currentDrink = bm.currentDrink;

        Debug.Log("Current biscuit " + currentBiscuit.name);
        Debug.Log("Current drink " + currentDrink.name);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDipping = true;
            holdTime = 0f;
            pointsThisDip = 0f;
            currentIntegrity = baseIntegrity * currentBiscuit.integrityMultiplier;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isDipping = false;
            EndDip();
        }

        if (isDipping)
        {
            DipBiscuit();
        }

        Debug.Log(currentIntegrity);
    }

    public void DipBiscuit()
    {
        holdTime += Time.deltaTime;

        float biscuitScoreMult = currentBiscuit.scoreMultiplier;
        float drinkScoreMult = currentDrink.scoreMultiplier;

        pointsThisDip += baseRate * biscuitScoreMult * drinkScoreMult * Time.deltaTime;

        float biscuitIntegrityMult = currentBiscuit.integrityMultiplier;
        float drinkSogginess = currentDrink.sogginess;

        currentIntegrity -= drinkSogginess * Time.deltaTime;
        
        if (currentIntegrity <= 0)
        {
            Debug.Log("Biscuit broke");
            Refresh();
        }
    }

    public void EndDip()
    {
        bm.crumbs += Mathf.RoundToInt(pointsThisDip);
        Refresh();
    }

    public void Refresh()
    {
        isDipping = false;
        holdTime = 0f;
        pointsThisDip = 0;
        currentIntegrity = baseIntegrity * currentBiscuit.integrityMultiplier;

    }
}
