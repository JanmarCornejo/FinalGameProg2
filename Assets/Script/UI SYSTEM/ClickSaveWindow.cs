using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSaveWindow : MonoBehaviour
{
    [SerializeField] private SaveWindow mySaveWindow;
    [SerializeField] private Crosshair crosshair;

    public Camera playerCamera;

    public static bool isPaused;

    void Update()
    {
        InteractSave();
    }

    /*
    void OnMouseDown() 
    {

        if (!isPaused )
        {
            PauseGame();
            Debug.Log("Opened Save Window.");
        }

    }
    */

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

    void OpenSaveWindow()
    {
        if (!isPaused)
        {
            PauseGame();
            Debug.Log("Opened Save Window.");
        }
    }

    private void InteractSave()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, 3))
        {
            if (hit.transform.CompareTag("Computer"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    OpenSaveWindow();
                }
            }
        }
    }
}
