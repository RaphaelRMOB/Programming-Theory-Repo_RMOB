using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenu : MonoBehaviour
{
    //Criado um empty object para servir de referencia do local onde a camera irá parar.
    public GameObject camPosOptions;
    public GameObject camPosMain;
    public GameObject aimVision;
    public GameObject menu;
    public GameObject menuOption;
    bool options;
    bool mainMenu;
    Vector3 camOptPos;
    Vector3 camMainPos;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        menuOption.SetActive(false);
        camOptPos = camPosOptions.transform.position;
        camMainPos = camPosMain.transform.position;
        mainMenu = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (options == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, camOptPos, speed * Time.deltaTime);

            var newRotation = Quaternion.LookRotation(aimVision.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, speed * Time.deltaTime);
        }

        if (mainMenu == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, camMainPos, speed * Time.deltaTime);

            var newRotation = Quaternion.LookRotation(aimVision.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, speed * Time.deltaTime);
        }

    }

    public void MenuOptions()
    {

        //Ideia estraida desta pagina. Vamos usar um bollean para ativar a direção da camera.
        options = true;
        mainMenu = false;
        menu.SetActive(false);
        StartCoroutine(OpenMenuOption());
        

    }

    public void MainMenu()
    {
        mainMenu = true;
        options = false;
        menuOption.SetActive(false);
        StartCoroutine(OpenMenuMain());
        
    }
    IEnumerator OpenMenuOption()
    {
        yield return new WaitForSeconds(2);
        menuOption.SetActive(true);

    }

    IEnumerator OpenMenuMain()
    {
        yield return new WaitForSeconds(2);
        menu.SetActive(true);
    }

}
