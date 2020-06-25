using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    public static WeatherController instance;
    AirPocket[] airpockets;

    [Range(0.0f, 1.0f)]
    public float waterAvailability; //affects water in air

    [Range(0.0f, 1.0f)]
    public float mountains;

    [Range(0.0f, 1.0f)]
    public float thunderstorm; //lots of rain in clouds
    
    [Range(0.0f, 1.0f)]
    public float wind; //temperature diffrence

    [Range(0.0f, 1.0f)]
    public float windDryness; //air not saturated
    
    [Range(0.0f, 1.0f)]
    public float fog;

    [Range(0.0f, 1.0f)] //warm and saturated
    public float clouds;

    
    [Range(0.0f, 1.0f)]
    public float rain;

    const float minTemperature = -90;
    const float maxTemperature = 60;
    [Range(minTemperature, maxTemperature)]
    public float temperature = 22;

    //ThunderLightning Delay
    [Range(0.0f , 300.0f)]
    public float timeInput; //Time from flash to thunder

    [Range(1100.0f, 1200.0f)]
    public float speedOfSoundInAir;

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
        wind = (mountains + Mathf.InverseLerp(0, 150, GetRangeOfTemperatures()))/2;
        thunderstorm = (rain + clouds) / 2;
        windDryness = 1 - GetAverageSaturation();
        temperature = GetAverageTemperature();
        clouds = (airpockets[0].clouds + airpockets[1].clouds) / 2;
        rain = Mathf.InverseLerp(.5f, 1, GetAverageSaturation());
        hail = wind * Mathf.InverseLerp(.5f, 1, GetAverageSaturation());
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

    
    float GetAverageSaturation()
    {
        float totalSaturation = 0;

        foreach (AirPocket airpocket in airpockets)
        {
            totalSaturation += airpocket.saturation;
        }

        return totalSaturation/airpockets.Length;
    }
    
    float GetAverageTemperature()
    {
        float totalTemperature = 0;

        foreach (AirPocket airpocket in airpockets)
        {
            totalTemperature += airpocket.temperature;
        }

        return totalTemperature/airpockets.Length;
    }

    public void SetWaterAvailability(float waterAvailability)
    {
        this.waterAvailability = waterAvailability;
    }

        public void SetMountains(float mountains)
    {
        this.mountains = mountains;
    }

    public void ThunderLightningDelay(float timeInput, float speedOfSoundInAir)
    {
        this.timeInput = timeInput;
        this.speedOfSoundInAir = speedOfSoundInAir;

        float distance = Mathf.Round(timeInput / (5280 / speedOfSoundInAir));
    }
}
