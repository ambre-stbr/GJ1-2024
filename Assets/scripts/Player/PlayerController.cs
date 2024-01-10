using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    [SerializeField] private float speed = 5.0f;

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
        Debug.Log("OnMove !");
    }

    void Update()
    {
        // Convertit le mouvement en direction relative à la rotation du joueur
        Vector3 move = transform.right * movement.x + transform.forward * movement.y;

        // Applique le mouvement sans changer la hauteur (axe Y)
        transform.Translate(move * speed * Time.deltaTime, Space.World);

    }
}
