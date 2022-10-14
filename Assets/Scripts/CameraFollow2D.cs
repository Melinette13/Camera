using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{

    public GameObject player; 
 
    float depth=5f;
    float verticalOffset = 1f;
    public float horizontalOffset = 2f;

  
    
    private void Update()
    {
        Vector3 Offest = new Vector3(depth, verticalOffset, horizontalOffset);
        transform.position = player.transform.position + Offest;
    }


}
