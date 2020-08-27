using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject hexagon, circle, triangle;
    // Default is 0 because hexagon will be the starting shape.
    private int selectedShape = 0;

    // Changes the visible shape based off of the selection of the dropdown menu.
    public void ChangeIndex(int index)
    {
       switch(index)
        {
            case 0:
                DeactivateShapes();
                hexagon.SetActive(true);
                selectedShape = 0;
                break;
            case 1:
                DeactivateShapes();
                circle.SetActive(true);
                selectedShape = 1;
                break;
            case 2:
                DeactivateShapes();
                triangle.SetActive(true);
                selectedShape = 2;
                break;
        }
    }

    // Sets the visiblilty of all of the shapes to false before enabling the selected shape.
    private void DeactivateShapes()
    {
        hexagon.SetActive(false);
        circle.SetActive(false);
        triangle.SetActive(false);
    }
}
