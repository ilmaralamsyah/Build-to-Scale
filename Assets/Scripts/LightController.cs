using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    public static event Action onReveal;
    public static event Action onHide;

    [SerializeField] private Light light;

    private float lightRangeDefault;
    private float lightIntensityDefault;

    private void Awake()
    {
        light = light.GetComponent<Light>();
        lightRangeDefault = light.range;
        lightIntensityDefault = light.intensity;
    }

    public void LightDown()
    {
        if (light.range > lightRangeDefault)
        {
            light.range -= 1f;
        }

        if (light.intensity > lightIntensityDefault)
        {
            light.intensity -= 1f;
        }

        if (light.intensity < 7f)
        {
            onHide?.Invoke();
        }
    }

    public void LightUp()
    {
        if (light.range <= 10f)
        {
            light.range += 1f;
        }

        if (light.intensity <= 7f)
        {
            light.intensity += 1f;
        }

        if (light.intensity >= 7f)
        {
            Debug.Log("aa");
            onReveal?.Invoke();
        }
        
    }
}
