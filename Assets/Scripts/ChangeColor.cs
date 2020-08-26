using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Vector2 mousePos;
    private bool canClick = false;
    private bool firstClick = false;
    private float doubleClickTimer;
    private float delay = 0.5f;
    
    //public GameObject shapeToChange;
    
    //public GameObject hexagon;
    //public GameObject circle;
    //public GameObject triangle;

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;  
        
        if(Input.GetMouseButtonDown(0))
        {
            if(!firstClick)
            {
                firstClick = true;

                doubleClickTimer = Time.time;
            }
            else
            {
                firstClick = false;
                if (canClick)
                {
                    ColorChange();
                }
            }
        }

        if(firstClick)
        {
            if((Time.time - doubleClickTimer) > delay) { firstClick = false;  }
        }

    }

    private void OnMouseEnter()
    {
        canClick = true;
    }

    private void OnMouseExit()
    {
        canClick = false;
    }

    private void ColorChange()
    {
        Color co = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        this.GetComponent<SpriteRenderer>().color = co;
        //shapeToChange.GetComponent<SpriteRenderer>().color = co;
        /*hexagon.GetComponent<SpriteRenderer>().color = co;
        circle.GetComponent<SpriteRenderer>().color = co;
        triangle.GetComponent<SpriteRenderer>().color = co;*/
    }
}
