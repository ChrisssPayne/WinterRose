using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angle_Calc : MonoBehaviour
{
    private Vector3 lastFwd;
    private float curAngleX = 0;


    void Start()
    {
        lastFwd = transform.forward;
    }

    void Update()
    {

        Vector3 curFwd = transform.forward;
        // measure the angle rotated since last frame:
        float ang = Vector3.Angle(curFwd, lastFwd);
        if (ang > 0.01)
        { // if rotated a significant angle...
          // fix angle sign...
            if (Vector3.Cross(curFwd, lastFwd).x < 0) ang = -ang;
            curAngleX += ang; // accumulate in curAngleX...
            lastFwd = curFwd; // and update lastFwd
        }

        print(curAngleX);
    }
}
