using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGen : MonoBehaviour
{
    public Material source;
    public RenderTexture target;
    public float scale;

    const int gradCount = 256;

    GradData gradData;
    float startTime;

    //2D Noise:  Initialize the random vectors for noise generation.  Call again to generate different noise at the same scale.
    //  Generates 3 layers for rgb channels of final texture
    public void InitNoise2()
    {
        gradData = new GradData2(3).Init(gradCount);
        startTime = Time.time;
    }

    //3D Noise:  Initialize the random vectors for noise generation.  Call again to generate different noise at the same scale.
    //  RGB channels in final texture are sampled from 3D positions
    public void InitNoise3()
    {
        gradData = new GradData3().Init(gradCount);
        startTime = Time.time;
    }

    //Call to create noise, or to regenerate the same noise at a different scale.
    //  'scale' determines scale of separate noise textures to r, g, b channels of output
    public void CreateNoise(float scale)
    {
        source.SetVector("_Scale", gradData.GetScale(scale));
        source.SetVectorArray("_Grad", gradData.grads);
        Graphics.Blit(null, target, source);
    }

    void Start()
    {
        InitNoise2();
        CreateNoise(scale);
    }

    void Update()
    {
        if ((Time.time - startTime) > 10.0f)
        {
            InitNoise2();
            CreateNoise(scale);
        }
    }
}
