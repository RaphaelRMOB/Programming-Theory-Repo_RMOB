using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawn : MonoBehaviour
{
    // variaveis para destruir o objeto caso ele saia do mapa.
    private float XZDestroy = 360.0f;
    private float YDestroy = 250.0f;
    private float startDelay = 2;
    private float spawnInterval = 0.5f;

    public GameObject projectilePrefab;
    private GameObject player;
    public bool Stun;
    //public bool PlayerP; //haspowerUp

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("CUBE");
        Stun = false;
        InvokeRepeating("SpawnFlack", startDelay, spawnInterval);

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

    void SpawnFlack()
    {
        if (Stun == false)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Stun = true;
        }
    }

}
