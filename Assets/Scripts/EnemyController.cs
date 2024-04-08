using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    // Start is called before the first frame update
    private float maxSpeed = 10;
    private GameObject player;
    private NavMeshAgent enemy;
    private string STATE = "CHASE";
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = GetComponent<NavMeshAgent>(); 
        enemy.SetDestination(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    
    {
        // get the direction player is facing 
        Vector3 targetDir =  transform.position - player.transform.position;

        // returns the angle (from, to)
        float angleToUs= Vector3.Angle(targetDir, player.transform.forward);

        if(STATE == "IDLE")
        {
            if (angleToUs >= -70 && angleToUs<= 70)
            {
                 
            }else{
                STATE = "CHASE";
            }
            enemy.speed = 0;

        }else if(STATE == "STALK"){

            enemy.speed = 3;
        }else if(STATE == "CHASE"){
            enemy.SetDestination(player.transform.position);
            enemy.speed = 15;
           
            // when the angle is at -90 or +90, then it is in view (180º FOV)
            if (angleToUs >= -70 && angleToUs<= 70)
            {
                STATE = "IDLE";
            }
        }else if(STATE == "RUN"){

            
        }
       
    }
}
