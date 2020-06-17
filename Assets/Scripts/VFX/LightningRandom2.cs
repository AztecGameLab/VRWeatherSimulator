using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class LightningRandom2 : MonoBehaviour
{
    // Start is called before the first frame update
    // These are the lightning balls
    public GameObject g1;
    public GameObject g2;
    public GameObject g3;
    public GameObject g4;
    public GameObject g5;
    public GameObject g6;
    public GameObject g7;
    public GameObject g8;
    public GameObject currentPos;
    float xAxis;
    float zAxis;

    public VisualEffect myEffect;

    // Lightning position
    //public GameObject lightningPos;

    void Start()
    {
        // Works off of the X,Y,Z system
        // The only ones that should change position is the X and Z coordinate
        xAxis = currentPos.transform.position.x;
        zAxis = currentPos.transform.position.z; 
        g1.transform.position = new Vector3(Random.Range(xAxis - 5, xAxis + 5), Random.Range(24f, 20f), Random.Range(zAxis - 5, zAxis + 5));
        g2.transform.position = new Vector3(Random.Range(xAxis - 5, xAxis + 5), Random.Range(24f, 20f), Random.Range(zAxis - 5, zAxis + 5));
        g3.transform.position = new Vector3(Random.Range(xAxis - 5, xAxis + 5), Random.Range(24f, 20f), Random.Range(zAxis - 5, zAxis + 5));
        g3.transform.position = new Vector3(Random.Range(xAxis - 5, xAxis + 5), Random.Range(24f, 20f), Random.Range(zAxis - 5, zAxis + 5));
        g4.transform.position = new Vector3(Random.Range(xAxis - 5, xAxis + 5), Random.Range(24f, 20f), Random.Range(zAxis - 5, zAxis + 5));
        g5.transform.position = new Vector3(Random.Range(xAxis - 5, xAxis + 5), Random.Range(24f, 20f), Random.Range(zAxis - 5, zAxis + 5));
        g6.transform.position = new Vector3(Random.Range(xAxis - 5, xAxis + 5), Random.Range(24f, 20f), Random.Range(zAxis - 5, zAxis + 5));
        g7.transform.position = new Vector3(Random.Range(xAxis - 5, xAxis + 5), Random.Range(24f, 20f), Random.Range(zAxis - 5, zAxis + 5));
        g8.transform.position = new Vector3(Random.Range(xAxis - 5, xAxis + 5), Random.Range(24f, 20f), Random.Range(zAxis - 5, zAxis + 5));
    }
}
