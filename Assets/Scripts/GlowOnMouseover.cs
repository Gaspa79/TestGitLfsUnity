using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowOnMouseover : MonoBehaviour
{
    /// <summary>
    /// Arbitrary number that controls how fast the glow "breathes"
    /// </summary>
    public int GlowBreathSpeed = 1;

    public double GlowIntensity = 0.1;

    /// <summary>
    /// The name of the child
    /// </summary>
    public const string LIGHT_OBJ_NAME = "BreathingLight";

    private UnityEngine.Rendering.Universal.Light2D _lightComponent;

    private void OnMouseOver()
    {
        _lightComponent.intensity = (float)GlowIntensity;
    }

    void OnMouseExit()
    {
        _lightComponent.intensity = 0;
    }

    private void Awake()
    {
        GameObject lightGameObject = GetChildWithName(this.gameObject, LIGHT_OBJ_NAME);
        this._lightComponent = lightGameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }
}
