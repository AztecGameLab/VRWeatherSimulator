using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    public static WeatherController instance;

    private void Awake()
    {
        instance = this;
    }

    Transform[] airpockets;

    void Start()
    {
        airpockets = GetComponentsInChildren<Transform>();
    }

    void Update()
    {

    }

    void OnDrawGizmosSelected()
    {
        foreach (Transform airpocket in airpockets)
        {
            Gizmos.color = new Color(0.2f, 0.2f, 1, 0.5f);
            Gizmos.DrawCube(airpocket.position, airpocket.localScale);
        }

    }
}
