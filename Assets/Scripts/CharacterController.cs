using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;
    public float DashSpeed = 35f;
    public float NormalSpeed = 5f;

    public float jumpAmount = 5.0f;


    public bool isOnGround = true;

    private float horizontalInput;

    private float fowardInput;

    private Rigidbody playerRb;

    public CinemachineVirtualCamera cam;
    



    void Start()

    {

        playerRb = GetComponent<Rigidbody>();
        cam.GetComponent<CinemachineFollowZoom>();
    }





    void Update()

    {

        // get player input 

        horizontalInput = Input.GetAxis("Horizontal");

        fowardInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
           
            speed = DashSpeed;
            print("Running");
            cam.GetComponent<CinemachineFollowZoom>().m_Width = 3; 


        }
        else
        {
            speed = NormalSpeed;
            cam.GetComponent<CinemachineFollowZoom>().m_Width = 10;
        }


        // Move the player foward

        transform.Translate(Vector3.forward * Time.deltaTime * speed * fowardInput);

        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);



        // Let the player jump 

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)

        {

            playerRb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);

            isOnGround = false;

        }

    }

     void OnCollisionEnter(Collision collision) 
        {
            if (collision.gameObject.CompareTag("Ground"))

            {

                isOnGround = true;

            }
        }

        

    

}

