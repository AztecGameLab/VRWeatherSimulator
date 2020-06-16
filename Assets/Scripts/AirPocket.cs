using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPocket : MonoBehaviour
{

    const float minTemperature = -90;
    const float maxTemperature = 60;
    [Range(minTemperature, maxTemperature)]
    public float temperature = 22;
    public Gradient temperatureGradient;

    [Range(0.0f, 1.0f)]
    public float saturation = 0.5f;

    Material material;
    Color color;

    void Start()
    {
        material = GetComponentInChildren<Renderer>().material;
    }

    void Update()
    {
        color = temperatureGradient.Evaluate(Mathf.InverseLerp(minTemperature,maxTemperature,temperature));
        color.a = Mathf.Lerp(0.2f,0.8f, saturation);
        material.color = color;
        saturation = Mathf.InverseLerp(-20, 40, temperature);
    }

    public void SetTemperature(float temperature)
    {
        this.temperature = temperature;
    }

    public void SetTemperatureByPercent(float percent)
    {
        SetTemperature(Mathf.Lerp(minTemperature, maxTemperature, percent));
    }

        public void SetSaturation(float saturation)
    {
        this.saturation = saturation;
    }
}
