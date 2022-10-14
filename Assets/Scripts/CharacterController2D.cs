using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float speed;
    public float DashSpeed = 35f;
    public float NormalSpeed = 5f;

    public float jumpAmount = 5.0f;

    public bool isOnGround = true;

    private float horizontalInput;

    private float fowardInput;

    private Rigidbody playerRb;



    void Start()

    {

        playerRb = GetComponent<Rigidbody>();

    }





    void Update()

    {

        // get player input 

        horizontalInput = Input.GetAxis("Horizontal");


        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = DashSpeed;
            print("Running");
        }
        else
        {
            speed = NormalSpeed;

        }


        // Move the player foward



        transform.Translate(Vector3.forward * Time.deltaTime * speed * horizontalInput);



        // Let the player jump 

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)

        {

            playerRb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);

            isOnGround = false;

        }

    }

    private void OnCollisionEnter(Collision collision)

    {

        if (collision.gameObject.CompareTag("Ground"))

        {

            isOnGround = true;

        }

    }
}
