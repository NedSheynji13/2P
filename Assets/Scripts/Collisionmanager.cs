using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisionmanager : MonoBehaviour
{

    #region Variables
    public GameObject Boom;
    public float splinterR;
    private float SunR;
    #endregion

    private void Start()
    {
        SunR = transform.GetChild(0).localScale.x / 2;
    }

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

                    int Count = 0;
                    float x1Min, x1Max, y1Min, y1Max, z1Min, z1Max;
                    float x2Min, x2Max, y2Min, y2Max, z2Min, z2Max;

                    x1Min = y1Min = z1Min = x2Min = y2Min = z2Min = Mathf.Infinity;
                    x1Max = y1Max = z1Max = x2Max = y2Max = z2Max = -Mathf.Infinity;

                    if (unit1.tag == "Cube")
                    {
                        float tempx, tempy, tempz;
                        float cubesize = 20.0f;
                        float p1 = (cubesize / 2);
                        float p2 = (cubesize / -2);
                        Vector3 vtmp;

                        for (int k = 0; k < 7; k++)
                        {
                            switch (k)
                            {
                                case 0: vtmp = new Vector3(p1, p1, p1); break;
                                case 1: vtmp = new Vector3(p1, p1, p2); break;
                                case 2: vtmp = new Vector3(p1, p2, p1); break;
                                case 3: vtmp = new Vector3(p1, p2, p2); break;
                                case 4: vtmp = new Vector3(p2, p1, p1); break;
                                case 5: vtmp = new Vector3(p2, p1, p2); break;
                                case 6: vtmp = new Vector3(p2, p2, p1); break;
                                case 7: vtmp = new Vector3(p2, p2, p2); break;
                                default: vtmp = new Vector3(0, 0, 0); break;
                            }
                            GetDotonAxis(unit1.GetChild(0).transform, vtmp, out tempx, out tempy, out tempz);
                            ProjectBorders(tempx, ref x1Min, ref x1Max);
                            ProjectBorders(tempy, ref y1Min, ref y1Max);
                            ProjectBorders(tempz, ref z1Min, ref z1Max);
                        }
                    }
                    else if (unit1.tag == "Sphere")
                    {
                        x1Min = unit1.transform.position.x - 5;
                        x1Max = unit1.transform.position.x + 5;
                        y1Min = unit1.transform.position.y - 5;
                        y1Max = unit1.transform.position.y + 5;
                        z1Min = unit1.transform.position.z - 5;
                        z1Max = unit1.transform.position.z + 5;
                    }
                    if (unit2.tag == "Cube")
                    {
                        float tempx, tempy, tempz;
                        float cubesize = 20.0f;
                        float p1 = (cubesize / 2);
                        float p2 = (cubesize / -2);
                        Vector3 vtmp;

                        for (int k = 0; k < 7; k++)
                        {
                            switch (k)
                            {
                                case 0: vtmp = new Vector3(p1, p1, p1); break;
                                case 1: vtmp = new Vector3(p1, p1, p2); break;
                                case 2: vtmp = new Vector3(p1, p2, p1); break;
                                case 3: vtmp = new Vector3(p1, p2, p2); break;
                                case 4: vtmp = new Vector3(p2, p1, p1); break;
                                case 5: vtmp = new Vector3(p2, p1, p2); break;
                                case 6: vtmp = new Vector3(p2, p2, p1); break;
                                case 7: vtmp = new Vector3(p2, p2, p2); break;
                                default: vtmp = new Vector3(0, 0, 0); break;
                            }
                            GetDotonAxis(unit2.GetChild(0).transform, vtmp, out tempx, out tempy, out tempz);
                            ProjectBorders(tempx, ref x2Min, ref x2Max);
                            ProjectBorders(tempy, ref y2Min, ref y2Max);
                            ProjectBorders(tempz, ref z2Min, ref z2Max);
                        }
                    }
                    else if (unit2.tag == "Sphere")
                    {
                        x2Min = unit2.transform.position.x - 5;
                        x2Max = unit2.transform.position.x + 5;
                        y2Min = unit2.transform.position.y - 5;
                        y2Max = unit2.transform.position.y + 5;
                        z2Min = unit2.transform.position.z - 5;
                        z2Max = unit2.transform.position.z + 5;
                    }

                    //Intersection testing
                    if (x2Max > x1Min && x1Max > x2Min && y2Max > y1Min && y1Max > y2Min && z2Max > z1Min && z1Max > z2Min)
                    {
                        Instantiate(Boom, unit1.transform.position, Quaternion.identity);
                        Instantiate(Boom, unit2.transform.position, Quaternion.identity);
                        Destroy(unit1.gameObject);
                        Destroy(unit2.gameObject);
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
