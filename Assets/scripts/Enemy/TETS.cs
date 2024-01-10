using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TETS : MonoBehaviour
{
    private GameManager gameManager;
    private NavMeshAgent agent;
    public Transform player;
    public float sightRange = 10f;
    public float attackDistance = 5f;
    private Vector3 wanderTarget = Vector3.zero;
    private bool isWandering = false;
    private AnimationMascotte animationMascotte;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < sightRange)
        {
            if (distanceToPlayer < attackDistance)
            {
                //animationMascotte.MascotteAnimationKidnappe();
                Debug.Log("Attack Player");
                gameManager.ShowGameOverScreen();
            }
            else agent.SetDestination(player.position);
        }
        else
        {
            if (!isWandering)
            {
                StartCoroutine(Wander());
            }
        }
    }

    IEnumerator Wander()
    {
        isWandering = true;

        float wanderRadius = 10f;
        float wanderDistance = 10f;
        float wanderJitter = 1f;

        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter, 0, Random.Range(-1.0f, 1.0f) * wanderJitter);
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        Vector3 targetLocal = wanderTarget + new Vector3(0, 0, wanderDistance);
        Vector3 targetWorld = transform.TransformPoint(targetLocal);

        agent.SetDestination(targetWorld);

        // Attendre jusqu'à ce que l'ennemi atteigne le point cible
        while (Vector3.Distance(transform.position, targetWorld) > agent.stoppingDistance)
        {
            yield return null;
        }

        // Attendre pendant un certain temps après avoir atteint le point
        float waitTime = 3f; // Temps d'arrêt en secondes
        //animationMascotte.MascotteAnimationIdle();
        yield return new WaitForSeconds(waitTime);

        isWandering = false;
    }
}
