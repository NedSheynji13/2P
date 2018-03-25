using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplinterForce : MonoBehaviour
{
    #region Variables
    public Vector3 direction;
    public float power = 1;
    #endregion

    private void Start()
    {
        direction = new Vector3(randomizer(), randomizer(), 0);
    }

    private void FixedUpdate () 
	{
        transform.Translate(direction * power * Time.fixedDeltaTime);
        if (Vector3.Distance(transform.position, transform.parent.position) > 1000)
            Destroy(gameObject);
	}

    public void AlterForce(Vector3 _direction)
    {
        direction += _direction;
    }

    private float randomizer()
    {
        float temp = Random.Range(40, 50);
        if (Random.value > 0.5f)
            temp *= -1;
        return temp;
    }
}
