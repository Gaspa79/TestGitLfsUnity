using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    public static void SetX(this Transform t, float newX)
    {
        t.position = new Vector3(newX, t.position.y, t.position.z);
    }

    public static void SetY(this Transform t, float newY)
    {
        t.position = new Vector3(t.position.x, newY, t.position.z);
    }

    public static void SetZ(this Transform t, float newZ)
    {
        t.position = new Vector3(t.position.x, t.position.y, newZ);
    }

    public static void SetXY(this Transform t, float newX, float newY)
    {
        t.position = new Vector3(newX, newY, t.position.z);
    }
}
