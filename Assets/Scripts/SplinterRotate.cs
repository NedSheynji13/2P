using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplinterRotate : MonoBehaviour
{
    #region Variables
    public float rotationSpeed;
    private float rotated = 0;
    #endregion

    void Update()
    {
        rotated += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, rotated, 0));
        if (rotated > 360) rotated -= 360;
    }
}
