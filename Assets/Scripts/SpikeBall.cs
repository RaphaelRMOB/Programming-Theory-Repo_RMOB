using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody enemyRB;
    private GameObject player;
    private GameObject SBType;
    string objectName;
    Vector3 relativePos = new Vector3(0.1405792f, 0, -30.1f);

    // variaveis para destruir o objeto caso ele saia do mapa.
    private float XZDestroy = 360.0f;
    private float YDestroy = 250.0f;


    // teste para fazer o objeto andar em circulos.
    float timeCounter = 0;
    float amplitude; // Diametro do trajeto.
    float frequency; //velocidade que o objeto anda.


    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("CUBE");
        objectName = gameObject.name;
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        amplitude = 80; 
        frequency = 0.5f; 

    }

    // Update is called once per frame
    void Update()
    { 
        
        if (objectName == "Enemy_SpikeBall")
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRB.AddForce(lookDirection * speed);
        }
        else if(objectName == "Enemy_SBRound")
        {  //Pode tentar fazer rodar em um ponto expecifico https://www.youtube.com/watch?v=7fdSYc8WElo
            timeCounter += Time.deltaTime;
            float x = Mathf.Cos(timeCounter * frequency) * amplitude;
            float y = transform.position.y;
            float z = Mathf.Sin(timeCounter * frequency) * amplitude;
            transform.position = new Vector3(x, y, z);

        }

        //If para destruição do objeto caso caia fora do mapa.
        if (transform.position.z > XZDestroy || transform.position.z < -XZDestroy || 
            transform.position.x < -XZDestroy || transform.position.x > XZDestroy ||
            transform.position.y < 0 || transform.position.y > YDestroy)
        {
            Destroy(gameObject);
        }
    }
}
