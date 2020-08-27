using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private bool canClick = false;
    private bool firstClick = false;
    private float doubleClickTimer;

    // Delay set at 0.5 for double click. It can be adjusted to change the time it takes for a double click to be completed
    private float delay = 0.5f;

    // Update is called once per frame
    void Update()
    { 
        
        // Commented out additional touch inputs as the mousebuttondown commands worked fine on my mobile devices.
        if(Input.GetMouseButtonDown(0)) // || Input.touchCount == 1)
        {
            // First click to set up the window for the Second click.
            if(!firstClick)
            {
                firstClick = true;

                doubleClickTimer = Time.time;
            }
            else
            {
                firstClick = false;

                // If the user double clicked and is colliding with the shape, change the color of the shape.
                if (canClick)
                {
                    ColorChange();
                }
            }
        }

        // Countdown from first click to achieve double click.
        if(firstClick)
        {
            if((Time.time - doubleClickTimer) > delay) { firstClick = false;  }
        }

    }

    // The user is colliding with the shape and is now allowed to change its color.
    private void OnMouseEnter()
    {
        canClick = true;
    }


    // The user is no longer colliding with the shape. Do not allow them to interact with the shape.
    private void OnMouseExit()
    {
        canClick = false;
    }

    // Selects a random color to assign to the shape.
    private void ColorChange()
    {
        Color co = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        this.GetComponent<SpriteRenderer>().color = co;

        // Extra code if you wanted to change the colors together. I kept the change individual.

        //shapeToChange.GetComponent<SpriteRenderer>().color = co;
        /*hexagon.GetComponent<SpriteRenderer>().color = co;
        circle.GetComponent<SpriteRenderer>().color = co;
        triangle.GetComponent<SpriteRenderer>().color = co;*/
    }
}
