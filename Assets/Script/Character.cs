using System.Collections;
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
    [SerializeField]
    AudioClip stepSound;
    public AudioSource source;

    public bool bruitPas = true;

    public AudioClip grassClip;
    public AudioClip dirtClip;
    public AudioClip grassdirtClip;
    public AudioClip cliffClip;
    public AudioClip sandClip;
    public AudioClip carrelageClip;
    public CheckTerrainTexture check;

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
        if (bruitPas)
        {
            check.GetTerrainTexture();
            if (check.textureValues[0] > 0)
            {
                source.PlayOneShot(grassClip, check.textureValues[0] / 7);
            }
            if (check.textureValues[1] > 0)
            {
                source.PlayOneShot(dirtClip, check.textureValues[1] / 7);
            }
            if (check.textureValues[2] > 0)
            {
                source.PlayOneShot(grassdirtClip, check.textureValues[2] / 7);
            }
            if (check.textureValues[3] > 0)
            {
                source.PlayOneShot(cliffClip, check.textureValues[3] / 7);
            }
            if (check.textureValues[4] > 0)
            {
                source.PlayOneShot(sandClip, check.textureValues[4] / 7);
            }
            if (check.textureValues[5] > 0)
            {
                source.PlayOneShot(carrelageClip, check.textureValues[5] / 56);
            }
        }
        else
        {
            source.PlayOneShot(carrelageClip, 0.01715686f);
        }


    }
}
