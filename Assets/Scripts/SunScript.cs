using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    #region Variables
    public float systemRotationSpeed;
    public float gravitationalForce = 1;
    #endregion

    void Update()
    {
        Star.rotationRates = new Vector3(0, systemRotationSpeed * Time.fixedDeltaTime, 0);
    }

    private void FixedUpdate()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            Transform unit = transform.GetChild(i).transform;
            float distance = Vector3.Distance(transform.position, unit.position);
            float gforce = (gravitationalForce/ Mathf.Pow(distance, 2)) * 6674f;

            Vector3 direction = Vector3.Normalize(transform.position - unit.position);
            transform.GetChild(i).GetComponent<SplinterForce>().AlterForce(direction * gforce);
        }
    }
}
