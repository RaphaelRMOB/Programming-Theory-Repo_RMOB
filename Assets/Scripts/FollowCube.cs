using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCube : MonoBehaviour
{
    public GameObject player;
    //private Vector3 offset = new Vector3(0, 5, -7);

    // public Transform targetObject;

    // Distancia entre a camera e o player.
    //public Vector3 cameraOffset;

    //Será usado na rotação da camera.
    //public float smoothFactor = 0.5f;

    //public float cameraDistance = 10.0f;



   // private Vector3 offset;

    public float speed = 5;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //posicionamos a camera acima do CUBO.
        //transform.position = player.transform.position + offset;



        /*
                transform.position = player.transform.position - player.transform.forward * cameraDistance;
                transform.LookAt(player.transform.position);
                transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z -7);
        
        */


        // Look
        var newRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, speed * Time.deltaTime);

        // Move
        Vector3 newPosition = player.transform.position - player.transform.forward * offset.z - player.transform.up * offset.y;
        transform.position = Vector3.Slerp(transform.position, newPosition, Time.deltaTime * speed);


    }
    
}
