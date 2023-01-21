using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickComputerWindow : MonoBehaviour
{
    [SerializeField] private ComputerWindow myComputerWindow;
    [SerializeField] private Crosshair crosshair;

    public Camera playerCamera;

    public static bool isOpen;

    void Update()
    {
        InteractComputer();
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        crosshair.gameObject.SetActive(false);
        myComputerWindow.gameObject.SetActive(true);
        Time.timeScale = 0f;
        isOpen = true;
    }

    public void CloseClicked()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        crosshair.gameObject.SetActive(true);
        myComputerWindow.gameObject.SetActive(false);
        Debug.Log("Closed Save Window.");
        Time.timeScale = 1f;
        isOpen = false;
    }

    void OpenComputerWindow()
    {
        if (!isOpen)
        {
            Pause();
            Debug.Log("Opened Save Window.");
        }
    }

    private void InteractComputer()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, 3))
        {
            if (hit.transform.CompareTag("Computer"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    OpenComputerWindow();
                }
            }
        }
    }
}
