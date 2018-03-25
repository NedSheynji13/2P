using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerascript : MonoBehaviour
{
    #region Variables
    public float sensivity;
    private Vector3 inputAngle;
    #endregion
	
	void Update () 
	{
        inputAngle.y -= Input.GetAxis("Horizontal") * sensivity * Time.deltaTime;
        inputAngle.x += Input.GetAxis("Vertical") * sensivity * Time.deltaTime;

        if (inputAngle.y > 360)
            inputAngle.y -= 360;
        else if (inputAngle.y < 0)
            inputAngle.y += 360;

        inputAngle.x = Mathf.Clamp(inputAngle.x, -10, 40);
        transform.localRotation = Quaternion.Euler(inputAngle);
    }
}
