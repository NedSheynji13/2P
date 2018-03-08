using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    #region Variables
    public float systemRotationSpeed;
    public float gravitationalForce = 10;
    public GameObject Splinter;
    private bool isRunning = false;
    #endregion


    void Update()
    {
        Star.rotationRates = new Vector3(0, systemRotationSpeed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.Space) && isRunning == false)
        {
            isRunning = true;
            StartCoroutine(SpawnSplinter());
        }
    }

    private void FixedUpdate()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            float distance = Vector3.Distance(transform.position, transform.GetChild(i).transform.position);
            float gforce = (gravitationalForce/ Mathf.Pow(distance, 2)) * 6674f;

            Vector3 direction = Vector3.Normalize(transform.position - transform.GetChild(i).transform.position);

            transform.GetChild(i).transform.Translate(direction * gforce * Time.fixedDeltaTime);
        }
    }

    private IEnumerator SpawnSplinter()
    {
        Instantiate(Splinter, gameObject.transform);
        yield return new WaitForSeconds(3);
        isRunning = false;
    }
}
