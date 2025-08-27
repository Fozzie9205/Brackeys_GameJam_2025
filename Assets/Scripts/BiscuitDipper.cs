using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class BiscuitDipper : MonoBehaviour
{
    private ScoreManager scoreManager;
    private BiscuitManager bm;
    private DrinkManager dm;

    public Biscuit currentBiscuit;
    public Drink currentDrink;

    private float holdTime;
    private float pointsThisDip;

    public float baseIntegrity = 10f; //This is the base integrity of all biscuits
    private float currentIntegrity;

    private bool isDipping = false;

    public float baseRate; //This is the base points per second

    private void Awake()
    {
        bm = FindFirstObjectByType<BiscuitManager>();
        dm = FindFirstObjectByType<DrinkManager>();
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    void Update()
    {
        currentBiscuit = bm.currentBiscuit;
        currentDrink = dm.currentDrink;

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
        scoreManager.crumbs += Mathf.RoundToInt(pointsThisDip);
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
