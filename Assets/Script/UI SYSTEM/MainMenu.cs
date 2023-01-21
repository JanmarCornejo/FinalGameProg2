using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        FindObjectOfType<SoundManager>().Play("ClickSFX");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGame()
    {
        FindObjectOfType<SoundManager>().Play("ClickSFX");
    }

    public void QuitGame()
    {
        FindObjectOfType<SoundManager>().Play("ClickSFX");
        Application.Quit();
        Debug.Log("Exit Application.");
    }
}
