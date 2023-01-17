using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaController : MonoBehaviour
{
    [Header("Stamina Parameters")]
    [SerializeField] private float playerStamina = 50.0f;
    [HideInInspector] public bool hasRegenerated = true;
    [HideInInspector] public bool IsSprinting = true;
    [SerializeField] private float MaxStamina = 50.0f;
    [Range(0, 50)] [SerializeField] private float staminaDrain = 0.5f;
    [Range(0, 50)] [SerializeField] private float staminaRegen = 0.5f;

    private FirstPersonController playerController;

    void Start()
    {
        playerController = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        if (!IsSprinting)
        {
            if(playerStamina <= MaxStamina - 0.01)
            {
                playerStamina += staminaRegen * Time.deltaTime;
                

                if(playerStamina >= MaxStamina)
                {
                    hasRegenerated = true;
                }
            }
        }
    }

    void Sprinting()
    {
        if (hasRegenerated)
        {
            IsSprinting = true;
            playerStamina -= staminaDrain * Time.deltaTime;
            
            if(playerStamina <= 0)
            {
                hasRegenerated = false;
            }
        }
    }
}
