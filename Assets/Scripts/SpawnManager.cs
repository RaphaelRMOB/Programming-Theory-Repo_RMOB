using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject BulletStarPrefab;
    public float startDelay = 1;
    public float repeatRate = 1;

    private Rigidbody bulletStarSpawn;

    private PlayerController playerControllerScript;

    private Vector3 starBull = new Vector3(41, 2, 035);
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("CUBE").GetComponent<PlayerController>();
        InvokeRepeating("SpawnStarBullet", startDelay, repeatRate);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnStarBullet()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(BulletStarPrefab, starBull, BulletStarPrefab.transform.rotation);
            //bulletStarSpawn.AddForce(focalPoint.transform.forward * verticalInput * 1300);
        }
    }
}
