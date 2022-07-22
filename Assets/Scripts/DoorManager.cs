//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorManager : MonoBehaviour
{
    public PlayerController playerController;
    public MenuManager menuManager;
    public string sceneName;
    
    public Vector3 portalAberto;
    Scene scene;

    // Variaveis relacionadas a contagem de gemas.
    int gemLeft;
    public int gemCount;
    


    // Start is called before the first frame update
    void Start()
    {
        // Pegamos a posição atual das barras e usamos para criar uma posição de destino.
        // posição atual da barra menos a quantidade nescessaria para esconde-la debaixo do solo.
        portalAberto.y = transform.position.y - 9;
        scene = SceneManager.GetActiveScene();
        if (scene.name == "SampleScene")
        {
            gemLeft = 3;
        }

    }

    // Update is called once per frame
    void Update()
    {
        gemCount = playerController.gemCount;
        

        if (gemCount >= gemLeft  /*& sceneName == "SampleScene"*/)
        {
            //Chama função para baixaras barras. 
            OpenGate();
            
            //Debug.Log("Active Scene is '" + scene.name + "'.");


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
