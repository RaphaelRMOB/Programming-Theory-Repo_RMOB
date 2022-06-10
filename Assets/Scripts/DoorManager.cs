using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public PlayerController playerController;
    public int gemCount;
    public Vector3 portalAberto; 

    // Start is called before the first frame update
    void Start()
    {
        // Pegamos a posição atual das barras e usamos para criar uma posição de destino.
        // posição atual da barra meno 8 no Y.
        portalAberto.y = transform.position.y - 9;

    }

    // Update is called once per frame
    void Update()
    {
        gemCount = playerController.gemCount;

        if (gemCount == 3)
        {
            //Chama função para baixaras barras. 
            OpenGate();


        }
    }

    void OpenGate()
    {
        if (transform.position.y > portalAberto.y) 
        {
            transform.Translate(Time.deltaTime * Vector3.down);
        }
        
    }


}
