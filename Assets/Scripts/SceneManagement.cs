using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void Play()
    {
        AudioManager.Instance.Play("Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Menu()
    {
        AudioManager.Instance.Play("Click");
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        AudioManager.Instance.Play("Click");
        Application.Quit();
    }
}
