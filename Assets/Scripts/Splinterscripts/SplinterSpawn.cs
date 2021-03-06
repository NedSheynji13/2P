﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplinterSpawn : MonoBehaviour
{
    #region Variables
    public GameObject Splinter, CubeSplinter, Sun;
    private bool isRunning = false;
    private Ray ray;
    #endregion

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isRunning == false)
        {
            isRunning = true;
            StartCoroutine(SpawnSplinter());
        }
    }

    private IEnumerator SpawnSplinter()
    {
        float temp = Random.value;
        if (temp > 0.2f)
            Instantiate(Splinter, Spawn(), Quaternion.identity, Sun.transform);
        else
            Instantiate(CubeSplinter, Spawn(), Quaternion.identity, Sun.transform);
        yield return new WaitForSeconds(0f);
        isRunning = false;
    }

    private Vector3 Spawn()
    {
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
            return hit.point;
        else
            return new Vector3(0, 0, 100);
    }
}
