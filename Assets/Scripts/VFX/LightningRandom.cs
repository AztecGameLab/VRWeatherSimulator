using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class LightningRandom : MonoBehaviour
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
        g1.transform.position = new Vector3(Random.Range(xAxis - 2.5f, xAxis + 2.5f), 24, Random.Range(zAxis - 5, zAxis + 5));
        g2.transform.position = new Vector3(Random.Range(xAxis - 2.5f, xAxis + 2.5f), 21, Random.Range(zAxis - 5, zAxis + 5));
        g3.transform.position = new Vector3(Random.Range(xAxis - 2.5f, xAxis + 2.5f), 18, Random.Range(zAxis - 5, zAxis + 5));
        g3.transform.position = new Vector3(Random.Range(xAxis - 2.5f, xAxis + 2.5f), 15, Random.Range(zAxis - 5, zAxis + 5));
        g4.transform.position = new Vector3(Random.Range(xAxis - 2.5f, xAxis + 2.5f), 12, Random.Range(zAxis - 5, zAxis + 5));
        g5.transform.position = new Vector3(Random.Range(xAxis - 2.5f, xAxis + 2.5f), 9, Random.Range(zAxis - 5, zAxis + 5));
        g6.transform.position = new Vector3(Random.Range(xAxis - 2.5f, xAxis + 2.5f), 6, Random.Range(zAxis - 5, zAxis + 5));
        g7.transform.position = new Vector3(Random.Range(xAxis - 2.5f, xAxis + 2.5f), 3, Random.Range(zAxis - 5, zAxis + 5));
        g8.transform.position = new Vector3(Random.Range(xAxis - 2.5f, xAxis + 2.5f), 0, Random.Range(zAxis - 5, zAxis + 5));
        //myEffect.;
    }    
}
