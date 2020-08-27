using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject intro, gameOver;
    public GameObject timer, score, finalScore, newHighScore;
    public TextMeshProUGUI highScore;
    private bool startTimer = false;
    private float timeLeft = 60;
    private bool isGameOver = false;


    private void Start()
    {
        gameOver.SetActive(false);
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        

        /*if(Input.GetMouseButtonDown(0) && isGameOver)
        {
            RestartGame();
        } else*/
        if (Input.GetMouseButtonDown(0))
        {
            intro.SetActive(false);
            startTimer = true;
        }

        if (startTimer && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timer.GetComponent<TextMeshProUGUI>().text = "" + (int)timeLeft;
        }
        else if (startTimer && timeLeft < 0)
        {
            GameOver();
        }

        // Resets High Score
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("HighScore");
        }
    }

    /*private void RestartGame()
    {
        gameOver.SetActive(false);
        intro.SetActive(true);
        timeLeft = 60;
        score.GetComponent<TextMeshProUGUI>().text = "0";
    }*/

    private void GameOver()
    {
        gameOver.SetActive(true);
        //isGameOver = true;
        startTimer = false;
        finalScore.GetComponent<TextMeshProUGUI>().text = score.GetComponent<TextMeshProUGUI>().text;

        if(int.Parse(finalScore.GetComponent<TextMeshProUGUI>().text) > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", int.Parse(finalScore.GetComponent<TextMeshProUGUI>().text));
            newHighScore.SetActive(true);
        }

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Shape"))
        {
            Destroy(obj);
        }
    }
}
