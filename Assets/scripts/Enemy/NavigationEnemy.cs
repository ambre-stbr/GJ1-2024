using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationEnemy : MonoBehaviour
{
    private GameManager gameManager;
    private NavMeshAgent agent;
    public Transform player;
    [SerializeField] private float attackDistance = 5f;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer < attackDistance)
        {
            Debug.Log("distanceToPlayer < attackDistance !");
            gameManager.ShowGameOverScreen();

        }

    }
    /*    private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("OnCollisionEnter !");
            if (collision.gameObject.CompareTag("Player"))
            {
                gameManager.ShowGameOverScreen();

                Debug.Log("ShowGameOverScreen !");
            }
        }*/
}