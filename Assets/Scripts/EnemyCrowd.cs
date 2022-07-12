using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCrowd : MonoBehaviour
{
    private NavMeshAgent agent;

    private Player player;

    private GameObject enemySpawnPoint;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        agent = GetComponent<NavMeshAgent>();

        enemySpawnPoint = this.transform.parent.gameObject;
        agent.isStopped = true;
        agent.speed = 0;
    }

    private void Update()
    {
        agent.SetDestination(enemySpawnPoint.transform.position);

        if (Vector3.Distance(player.gameObject.transform.position, this.gameObject.transform.position) < 10.0f)
        {
            agent.isStopped = false;
            agent.speed = 3.5f;
            agent.SetDestination(player.gameObject.transform.position);
        }
    }
}
