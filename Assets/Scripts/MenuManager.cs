using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    
    public string sceneName;

    public Button startButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
        

    }

    

    public void Exit()
    {
        // Condição para fechar o jogo compilado e no Unity.
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }

    public void TitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    
}
