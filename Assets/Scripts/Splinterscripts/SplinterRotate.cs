using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplinterRotate : MonoBehaviour
{
    #region Variables
    public float rotationSpeed;
    private Vector3 randomRot;
    private float rotationspeed;
    #endregion

    private void Start()
    {
        randomRot = new Vector3(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360));
    }

    void Update()
    {
        rotationspeed = Random.value * 200;
        transform.RotateAround(transform.position, randomRot, Time.deltaTime * rotationspeed);
    }
}
