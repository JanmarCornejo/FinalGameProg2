using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{



    public bool CanMove { get; private set; } = true;
    private bool IsSprinting => canSprint && Input.GetKey(sprintKey);

    [Header("Function Options")]
    [SerializeField] private bool canSprint = true;
    [SerializeField] private bool canHeadBob = true;
    [SerializeField] private bool useFootsteps = true;
    [SerializeField] private bool useStamina = true;

    [Header("Controls")]
    [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Movement Parameters")]
    [SerializeField] private float WalkSpeed = 3.0f;
    [SerializeField] private float SprintSpeed = 6.0f;
    [SerializeField] private float Gravity = 30.0f;

    [Header("Look Parameters")]
    [SerializeField, Range(1, 10)] private float LookSpeedX = 2.0f;
    [SerializeField, Range(1, 10)] private float LookSpeedY = 2.0f;
    [SerializeField, Range(1, 180)] private float UpperLookLimit = 80.0f;
    [SerializeField, Range(1, 180)] private float LowerLookLimit = 80.0f;


    [Header("Stamina Parameters")]
    [SerializeField] private float maxStamina = 100;
    [SerializeField] private float staminaDrain = 5;
    [SerializeField] private float timeBeforeStart = 5;
    [SerializeField] private float staminaRegenValue = 2;
    [SerializeField] private float staminaRegenTime = 0.1f;
    private float currentStamina;
    private Coroutine regeneratingStamina;

    [Header("Headbob Parameters")]
    [SerializeField] private float walkBobSpeed = 14f;
    [SerializeField] private float walkBobAmount = 0.05f;
    [SerializeField] private float SprintBobSpeed = 18f;
    [SerializeField] private float SprintBobAmount = 0.11f;
    private float defaultYPos = 0;
    private float timer = 20;

    [Header("Footstep Parameters")]
    [SerializeField] private float baseStepSpeed = 0.1f;
    [SerializeField] private float SprintStepMultiplier = 0.5f;
    [SerializeField] private AudioSource footstepAudioSource = default;
    [SerializeField] private AudioClip[] WalkClips = default;
    private float footstepTimer = 0;
    private float GetCurrentOffset => IsSprinting ? baseStepSpeed * SprintStepMultiplier : baseStepSpeed;

    private Camera playerCamera;
    private CharacterController CharacCtrl;

    private Vector3 MoveDir;
    private Vector2 CurrentInput;

    private float rotationX = 0;


    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        CharacCtrl = GetComponent<CharacterController>();
        defaultYPos = playerCamera.transform.localPosition.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (CanMove)
        {
            MovementInput();

            if (!ClickSaveWindow.isPaused && !OpenInventory.isOpened) // Camera Movement stopped when opening windows
            {
                MouseLook();
            }
            
            //Interact();
            MouseLook();
            ApplyMovement();

            if (canHeadBob)
                HandleHeadBob();

            if (useFootsteps)
                HandleFootstep();

            if (useStamina)
                HandleStamina();
        }
    }

    // ***** PLAYER MOVEMENT *****

    private void MovementInput()
    {
        CurrentInput = new Vector2((IsSprinting ? SprintSpeed : WalkSpeed) * Input.GetAxis("Vertical"), (IsSprinting ? SprintSpeed : WalkSpeed) * Input.GetAxis("Horizontal"));

        float moveDirectionY = MoveDir.y;
        MoveDir = (transform.TransformDirection(Vector3.forward) * CurrentInput.x) + (transform.TransformDirection(Vector3.right) * CurrentInput.y);
        MoveDir.y = moveDirectionY;
    }

    // ***** PLAYER LOOK *****

    private void MouseLook()
    {
        rotationX -= Input.GetAxis("Mouse Y") * LookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -UpperLookLimit, LowerLookLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * LookSpeedX, 0);
    }

    // ***** PLAYER HEADBOB *****

    private void HandleHeadBob()
    {
        if (!CharacCtrl.isGrounded) return;

        if (Mathf.Abs(MoveDir.x) > 0.1f || Mathf.Abs(MoveDir.z) > 0.1f)
        {
            timer += Time.deltaTime * (IsSprinting ? SprintBobSpeed : walkBobSpeed);
            playerCamera.transform.localPosition = new Vector3(
                playerCamera.transform.localPosition.x,
                defaultYPos + Mathf.Sin(timer)* (IsSprinting ? SprintBobAmount : walkBobAmount),
                playerCamera.transform.localPosition.z);
        }
    }

    // ***** PLAYER STAMINA *****

    private void HandleStamina()
    {
        if(IsSprinting && CurrentInput != Vector2.zero)
        {
            if(regeneratingStamina != null)
            {
                StopCoroutine(regeneratingStamina);
                regeneratingStamina = null;
            }

            currentStamina -= staminaDrain * Time.deltaTime;

            if (currentStamina < 0)
                currentStamina = 0;
            if (currentStamina <= 0)
                canSprint = false;
        }
        if(!IsSprinting && currentStamina < maxStamina && regeneratingStamina == null)
        {
            regeneratingStamina = StartCoroutine(RegenStamina());
        }
    }
    
    // ***** PLAYER FOOTSTEP SOUNDS *****

    private void HandleFootstep()
    {
        if (!CharacCtrl.isGrounded) return;
        if (CurrentInput == Vector2.zero) return;

        footstepTimer -= Time.deltaTime;

        if(footstepTimer <= 0)
        {
            if(Physics.Raycast(playerCamera.transform.position, Vector3.down, out RaycastHit hit, 3))
            {
                switch (hit.collider.tag)
                {
                    default:
                        footstepAudioSource.PlayOneShot(WalkClips[Random.Range(0, WalkClips.Length - 1)]);
                        break;
                }
            }

            footstepTimer = GetCurrentOffset;
        }
    }

    // ***** Interact *****
    /*
    private void Interact()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, 3))
        {
            if (hit.transform.CompareTag("KeyCard"))
            {
                if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.F))
                {
                    Debug.Log("KeyCard Obtained");
                }
            }           
        }
    }
    */
    
    // ***** PLAYER Check if can move *****

    private void ApplyMovement()
    {
        if (!CharacCtrl.isGrounded)
            MoveDir.y -= Gravity * Time.deltaTime;

        CharacCtrl.Move(MoveDir * Time.deltaTime);
    }

    // ***** Coroutines *****

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(timeBeforeStart);
        WaitForSeconds timeToWait = new WaitForSeconds(staminaRegenTime);

        while(currentStamina < maxStamina)
        {
            if (currentStamina > 0)
                canSprint = true;

            currentStamina += staminaRegenValue;

            if (currentStamina > maxStamina)
                currentStamina = maxStamina;

            yield return timeToWait;
        }

        regeneratingStamina = null;
    }
}
