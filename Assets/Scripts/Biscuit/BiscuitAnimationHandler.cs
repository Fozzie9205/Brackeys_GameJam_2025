using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiscuitAnimationHandler : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void PlayBreakAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Break");
        }
    }
}
