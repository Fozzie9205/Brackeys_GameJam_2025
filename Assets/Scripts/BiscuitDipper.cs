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
    private Win win;

    public Biscuit currentBiscuit;
    public Drink currentDrink;

    private float holdTime;
    private float pointsThisDip;

    private BiscuitAnimationHandler biscuitAnimHandler;

    [Header("Integrity")]
    public float baseIntegrity = 10f; //This is the base integrity of all biscuits
    private float currentIntegrity;

    private bool isDipping = false;

    public float baseRate; //This is the base points per second

    [Header("Biscuit Movement")]
    public Transform biscuit;
    public float dipDepth = -0.5f;
    public float dipSpeed = 5f;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    private void Awake()
    {
        bm = FindFirstObjectByType<BiscuitManager>();
        dm = FindFirstObjectByType<DrinkManager>();
        scoreManager = FindFirstObjectByType<ScoreManager>();

        biscuit = gameObject.transform;
    }
    void Start()
    {
        startPosition = biscuit.localPosition;
        targetPosition = startPosition;
    }
    void Update()
    {
        currentBiscuit = bm.currentBiscuit;
        currentDrink = dm.currentDrink;

        if (Input.GetMouseButtonDown(0))
        {
            isDipping = true;
            holdTime = 0f;
            pointsThisDip = 0f;
            currentIntegrity = baseIntegrity * currentBiscuit.integrityMultiplier;

            //Start moving biscuit down
            targetPosition = startPosition + new Vector3(0f, dipDepth, 0f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDipping = false;
            EndDip();
        }

        if (isDipping)
        {
            DipBiscuit();
        }

        biscuit.localPosition = Vector3.Lerp(biscuit.localPosition, targetPosition, dipSpeed * Time.deltaTime);

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

        targetPosition = startPosition;
    }
}
