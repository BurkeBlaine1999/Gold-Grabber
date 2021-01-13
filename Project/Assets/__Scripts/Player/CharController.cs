using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    //Variables

    public float movementSpeed = 50.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 28.0f;//14

    private float jumpForce = 20.0f;//15
    private Vector3 moveVector;

    private CharacterController controller;

    private float animationDuration = 3.0f;
    private float startTime;

    private bool isDead = false;

    bool keepPlaying = true;
    private int randomIndex;

    //Audio variables
    public AudioSource audioSource;
    public AudioClip rightStep;
    public AudioClip leftStep;
    public AudioClip deathSound;
    public AudioClip[] JumpSFX;
    public AudioClip[] ladderSound;

    [SerializeField]private GameObject MainCamera;
    [SerializeField]private GameObject FPSCamera;
    private bool timer = false;

    void Start()
    {
        float time = Time.time;
        controller = GetComponent<CharacterController>();
        startTime = Time.time;//Get start time for the start animation
        StartCoroutine(RunningSFX());
        MainCamera.SetActive(true);
        FPSCamera.SetActive(false);
    }

    void Update()
    {   


        if (isDead)
            return;

        if (Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward * movementSpeed * Time.deltaTime);
            return; // Stops the movement on the x axis until animation is over;
        }
        
        if(Input.GetKeyDown(KeyCode.E)){
            if(MainCamera.activeSelf){
                MainCamera.SetActive(false);
                FPSCamera.SetActive(true);
            }else{
                MainCamera.SetActive(true);
                FPSCamera.SetActive(false);
            }
        }
        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            //if grounded , reduce gravity
            verticalVelocity = -gravity * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {   //Jump and play a random jump sound 
                randomIndex = Random.Range(0, JumpSFX.Length);
                audioSource.PlayOneShot(JumpSFX[randomIndex]);
                verticalVelocity = jumpForce;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {   //Jump and play a random jump sound 
                randomIndex = Random.Range(0, JumpSFX.Length);
                audioSource.PlayOneShot(JumpSFX[randomIndex]);
                verticalVelocity = -jumpForce;
            }
            else
            {
                verticalVelocity -= gravity * Time.deltaTime;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        //X -- Left and right
        moveVector.x = Input.GetAxisRaw("Horizontal") * movementSpeed;

        //Y -- Jump 
        moveVector.y = verticalVelocity;

        //Z -- Speed
        moveVector.z = movementSpeed;

        controller.Move(moveVector * Time.deltaTime);
    }

    //Set the players new movement speed
    public void SetSpeed(float modifier)
    {
        movementSpeed += modifier * 2;
    }

    //If hit...
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //If you hit an obstacle , you die
        if (hit.gameObject.tag == "Obstacle")
        {
            Death();
        }

        //If you hit a bomb , you die
        else if (hit.gameObject.tag == "Bomb")
        {
            Death();
            Debug.Log(" You are dead :( ");
        }
        //If you hit a ladder , you will climb it
        else if (hit.gameObject.tag == "Ladder")
        {
            randomIndex = Random.Range(0, 2);
            audioSource.PlayOneShot(ladderSound[randomIndex]);
            controller.Move(Vector3.up * 0.06f);
        }
    }

    //Play death sound and pop up the death menu
    private void Death()
    {
        audioSource.PlayOneShot(deathSound);
        keepPlaying = false;
        isDead = true;
        GetComponent<Score>().OnDeath();
    }

    //Keeps the running sfx playing for the player
    IEnumerator RunningSFX()
    {
        while (keepPlaying)
        {
            Debug.Log("Sound Playing");
            yield return new WaitForSeconds(0.4f);
            audioSource.PlayOneShot(rightStep);
            yield return new WaitForSeconds(0.4f);
            audioSource.PlayOneShot(leftStep);
        }
    }

}
