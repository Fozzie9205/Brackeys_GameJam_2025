using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public void WinScreen()
    {
        AudioManager.Instance.Play("Positive");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
