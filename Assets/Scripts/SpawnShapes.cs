using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShapes : MonoBehaviour
{
    public bool canClick = false;
    public GameObject newShape = null;
    public GameObject topLeft, topRight, bottomLeft, bottomRight;
    private float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {

        minX = bottomLeft.transform.position.x;
        maxX = topRight.transform.position.x;
        minY = bottomLeft.transform.position.y;
        maxY = topRight.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canClick)
        {
            Instantiate(newShape, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0), Quaternion.identity);
            Destroy(transform.parent.gameObject);
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
}
