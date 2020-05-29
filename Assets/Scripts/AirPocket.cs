using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPocket : MonoBehaviour
{

    public float temperature = 22;

    [Range(0.0f, 1.0f)]
    public float saturation = 0.5f;

    void Start()
    {

    }

    void Update()
    {

    }

    public void SetTemperature(float temperature)
    {
        this.temperature = temperature;
    }

        public void SetSaturation(float saturation)
    {
        this.saturation = saturation;
    }
}
