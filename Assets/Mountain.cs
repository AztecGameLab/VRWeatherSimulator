using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : MonoBehaviour
{
    public float maxHeight = 5;
    public float minHeight = -10;



    public void SetHeight(int percent)
    {
        print(percent);
        var p = transform.position;
        p.y = Mathf.Lerp(minHeight, maxHeight, (float)percent/3f);
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
