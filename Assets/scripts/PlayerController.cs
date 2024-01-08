using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody rigidbody;

    [SerializeField]
    private float speed = 5.0f;
    private Vector3 movement;
    private Vector3 moveDirection;
    public Vector3 MoveDirection
    {
        get { return moveDirection; }
    }
    private float rotationSpeed = 50.0f;

    public bool isAlive = true;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isAlive)
        {
            moveDirection = new Vector3(movement.x, 0, movement.y).normalized * speed * Time.deltaTime;
            transform.Translate(moveDirection, Space.World);


            // Player rotation
            Vector3 mousePosition = Input.mousePosition;
            Vector3 lookAt = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y - transform.position.y));

            lookAt.y = transform.position.y;
            Vector3 direction = (lookAt - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }

    void OnMove(InputValue value)
    {
        if (isAlive)
        {
            movement = value.Get<Vector3>();
        }
    }
}
