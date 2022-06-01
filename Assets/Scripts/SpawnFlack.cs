using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlack : MonoBehaviour
{
    private Rigidbody flack;
    //private float jumpForce = 1.0f;
    private Vector3 direcao;
    private float XZDestroy = 360.0f;
    private float YDestroy = 250.0f;

    // Start is called before the first frame update
    void Start()
    {
        flack = GetComponent<Rigidbody>();
        direcao = new Vector3((Random.Range(-50, 50)),
            transform.position.y + 100,(Random.Range(-50, 50))); ;
        flack.AddForce(direcao *0.25f, (ForceMode.Impulse));
        
    }

    // Update is called once per frame
    void Update()
    {
        //If para destrição do objeto caso caia fora do mapa.
        if (transform.position.z > XZDestroy || transform.position.z < -XZDestroy ||
            transform.position.x < -XZDestroy || transform.position.x > XZDestroy ||
            transform.position.y < 0 || transform.position.y > YDestroy)
        {
            Destroy(gameObject);
        }
    }

    

}
