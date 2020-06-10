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


    public VisualEffect myEffect;

    // Lightning position
    //public GameObject lightningPos;

    void Start()
    {
        // Works off of the X,Y,Z system
        // The only ones that should change position is the X and Z coordinate
        //lightningPos.transform.position = new Vector3(Random.Range(-20.0f, 20.0f), 0, Random.Range(-20.0f, 20.0f));
        g1.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(24f, 20f), Random.Range(-5f, 5f));
        g2.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(24f, 20f), Random.Range(-5f, 5f));
        g3.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(24f, 20f), Random.Range(-5f, 5f));
        g3.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(24f, 20f), Random.Range(-5f, 5f));
        g4.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(24f, 20f), Random.Range(-5f, 5f));
        g5.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(24f, 20f), Random.Range(-5f, 5f));
        g6.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(24f, 20f), Random.Range(-5f, 5f));
        g7.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(24f, 20f), Random.Range(-5f, 5f));
        g8.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(24f, 20f), Random.Range(-5f, 5f));
        //myEffect.;
    }
}
