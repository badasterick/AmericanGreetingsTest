using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject intro, gameOver;
    public GameObject timer, score;
    private bool startTimer = false;
    private float timeLeft = 60;
    private bool isGameOver = false;


    private void Start()
    {
        gameOver.SetActive(false);
    }

    void Update()
    {
        
        if(startTimer && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timer.GetComponent<TextMeshProUGUI>().text = "" + (int)timeLeft;
        }
        else if(startTimer && timeLeft < 0)
        {
            GameOver();
        }

        if(Input.GetMouseButtonDown(0) && isGameOver)
        {
            RestartGame();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            intro.SetActive(false);
            startTimer = true;
        }
    }

    private void RestartGame()
    {
        gameOver.SetActive(false);
        intro.SetActive(true);
        timeLeft = 60;
        score.GetComponent<TextMeshProUGUI>().text = "0";
    }

    private void GameOver()
    {
        gameOver.SetActive(true);
        isGameOver = true;
        startTimer = false;
    }
}
