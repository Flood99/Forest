using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    // Start is called before the first frame update
    private GameObject player;
    private NavMeshAgent enemy;
    private Vector3 offset;
    private GameManager gameManager;
    private string STATE = "STALK";
    private bool playerLooking = false;
    private float acceleration = 10;
    private float deceleration = 60;
    private AudioSource audioSource;
    public AudioClip[] ambushSounds;
    public AudioClip neckSnap;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = GetComponent<NavMeshAgent>(); 
        audioSource = GetComponent<AudioSource>();
        offset = new Vector3(Random.Range(20,50),0,Random.Range(20,50));
        enemy.SetDestination(player.transform.position + offset);
        StartCoroutine(StalkTimers());
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    
    {
        // get the direction player is facing 
        Vector3 targetDir =  transform.position - player.transform.position;
        // returns the angle (from, to)
        float angleToUs= Vector3.Angle(targetDir, player.transform.forward);
        //check if player is looking then set variable
        if (angleToUs >= -70 && angleToUs<= 70)
        {
            if(playerLooking == false) Debug.Log("Player is looking at me >:(");
            playerLooking = true;
            
        }else{
            playerLooking = false;
        }
        //make enemy stop instantly when looked at
        if(enemy.speed == 0)
        {
            enemy.acceleration = deceleration;
        }else
        {
            enemy.acceleration = acceleration;
        }
       

        if(STATE == "IDLE")
        {
            if(playerLooking == false)
            {
                STATE = "CHASE";
                

            }
            enemy.speed = 0;

        }else if(STATE == "STALK")
        {
            enemy.SetDestination(player.transform.position + offset);
            if(playerLooking == false) enemy.speed = 10;
            if(playerLooking == true) enemy.speed = 0;

            
            

        }else if(STATE == "CHASE")
        {
            enemy.SetDestination(player.transform.position);
            enemy.speed = 15;
            Debug.Log("Chasing");
            
            if (playerLooking == true)
            {
                STATE = "IDLE";
                
                
            }
        }else if(STATE == "RUN")
        {
            enemy.speed = 10;
            offset = new Vector3(Random.Range(50,150),0,Random.Range(50,150));
            enemy.SetDestination(player.transform.position + offset);
            
        }
       
    }
    IEnumerator StalkTimers()
    {
        if(STATE == "STALK")
        {
            yield return new WaitForSeconds(Random.Range(10,20));
            int i = Random.Range(1, 11);
            Debug.Log(i);
            if (i < 10)
            {
                STATE = "CHASE";
                audioSource.PlayOneShot(ambushSounds[Random.Range(0,ambushSounds.Length)]);
                Debug.Log("Time to Run");
            }
        }
        if(STATE == "STALK")
        {
            yield return new WaitForSeconds(Random.Range(10,20));
            offset = new Vector3(Random.Range(20,50),0,Random.Range(20,50));
            enemy.SetDestination(player.transform.position + offset);
            
        }
    }
    public void Kill()
    {
        audioSource.PlayOneShot(neckSnap);  
        gameManager.EndGame();

    }
}   
