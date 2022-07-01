using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenu : MonoBehaviour
{
    //Criado um empty object para servir de referencia do local onde a camera irá parar.
    public GameObject camPosOptions;
    public GameObject cube;
    public GameObject menu;
    bool options;
    Vector3 camOptPos;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        camOptPos = camPosOptions.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (options == true) 
        {
            transform.position = Vector3.MoveTowards(transform.position, camOptPos, speed * Time.deltaTime);

            var newRotation = Quaternion.LookRotation(cube.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, speed * Time.deltaTime);
        }
        
    }

    public void MenuOptions()
    {
        //https://answers.unity.com/questions/971927/how-do-i-smoothly-move-my-camera-to-a-set-position.html
        //Ideia estraida desta pagina. Vamos usar um bollean para ativar a direção da camera.
        options = true;
        menu.SetActive(false);

    }


}
