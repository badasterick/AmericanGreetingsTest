using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //public TMP_Dropdown dropDownMenu;
    public GameObject hexagon, circle, triangle;
    // Default is 0 because hexagon will be the starting shape.
    private int selectedShape = 0;

    private void Start()
    {
        //List<string> shapes = new List<string>() { "Hexagon", "Circle", "Triangle" };
        //dropDownMenu.AddOptions(shapes);
    }

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

    private void DeactivateShapes()
    {
        hexagon.SetActive(false);
        circle.SetActive(false);
        triangle.SetActive(false);
    }
}
