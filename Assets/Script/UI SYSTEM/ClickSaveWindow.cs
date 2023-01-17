using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSaveWindow : MonoBehaviour
{
    [SerializeField] private SaveWindow mySaveWindow;

    public static bool isPaused;

    void OnMouseDown() // Save Window Popup when clicking the computer
    {

        if (!isPaused )
        {
            Cursor.visible = true;
            PauseGame();
            Debug.Log("Opened Save Window.");
        }

    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        mySaveWindow.gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void YesClicked()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mySaveWindow.gameObject.SetActive(false);
        Debug.Log("Save Progress.");
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void NoClicked()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mySaveWindow.gameObject.SetActive(false);
        Debug.Log("Closed Save Window.");
        Time.timeScale = 1f;
        isPaused = false;
    }
}
