using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    public static WeatherController instance;
    AirPocket[] airpockets;


    [Range(0.0f, 1.0f)]
    public float thunderstorm;
    
    [Range(0.0f, 1.0f)]
    public float windstorm;
    
    [Range(0.0f, 1.0f)]
    public float fog;



    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        airpockets = GetComponentsInChildren<AirPocket>();
    }

    void Update()
    {
        print(GetRangeOfTemperatures());
        windstorm = Mathf.InverseLerp(0, 150, GetRangeOfTemperatures());
    }

    float GetRangeOfTemperatures() //gets the largest diffrence between airpockets
    {
        float minimum = 9999;
        float maximum = -9999;

        foreach (AirPocket airpocket in airpockets)
        {
            if(airpocket.temperature < minimum)
                minimum = airpocket.temperature;
            if(airpocket.temperature > maximum)
                maximum = airpocket.temperature;
        }
        return Mathf.Abs(maximum - minimum);
    }
}
