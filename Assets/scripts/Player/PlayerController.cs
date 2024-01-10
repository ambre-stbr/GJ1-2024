using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float sprintSpeed = 10.0f;
    [SerializeField] private float maxSprintDuration = 5.0f;
    [SerializeField] private float sprintRegenerationRate = 1.0f; // Régénère 1 seconde de sprint par seconde
    private float sprintDurationRemaining;
    private bool isSprinting = false;

    void Start()
    {
        sprintDurationRemaining = maxSprintDuration;
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    void Update()
    {
        HandleSprint();

        float currentSpeed = isSprinting ? sprintSpeed : speed;
        Vector3 move = transform.right * movement.x + transform.forward * movement.y;
        transform.Translate(move * currentSpeed * Time.deltaTime, Space.World);
    }

    void HandleSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if (sprintDurationRemaining > 0)
            {
                isSprinting = true;
                sprintDurationRemaining -= Time.deltaTime;
            }
            else
            {
                isSprinting = false; // Arrête de courir si le sprint est épuisé
            }
        }
        else
        {
            isSprinting = false;
            if (sprintDurationRemaining < maxSprintDuration)
            {
                sprintDurationRemaining += sprintRegenerationRate * Time.deltaTime;
            }
        }
    }
}
