using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisionmanager : MonoBehaviour
{

    #region Variables
    public float splinterR, SunR;
    #endregion

    private void FixedUpdate()
    {
        CustomTrigger();
        CustomCollision();
    }

    private void CustomCollision()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            Transform unit1 = transform.GetChild(i);
            for (int j = 1; j < transform.childCount; j++)
            {
                if (i == j)
                    continue;
                else
                {
                    Transform unit2 = transform.GetChild(j);
                    if (Vector3.Distance(unit1.position, unit2.position) < splinterR * 2)
                    { Destroy(unit1.gameObject); Destroy(unit2.gameObject); }
                }
            }
        }
    }

    private void CustomTrigger()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            Transform unit = transform.GetChild(i);

            if (Vector3.Distance(unit.position, transform.position) < splinterR + SunR)
            {
                for (int j = 0; j < unit.childCount; j++)
                {
                    Material temp = unit.GetChild(j).GetComponent<Renderer>().material;
                    temp.SetColor("_MKGlowTexColor", Color.red);
                }
            }
        }
    }
}
