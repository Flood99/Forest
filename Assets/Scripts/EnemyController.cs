using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private NavMeshAgent enemy;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = GetComponent<NavMeshAgent>(); 
        enemy.SetDestination(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.transform.position);
    }
}
