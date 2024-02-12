using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; 
    public float speed = 5;
    public float jumpHeight = 3f;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public AudioClip[] walkSounds;
    public float timeBetweenSteps = 1f;

    public float gravity = -9.81f;
    // Start is called before the first frame update

    Vector3 velocity;
    bool isGrounded;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if(Input.GetButtonDown("Jump")&& isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2* gravity);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        velocity.y += gravity*Time.deltaTime;
        if(isGrounded)
        {
            if(x!=0||z!=0)
            {
                timeBetweenSteps -=1 * Time.deltaTime;
            }
        }
        if(timeBetweenSteps <= 0)
        {
            Debug.Log("Step");
            timeBetweenSteps = 1f;
        }

        Vector3 move = transform.right * x + transform.forward*z ;
        controller.Move(move*speed*Time.deltaTime);
        controller.Move(velocity*Time.deltaTime);
        Debug.Log(timeBetweenSteps);
    }
}
