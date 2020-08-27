using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnShapes : MonoBehaviour
{
    private bool canClick = false;
    public GameObject newShape = null;
    private AudioSource sfx;
    public GameObject score;
    private int scoreValue;

    // Set up the score and sound effect to be used.
    void Start()
    {
        scoreValue = int.Parse(score.GetComponent<TextMeshProUGUI>().text);
        sfx = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // If a shape is tapped on...
        if (Input.GetMouseButtonDown(0) && canClick)
        {
            // Play a sound effect.
            sfx.Play(0);

            // Increment the score.
            scoreValue += 10;
            score.GetComponent<TextMeshProUGUI>().text = "" + scoreValue;

            // Create a new shape at a random location within the screen.
            // NOTE: There is a better formula for determining how the shapes could fit within the screen. 
            //       I hand picked these random values to keep the shapes completely on the screen (time constraint decision). 
            Instantiate(newShape, new Vector3(Random.Range(-5, 8), Random.Range(-3, 4.5f), 0), Quaternion.identity);

            // Destroys the the shape that was tapped on.
            Destroy(transform.parent.gameObject);

        }
    }

    // Is the mouse/finger colliding with the shape.
    private void OnMouseEnter()
    {
        canClick = true;
    }


    // Mouse/finger is not colliding with the shape.
    private void OnMouseExit()
    {
        canClick = false;
    }
}
