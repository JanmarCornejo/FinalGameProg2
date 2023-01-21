using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        FindObjectOfType<SoundManager>().Play("ClickButton");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        FindObjectOfType<SoundManager>().Play("ClickButton");
        Application.Quit();
        Debug.Log("Exit Application.");
    }
}
