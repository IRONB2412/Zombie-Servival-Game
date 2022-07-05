using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsMovement : MonoBehaviour
{

    public GameObject FpsPlayer;
    public CharacterController characterController;
    public float speed =0;
    public float WalkSpeed = 3f;
    public float RunSpeed = 5f;
    public bool isWalking = false;
    public bool isRuning = false;


    public Transform groundChek;
    public LayerMask groundMask;
    public float GroundDistance = 0.05f;
    public bool isGrounded;

    Vector3 velocity;
    public float gravity=20f;

    public float jumpHight;


    public AudioClip[] FootSteps;
    public AudioClip[] FootStepsOnGrass;
    public AudioSource audioSource;
    public AudioClip JumpSound;
    public AudioClip LandSound;
    public bool Jumping;


    public float NextStep;
    public float stepCycle;

    
    private void Start()
    {
        characterController = characterController.GetComponent<CharacterController>();
        stepCycle = 0f;
        NextStep = stepCycle / 2f;
    }

    void RunAndWalk()
    {
        if(Input.GetKey(KeyCode.LeftShift) )
        {
            speed = RunSpeed;
            
            isRuning= true;
            isWalking= false;
        }else
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A))
        {
            speed = WalkSpeed;
            
            isWalking= true;
            isRuning= false;
            
            
        }else
        {
            speed=0;
            
            isWalking = false;
            isRuning = false;
        }
       

    }

    void FixedUpdate()
    { 
        RunAndWalk();
       
        if(Input.GetButtonDown("Jump") &&isGrounded)
        {
            Jumping = true;
            velocity.y = Mathf.Sqrt(jumpHight * 2f *gravity  );
            
            PlayJumpSound();
            
        }
        isGrounded = Physics.CheckSphere(groundChek.position, GroundDistance, groundMask);
        if(isGrounded && velocity.y<=0)
        {
            velocity.y = -1.5f;
        }

        
        
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");
        Vector3 move=transform.right*X+transform.forward*Z;
        velocity.y-=gravity*Time.deltaTime;
        characterController.Move(velocity*Time.deltaTime);
        characterController.Move(speed * move * Time.deltaTime);

        if(characterController.velocity.sqrMagnitude>0 && (X!=0 || Z!=0)&&Jumping==false)
        {
            stepCycle += (characterController.velocity.magnitude + (speed))* Time.deltaTime;
        }
        if(!(stepCycle>NextStep))
        {
            return;           
        }
        NextStep = stepCycle + speed;
        playAudioFootStep();
        
       
    }
    void playAudioFootStep()
    {

        if(!isGrounded)
        {
            return ;
        }


        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit GroundTag, 2f))
        {
            
            switch (GroundTag.collider.tag)
            {
                
                case "GrassGround":
                    int n = Random.Range(0, FootStepsOnGrass.Length);
                    audioSource.clip = FootStepsOnGrass[n];
                    audioSource.PlayOneShot(audioSource.clip);
                    // move picked sound to index 0 so it's not picked next time
                  /*  FootSteps[n] = FootSteps[0];
                    FootSteps[0] = audioSource.clip;*/
                    break;
                case "Ground":

                    int m = Random.Range(0, FootSteps.Length);
                    audioSource.clip = FootSteps[m];
                    audioSource.PlayOneShot(audioSource.clip);
                    // move picked sound to index 0 so it's not picked next time
                   /* FootSteps[m] = FootSteps[0];
                    FootSteps[0] = audioSource.clip;*/
                    break ;
                default:
                    break;
            }
        }
        
        

    }
    void PlayJumpSound()
    {
        audioSource.clip = JumpSound;
        audioSource.Play(); 
        chakeforGrounded();
    }
    void chakeforGrounded()
    {
        if(isGrounded)
        {
            Jumping = false;
        }
    }


}
