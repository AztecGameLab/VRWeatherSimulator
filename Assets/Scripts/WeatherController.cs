using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WeatherController : MonoBehaviour
{
    public static WeatherController instance;

    [Range(0.0f, 1.0f)]
    public float Thunderstorm;
    
    [Range(0.0f, 1.0f)]
    public float Windstorm;
    
    [Range(0.0f, 1.0f)]
    public float Fog;

    private void Awake()
    {
        instance = this;
    }

    AirPocket[] airpockets;

    void Start()
    {
        airpockets = GetComponentsInChildren<AirPocket>();
    }

    void Update()
    {

    }
}
