using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashRed : MonoBehaviour
{
    private SpriteRenderer sr;

    private Color originalColor;

    private float timer = 0f;
    public float fadeDuration = 0.5f;

    private bool isFlashing = false;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            originalColor = sr.color;
        }
    }

    private void Update()
    {
        if (!isFlashing) return;

        timer += Time.deltaTime;
        
        sr.color = Color.Lerp(Color.red, originalColor, timer / fadeDuration);

        if (timer >= fadeDuration)
        {
            sr.color = originalColor;
            isFlashing = false;
            timer = 0f;
        }
    }

    public void Flash()
    {
        if (sr == null) return;

        sr.color = Color.red;
        timer = 0f;
        isFlashing = true;
    }
}
