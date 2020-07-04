using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGen : MonoBehaviour
{
    public Material source;
    public RenderTexture target;
    public Vector3 scale;

    const int gradCount = 256;

    struct GradData
    {
        public Vector3[] grads;
        public Vector4[] perms;

        public GradData Init()
        {
            grads = new Vector3[gradCount];
            perms = new Vector4[gradCount];

            InitGrads();
            InitPerms();

            return this;
        }

        void InitGrads()
        {
            //Create gradients on unit sphere
            for (int i = 0; i < gradCount; i++)
            {
                grads[i] = Random.onUnitSphere;

                //~
                //grads[i] = new Vector3(Mathf.Abs(grads[i].x), Mathf.Abs(grads[i].y), Mathf.Abs(grads[i].z));
            }
        }

        void InitPerms()
        {
            for (int i = 0; i < gradCount; i++)
            {
                perms[i].x = grads[i].x;
                perms[i].y = grads[i].y;
                perms[i].z = grads[i].z;
                perms[i].w = i;
            }

            //Create randomly shuffled indices
            for (int i = 0; i < gradCount; i++)
            {
                int j = (int)(Random.value * gradCount) % gradCount;
                float t = perms[i].w;
                perms[i].w = perms[j].w;
                perms[j].w = t;
            }
        }
    }

    GradData gradData;
    float startTime;


    //Initialize the random vectors for noise generation.  Call again to generate different noise at the same scale.
    public void InitNoise()
    {
        gradData = new GradData().Init();
        startTime = Time.time;
    }

    //Call to create noise, or to regenerate the same noise at a different scale.
    //  'scale' determines scale of separate noise textures to r, g, b channels of output
    public void CreateNoise(Vector3 scale)
    {
        //Vector4[] colors = new Vector4[] { new Vector4(1.0f, 0.5f, 0, 1.0f), new Vector4(0, 1.0f, 0.5f, 1.0f), new Vector4(0.5f, 0, 1.0f, 1.0f) };
        //source.SetVectorArray("_Grad0", colors);

        source.SetVector("_Scale", new Vector4(scale.x, scale.y, scale.z, gradCount));
        source.SetVectorArray("_Grad", gradData.perms);
        Graphics.Blit(null, target, source);
    }

    // Start is called before the first frame update
    void Start()
    {
        InitNoise();
        CreateNoise(scale);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - startTime) > 100.0f)
        {
            InitNoise();
            CreateNoise(scale);
        }

    }
}
