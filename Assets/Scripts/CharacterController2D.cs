using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float speed;
    public float DashSpeed ;
    public float NormalSpeed;

    public float jumpAmount = 5.0f;

    public bool isOnGround = true;




    private Rigidbody playerRb;

    public bool RightOrLeft; 



    void Start()

    {

        playerRb = GetComponent<Rigidbody>();

    }





    void Update()

    {

        // get player input 

        ;


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
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            RightOrLeft = true; 
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(new Vector3(0, 90 ,0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RightOrLeft = false;
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }


        



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
