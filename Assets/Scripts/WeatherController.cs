using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WeatherController : MonoBehaviour
{
    public static WeatherController instance;

    private void Awake()
    {
        instance = this;
    }

    public AirPocket[] airpockets;

    void Start()
    {
        //airpockets = GetComponentsInChildren<AirPocket>();
    }

    void Update()
    {

    }


    void OnDrawGizmos()
    {
        foreach (AirPocket airpocket in airpockets)
        {
            Gizmos.color = new Color(0.2f, 0.2f, 1, 0.5f);
            Gizmos.DrawCube(airpocket.transform.position, airpocket.transform.localScale);
        }

    }
}
