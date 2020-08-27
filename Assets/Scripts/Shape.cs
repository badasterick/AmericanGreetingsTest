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
        shapeToSpawn = Random.Range(0, 3);
        //print(shapeToSpawn);
        ChangeIndex(shapeToSpawn);
    }

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

    private void DeactivateShapes()
    {
        hex.SetActive(false);
        circ.SetActive(false);
        tri.SetActive(false);
    }
}
