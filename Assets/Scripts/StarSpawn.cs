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

    private Vector3 scaleChange; // Variavel para criar o efeito de "encolhimento" do inimigo.
    private bool shrinkage =  false; // Variavel que liga e desliga o encolhimento.

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("CUBE");
        Stun = false;
        InvokeRepeating("SpawnFlack", startDelay, spawnInterval);
        scaleChange = new Vector3(-0.05f, -0.05f, -0.05f);

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

        if (shrinkage == true)
        {
            
            transform.localScale += scaleChange;
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
            shrinkage = true;
            Dying();
        }
    }

    
    IEnumerator Dying()
    {
        //Cria um contador(em segundos). depois faz a linha de comando.
        yield return new WaitForSeconds(10);
        Destroy(this);

    }

}
