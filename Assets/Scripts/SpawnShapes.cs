using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShapes : MonoBehaviour
{
    private bool canClick = false;
    public GameObject newShape = null;
    public GameObject topLeft, topRight, bottomLeft, bottomRight;
    private float minX, maxX, minY, maxY;
    private AudioSource sfx;

    // Start is called before the first frame update
    void Start()
    {
        sfx = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();
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
            sfx.Play(0);
            Instantiate(newShape, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0), Quaternion.identity);
            //canClick = false;
            //OnMouseExit();
            Destroy(transform.parent.gameObject);

        }
    }

    private void OnMouseEnter()
    {
        canClick = true;
        //print("entered");
    }

    private void OnMouseExit()
    {
        canClick = false;
        //print("exit");
    }
}
