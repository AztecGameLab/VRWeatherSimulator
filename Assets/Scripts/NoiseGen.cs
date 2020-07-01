using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGen : MonoBehaviour
{
    public Texture source;
    public Material shader;
    public RenderTexture target;

    // Start is called before the first frame update
    void Start()
    {
        Graphics.Blit(null, target, shader);

    }

    // Update is called once per frame
    void Update()
    {
    }
}
