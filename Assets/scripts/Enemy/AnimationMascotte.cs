using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMascotte : MonoBehaviour
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

        if (velocity.magnitude <= 0.2)
        {
            MascotteAnimationIdle();
        }
        else
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Idle2", false);

        }
    }

    public void MascotteAnimationKidnappe()
    {
        animator.SetTrigger("Kidnappe");

        Debug.Log("MascotteAnimationKidnappe !");
    }
    public void MascotteAnimationIdle()
    {
        float n = Random.Range(-1, 1);
        if (n >= 0) { animator.SetBool("Idle", true); }
        else animator.SetBool("Idle2", true);

        Debug.Log("MascotteAnimationIdle !");
    }

}