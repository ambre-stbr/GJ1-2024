using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemy : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 lastPosition;
    private Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
    }

    // Start is called before the first frame update
    void Update()
    {
        Vector3 deltaPosition = transform.position - lastPosition;
        velocity = deltaPosition / Time.deltaTime;

        lastPosition = transform.position;

        if (velocity.magnitude >= 0.1)
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
    }

    public void MascotteAnimationAttack()
    {
        animator.SetTrigger("attack");

        //Debug.Log("MascotteAnimationAttack !");
    }
}