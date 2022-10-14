using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{

    public GameObject player;

    Vector3 PlayerPosition; 
    public float PosZ; 
    public bool FollowPlayer;
    public float MaxY; 
    public float MinY;
    public float ValY;
    public float BasVal; 
        
   



    private void Start()
    {
        PosZ = transform.position.z;
    }
     void FixedUpdate()
    {
        if (FollowPlayer)
        {
            ValY = MinY;
        }
        if (player.GetComponent<CharacterController2D>().RightOrLeft == false)
        {
            PlayerPosition = new Vector3(player.transform.position.x + BasVal, ValY, PosZ);
        }
        else
        {
            PlayerPosition = new Vector3(player.transform.position.x - BasVal, ValY, PosZ);
        }

        transform.position = Vector3.Lerp(transform.position, PlayerPosition, Time.deltaTime);

    }

}



