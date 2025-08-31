using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class BiscuitDipper : MonoBehaviour
{
    private ScoreManager scoreManager;
    private BiscuitManager bm;
    private DrinkManager dm;
    private Win win;
    private FlashRed flashRed;

    public Biscuit currentBiscuit;
    public Drink currentDrink;

    private float holdTime;
    private float pointsThisDip;

    public TMP_Text instructionText;

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

    [Header("Drink Dip Points")]
    public Transform[] drinkDipPoints;
    private Drink lastDrink;
    private void Awake()
    {
        bm = FindFirstObjectByType<BiscuitManager>();
        dm = FindFirstObjectByType<DrinkManager>();
        scoreManager = FindFirstObjectByType<ScoreManager>();
        flashRed = GetComponent<FlashRed>();

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

        if (currentDrink != lastDrink)
        {
            int currentIndex = System.Array.IndexOf(dm.drinks, currentDrink);
            if (currentIndex >= 0 && currentIndex < drinkDipPoints.Length)
            {
                startPosition = drinkDipPoints[currentIndex].localPosition;
                targetPosition = startPosition;
            }

            lastDrink = currentDrink;
        }

        if (Input.GetMouseButtonDown(0))
        {
            instructionText.gameObject.SetActive(false);

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

    private void UpdateBiscuitPosition(int i)
    {
        Drink d = dm.drinks[i]; // however you're tracking current drink index
        if (i >= 0 && i < drinkDipPoints.Length)
        {
            startPosition = drinkDipPoints[i].localPosition;
        }
    }
    public void DipBiscuit()
    {
        AudioManager.Instance.Play("Dip");
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
            AudioManager.Instance.Play("Break");
            flashRed.Flash();
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
