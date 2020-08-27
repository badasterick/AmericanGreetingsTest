using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public GameObject hex, tri, circ;
    private int shapeToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn a random shape at start.
        shapeToSpawn = Random.Range(0, 3);
        ChangeIndex(shapeToSpawn);
    }

    // Sets the selected shape to be visible and plays the spawning animation for that shape.
    public void ChangeIndex(int index)
    {
        switch (index)
        {
            case 0:
                DeactivateShapes();
                hex.SetActive(true);
                hex.GetComponent<Animator>().Play("HexSpawn");
                break;
            case 1:
                DeactivateShapes();
                circ.SetActive(true);
                circ.GetComponent<Animator>().Play("CircleSpawn");
                break;
            case 2:
                DeactivateShapes();
                tri.SetActive(true);
                tri.GetComponent<Animator>().Play("TriangleSpawn");
                break;
        }
    }

    // Deactivates the other shapes. This is here to make sure multiple shapes don't show up during the game.
    private void DeactivateShapes()
    {
        hex.SetActive(false);
        circ.SetActive(false);
        tri.SetActive(false);
    }
}
