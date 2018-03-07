using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    #region Variables
    public float SystemRotationSpeed;
    public float gravitationalForce = 10;
    public GameObject Splinter;
    private bool IsRunning = false;
    //private Vector3 rot;
    //private Rigidbody physix
    #endregion

    private void Start()
    {
        //rot = transform.rotation.eulerAngles;
    }

    void Update()
    {
        //rot = Quaternion.Euler(0, 1 * rpm * Time.deltaTime, 0) * rot;
        //transform.rotation = Quaternion.Euler(rot);

        //transform.Rotate(Vector3.up, rpm * Time.deltaTime);

        Star.rotationRates = new Vector3(0, SystemRotationSpeed * Time.deltaTime, 0);

        /*Storytime with Ned
        
        To get this really cool looking star i had to work arround some stuff.
        1. Star.cs -> Star.rotationRates wasnt static before. For the sake of coolness is was a necessary sacrifice
        2. StarEditor.cs -> Had to be changed to compensate for the warnings
        I am aware that this isnt part of the actual Assignment but god damn i couldnt help myself. Hit me as hard as possible as punishment if this is not ok.
        To compensate this i will let the little spikes rotate arround themselves and the Sun to compensate
        */

        if (Input.GetKey(KeyCode.Space) && IsRunning == false)
        {
            IsRunning = true;
            StartCoroutine(SpawnSplinter());
        }
    }

    private void FixedUpdate()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            float distance = Vector3.Distance(transform.position, transform.GetChild(i).transform.position);
            float gforce = (gravitationalForce / Mathf.Pow(distance, 2)) * 66740.8f;

            Vector3 direction = Vector3.Normalize(transform.position - transform.GetChild(i).transform.position);
            //physix.AddForce(direction * gforce * Time.fixedDeltaTime);

            transform.GetChild(i).transform.Translate(direction * gforce * Time.fixedDeltaTime);
        }
    }

    private IEnumerator SpawnSplinter()
    {
        Instantiate(Splinter, gameObject.transform);
        yield return new WaitForSeconds(3);
        IsRunning = false;
    }
}
