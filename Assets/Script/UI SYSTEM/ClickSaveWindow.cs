using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSaveWindow : MonoBehaviour
{
    [SerializeField] private SaveWindow mySaveWindow;
    [SerializeField] private Crosshair crosshair;

    public static bool isPaused;

    void OnMouseDown() 
    {

        if (!isPaused )
        {
            PauseGame();
            Debug.Log("Opened Save Window.");
        }

    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        crosshair.gameObject.SetActive(false);
        mySaveWindow.gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void YesClicked()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        crosshair.gameObject.SetActive(true);
        mySaveWindow.gameObject.SetActive(false);
        Debug.Log("Save Progress.");
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void NoClicked()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        crosshair.gameObject.SetActive(true);
        mySaveWindow.gameObject.SetActive(false);
        Debug.Log("Closed Save Window.");
        Time.timeScale = 1f;
        isPaused = false;
    }
}
