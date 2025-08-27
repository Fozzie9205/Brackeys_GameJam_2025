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

    private float baseIntegrity = 10f; //This is the base integrity of all biscuits
    private float currentIntegrity;

    private bool isDipping = false;

    public float baseRate; //This is the base points per second

    void Start()
    {
        if (bm == null)
        {
            bm = FindFirstObjectByType<BiscuitManager>();
        }

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

        //Calculate score
        pointsThisDip += baseRate * biscuitScoreMult * drinkScoreMult * Time.deltaTime;

        float biscuitIntegrityMult = currentBiscuit.integrityMultiplier;
        float drinkSogginess = currentDrink.sogginess;

        //Integrity is lost over time
        currentIntegrity -= drinkSogginess * Time.deltaTime;

        if (currentIntegrity <= 0)
        {
            Debug.Log("Biscuit broke");
            Refresh();
        }
    }

    public void EndDip()
    {
        //Add points earned to crumbs counter
        bm.crumbs += Mathf.RoundToInt(pointsThisDip);
        Refresh();
    }

    public void Refresh()
    {
        //Reset values
        isDipping = false;
        holdTime = 0f;
        pointsThisDip = 0;
        currentIntegrity = baseIntegrity * currentBiscuit.integrityMultiplier;

    }
}
