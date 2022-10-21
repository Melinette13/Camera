using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{

    
    

    Vector3 PlayerPosition;
    public GameObject player; 
    public float PosZ; 
    public bool FollowPlayer;
    public float MaxY; 
    public float MinY;
    public float ValY;
    public float MedY;
    public float BasVal;
    public float MedBasVal;
    public float offest; 
    




    private void Start()
    {
        PosZ = transform.position.z;
    }
     void FixedUpdate()
    {
        if (FollowPlayer)
        {
            if (ValY<= MinY)
            {
                ValY = MinY;
            }
            
        
         else
         {
            if (ValY >= MaxY)
            {
                ValY = MaxY;
            }
            else
            {
                ValY = player.transform.position.y;
            }
          }

        if (player.GetComponent<CharacterController2D>().RightOrLeft == false)
        {
            PlayerPosition = new Vector3(player.transform.position.x + BasVal, ValY, PosZ - offest);
        }
        else
        {
            PlayerPosition = new Vector3(player.transform.position.x - BasVal, ValY, PosZ - offest);
        }

        transform.position = Vector3.Lerp(transform.position, PlayerPosition, Time.deltaTime);
       }
        else
        {

            ValY = MedY;

            if (player.GetComponent<CharacterController2D>().RightOrLeft == false)
            {
                PlayerPosition = new Vector3(player.transform.position.x + MedBasVal, ValY, PosZ - offest);
            }
            else
            {
                PlayerPosition = new Vector3(player.transform.position.x - MedBasVal, ValY, PosZ - offest);
            }

            transform.position = Vector3.Lerp(transform.position, PlayerPosition, Time.deltaTime );
        }
    }
    

}



