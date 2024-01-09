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
        
    }

    public void MascotteAnimationKidnappe()
    {
        animator.SetTrigger("Kidnappe");

        Debug.Log("MascotteAnimationKidnappe !");
    }
    public void MascotteAnimationIdle()
    {
        float n = Random.Range(-1, 1);
        if (n >= 0) {animator.SetTrigger("Idle");} 
        else  animator.SetTrigger("Idle2");

        Debug.Log("MascotteAnimationIdle !");
    }

}