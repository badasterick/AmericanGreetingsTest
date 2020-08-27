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


    private void Start()
    {
        // Makes sure the game over screen is hidden and saves the default high score of 0.
        gameOver.SetActive(false);
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        
        // Tracks the player tapping the screen or mouse input to start the game (timer).
        if (Input.GetMouseButtonDown(0))
        {
            intro.SetActive(false);
            startTimer = true;
        }

        // Counts down and updates the timer UI.
        if (startTimer && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timer.GetComponent<TextMeshProUGUI>().text = "" + (int)timeLeft;
        }
        else if (startTimer && timeLeft < 0)
        {
            // When the timer runs out, end the game.
            GameOver();
        }

        // Resets High Score 
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("HighScore");
        }
    }

    // Reveals the game over UI and checks if the user score is greater than the high score. If it is, save the new high score.
    // Destroys any remaining objects in the game.
    private void GameOver()
    {
        gameOver.SetActive(true);
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
