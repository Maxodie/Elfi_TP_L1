﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Camera cam;
    CharacterController characterController;
    float maxSpeed = 10, acceleration = 10, jumpForce = 5;
    float speed, verticalMovement;
    Vector3 direction, directionForward, directionRight, nextDir;
    Animator animator;
    
    public CheckTerrainTextures checkTerrainTextures;
    public DoorScript doorScript;

    public AudioSource audioSource;
    
    [SerializeField]
    public AudioClip[] gravelStep;
    public AudioClip[] grassStep;
    public AudioClip[] stoneStep;
    

    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
        direction = transform.forward;
        nextDir = transform.forward;
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        gravity();

        Move();


        //apply the calculated movement to the character controller movement system
        characterController.Move((direction * speed + verticalMovement * Vector3.up) * Time.deltaTime);

        animator.SetFloat("Speed", speed / maxSpeed);
    }

    private void Move()
    {
        if ((Input.GetAxisRaw("Vertical")) != 0 || (Input.GetAxisRaw("Horizontal")) != 0)
        {
            //gets the inputs from keyboard arrows and defines the direction depending on the camera's orientation;

            directionForward = cam.transform.forward;
            directionForward.y = 0;
            directionForward *= Input.GetAxisRaw("Vertical");

            directionRight = cam.transform.right;
            directionRight.y = 0;
            directionRight *= Input.GetAxisRaw("Horizontal");

            nextDir = Vector3.Normalize(directionForward + directionRight);

            //Direction interpolation between the current direction and the inputed direction
            direction = Vector3.Lerp(direction, nextDir, Time.deltaTime * 2);

            //Calculate the speed increasement depending on the time spent pushing an arrow button;

            if (speed < maxSpeed)
            {
                speed += acceleration * Time.deltaTime;
            }
            else
            {
                speed = maxSpeed;
            }

        }
        else
        {
            //Calculate the speed decreasement depending on the time since no arrow button is pressed;

            if (speed != 0)
            {
                if (speed <= 2 * acceleration * Time.deltaTime)
                    speed = 0;
                else
                {
                    speed -= 2 * acceleration * Time.deltaTime;
                }
            }
        }

        //make the object rotate toward its movement;
        transform.rotation = Quaternion.LookRotation(direction, transform.up);
    }

    private void gravity()
    {
        if (verticalMovement <= 0 && characterController.isGrounded)
        {
            verticalMovement = -5;
        }
        else
        {
            verticalMovement -= jumpForce * 2 * Time.deltaTime;
        }
    }

    // Fonction appelée lors de chaque pas grâce à un animation event intégré dans le cycle de marche du personnage
    public void StepSound()
    {
        checkTerrainTextures.GetTerrainTextures();
        if (!doorScript.isEnteredMansion)
        {
            if (checkTerrainTextures.texturesValues[0] > 0)
            {
                audioSource.PlayOneShot(grassStep[Random.Range(0,5)]);
            }
            if (checkTerrainTextures.texturesValues[2] > 0)
            {
                audioSource.PlayOneShot(gravelStep[Random.Range(0,5)]);
            }
        }
        else
        {
            audioSource.PlayOneShot(stoneStep[Random.Range(0,5)]);
        }
        
    }
}
