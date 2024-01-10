using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationMascotte : MonoBehaviour
{
    private GameManager gameManager;
    private NavMeshAgent agent;
    public Transform player;
    public float sightRange = 10f;
    public float attackDistance = 5f;
    private float timeToChangeDestination = 0;
    public float idleTime = 3;
    private AnimationMascotte animationMascotte;

    [System.Serializable]
    public struct PlayArea
    {
        public float minX;
        public float maxX;
        public float minZ;
        public float maxZ;
    }
    public PlayArea playArea;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Vérification constante de la proximité du joueur
        if (distanceToPlayer < sightRange)
        {
            agent.SetDestination(player.position);
            if (distanceToPlayer < attackDistance)
            {
                //animationMascotte.MascotteAnimationKidnappe();
                Debug.Log("Attack Player");
                gameManager.ShowGameOverScreen();
            }
        }
        else
        {
            // Logique de déplacement aléatoire
            if (timeToChangeDestination <= Time.time)
            {
                timeToChangeDestination = Time.time + idleTime;
                Vector3 randomPosition = RandomPositionInPlayArea();
                Debug.Log("randomPosition = " + randomPosition);
                if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
                {
                    agent.SetDestination(hit.position);
                    Debug.Log("SetDestination = " + randomPosition);
                }
                Debug.Log("timeToChangeDestination = " + timeToChangeDestination);
            }
        }

        Vector3 RandomPositionInPlayArea()
        {
            return new Vector3(
                Random.Range(playArea.minX, playArea.maxX),
                transform.position.y, // Gardez la hauteur actuelle de la mascotte
                Random.Range(playArea.minZ, playArea.maxZ)
            );
        }
    }
}
