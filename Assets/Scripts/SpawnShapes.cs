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

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = int.Parse(score.GetComponent<TextMeshProUGUI>().text);
        sfx = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canClick)
        {
            sfx.Play(0);
            scoreValue += 10;
            score.GetComponent<TextMeshProUGUI>().text = "" + scoreValue;


            Instantiate(newShape, new Vector3(Random.Range(-5, 8), Random.Range(-3, 4.5f), 0), Quaternion.identity);

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
