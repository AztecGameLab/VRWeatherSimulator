﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fog = true;
        RenderSettings.fogDensity = .1f;
        RenderSettings.fogEndDistance = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
