using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerascript : MonoBehaviour
{
    #region Variables
    public float sensivity;
    private Vector3 inputAngle;
    #endregion

    void Start ()
	{
	}
	
	void Update () 
	{
        //Takes informations from the mouse input, read by the input manager and recalculates them to allow smoother camera turns
        inputAngle.y -= Input.GetAxis("Horizontal") * sensivity * Time.deltaTime;
        inputAngle.x += Input.GetAxis("Vertical") * sensivity * Time.deltaTime;

        //Snaps the rotation of the basic form between 0 and 360 degrees
        if (inputAngle.y > 360)
            inputAngle.y -= 360;
        else if (inputAngle.y < 0)
            inputAngle.y += 360;

        inputAngle.x = Mathf.Clamp(inputAngle.x, -10, 40);   //Clamps how high/low and the user can turn the camera. Prevents the camera from looking through the ground.
        transform.localRotation = Quaternion.Euler(inputAngle);            //Sets the rotation of the camera according to the users preference calculated earlier
    }
}
