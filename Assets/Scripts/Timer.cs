using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    //private GameManagerX gameManagerX;
    private bool isGameActive;
    private void Start()
    {
        //gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        // Starts the timer automatically
        //timerIsRunning = true;

    }
    void Update()
    {
        //isGameActive = gameManagerX.isGameActive;

        if (timerIsRunning && isGameActive)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = "Score: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
