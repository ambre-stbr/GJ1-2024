using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float sprintSpeed = 10.0f;
    [SerializeField] private float sprintDuration = 5.0f;
    [SerializeField] private float sprintCooldown = 5.0f;
    private float sprintTimeRemaining;
    private float sprintCooldownRemaining;
    private bool isSprinting = false;

    void Start()
    {
        sprintTimeRemaining = sprintDuration;
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
        if (sprintCooldownRemaining > 0)
        {
            sprintCooldownRemaining -= Time.deltaTime;
            return;
        }

        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && sprintTimeRemaining > 0)
        {
            isSprinting = true;
            sprintTimeRemaining -= Time.deltaTime;
        }
        else if (isSprinting)
        {
            isSprinting = false;
            sprintCooldownRemaining = sprintCooldown;
            sprintTimeRemaining = sprintDuration;
        }
    }

}
