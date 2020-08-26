﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public RotateToMouse rotateToMouse;

    private GameObject effectToSpawn;
    private float timeToFire = 0;

    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfx[0];   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMovement>().fireRate;
            SpawnVFX();
        }
    }

    void SpawnVFX()
    {
        GameObject vfx;

        if(firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            if(rotateToMouse != null) { vfx.transform.localRotation = rotateToMouse.GetRotation(); }
        }
        else
        {
            UnityEngine.Debug.Log("No Fire Point");
        }
    }

}
