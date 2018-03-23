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
                    if (unit1.tag == "Sphere" && unit2.tag == "Sphere")
                    {
                        if (Vector3.Distance(unit1.position, unit2.position) < splinterR * 2)
                        {
                            Destroy(unit1.gameObject);
                            Destroy(unit2.gameObject);
                        }
                    }
                    else
                    {
                        int Count = 0;
                        float x1Min, x1Max, y1Min, y1Max, z1Min, z1Max;
                        float x2Min, x2Max, y2Min, y2Max, z2Min, z2Max;

                        x1Min = y1Min = z1Min = x2Min = y2Min = z2Min = Mathf.Infinity;
                        x1Max = y1Max = z1Max = x2Max = y2Max = z2Max = -Mathf.Infinity;

                        //Checking the Cubes corners
                        if (unit1.tag == "Cube")
                        {
                            float tempx, tempy, tempz;
                            GetDotonAxis(unit1.GetChild(0).transform, new Vector3(10, 10, 10), out tempx, out tempy, out tempz);
                            ProjectBorders(tempx, ref x1Min, ref x1Max);
                            ProjectBorders(tempy, ref y1Min, ref y1Max);
                            ProjectBorders(tempz, ref z1Min, ref z1Max);

                            GetDotonAxis(unit1.GetChild(0).transform, new Vector3(-10, 10, 10), out tempx, out tempy, out tempz);
                            ProjectBorders(tempx, ref x1Min, ref x1Max);
                            ProjectBorders(tempy, ref y1Min, ref y1Max);
                            ProjectBorders(tempz, ref z1Min, ref z1Max);

                            GetDotonAxis(unit1.GetChild(0).transform, new Vector3(10, -10, 10), out tempx, out tempy, out tempz);
                            ProjectBorders(tempx, ref x1Min, ref x1Max);
                            ProjectBorders(tempy, ref y1Min, ref y1Max);
                            ProjectBorders(tempz, ref z1Min, ref z1Max);

                            GetDotonAxis(unit1.GetChild(0).transform, new Vector3(10, 10, -10), out tempx, out tempy, out tempz);
                            ProjectBorders(tempx, ref x1Min, ref x1Max);
                            ProjectBorders(tempy, ref y1Min, ref y1Max);
                            ProjectBorders(tempz, ref z1Min, ref z1Max);

                            GetDotonAxis(unit1.GetChild(0).transform, new Vector3(-10, -10, 10), out tempx, out tempy, out tempz);
                            ProjectBorders(tempx, ref x1Min, ref x1Max);
                            ProjectBorders(tempy, ref y1Min, ref y1Max);
                            ProjectBorders(tempz, ref z1Min, ref z1Max);

                            GetDotonAxis(unit1.GetChild(0).transform, new Vector3(10, -10, -10), out tempx, out tempy, out tempz);
                            ProjectBorders(tempx, ref x1Min, ref x1Max);
                            ProjectBorders(tempy, ref y1Min, ref y1Max);
                            ProjectBorders(tempz, ref z1Min, ref z1Max);

                            GetDotonAxis(unit1.GetChild(0).transform, new Vector3(-10, -10, -10), out tempx, out tempy, out tempz);
                            ProjectBorders(tempx, ref x1Min, ref x1Max);
                            ProjectBorders(tempy, ref y1Min, ref y1Max);
                            ProjectBorders(tempz, ref z1Min, ref z1Max);
                        }
                        if (unit2.tag == "Cube")
                        {
                            float tempx, tempy, tempz;
                            GetDotonAxis(unit2.GetChild(0).transform, new Vector3(10, 10, 10), out tempx, out tempy, out tempz);
                            ProjectBorders(tempx, ref x2Min, ref x2Max);
                            ProjectBorders(tempy, ref y2Min, ref y2Max);
                            ProjectBorders(tempz, ref z2Min, ref z2Max);

                            GetDotonAxis(unit2.GetChild(0).transform, new Vector3(-10, 10, 10), out tempx, out tempy, out tempz);
                            ProjectBorders(tempx, ref x2Min, ref x2Max);
                            ProjectBorders(tempy, ref y2Min, ref y2Max);
                            ProjectBorders(tempz, ref z2Min, ref z2Max);

                            GetDotonAxis(unit2.GetChild(0).transform, new Vector3(10, -10, 10), out tempx, out tempy, out tempz);
                            ProjectBorders(tempx, ref x2Min, ref x2Max);
                            ProjectBorders(tempy, ref y2Min, ref y2Max);
                            ProjectBorders(tempz, ref z2Min, ref z2Max);

                            GetDotonAxis(unit2.GetChild(0).transform, new Vector3(10, 10, -10), out tempx, out tempy, out tempz);
                            ProjectBorders(tempx, ref x2Min, ref x2Max);
                            ProjectBorders(tempy, ref y2Min, ref y2Max);
                            ProjectBorders(tempz, ref z2Min, ref z2Max);

                            GetDotonAxis(unit2.GetChild(0).transform, new Vector3(-10, -10, 10), out tempx, out tempy, out tempz);
                            ProjectBorders(tempx, ref x2Min, ref x2Max);
                            ProjectBorders(tempy, ref y2Min, ref y2Max);
                            ProjectBorders(tempz, ref z2Min, ref z2Max);

                            GetDotonAxis(unit2.GetChild(0).transform, new Vector3(10, -10, -10), out tempx, out tempy, out tempz);
                            ProjectBorders(tempx, ref x2Min, ref x2Max);
                            ProjectBorders(tempy, ref y2Min, ref y2Max);
                            ProjectBorders(tempz, ref z2Min, ref z2Max);

                            GetDotonAxis(unit2.GetChild(0).transform, new Vector3(-10, -10, -10), out tempx, out tempy, out tempz);
                            ProjectBorders(tempx, ref x2Min, ref x2Max);
                            ProjectBorders(tempy, ref y2Min, ref y2Max);
                            ProjectBorders(tempz, ref z2Min, ref z2Max);
                        }


                    }
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

    private void GetDotonAxis(Transform DotOf, Vector3 WishedCorner, out float onX, out float onY, out float onZ)
    {
        Vector3 temp = DotOf.TransformPoint(Vector3.Scale(transform.localScale / 2, WishedCorner));
        onX = temp.x;
        onY = temp.y;
        onZ = temp.z;
    }

    private void ProjectBorders(float temp, ref float min, ref float max)
    {
        if (temp < min) min = temp;
        if (temp > max) max = temp;
    }
}
