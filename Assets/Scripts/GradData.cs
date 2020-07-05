using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GradData
{
    public Vector4[] grads;
    protected int count;

    public GradData Init(int _count)
    {
        count = _count;
        InitGrads();
        
        return this;
    }

    public abstract Vector4 GetScale(float scale);

    protected abstract void InitGrads();

    //o is offset, c is count
    protected void Shuffle(int o, int c)
    {
        //Create randomly shuffled indices in w
        for (int i = 0; i < c; i++)
        {
            int j = (int)(Random.value * c) % c;
            float t = grads[i+o].w;
            grads[i+o].w = grads[j+o].w;
            grads[j+o].w = t;
        }
    }
}

public class GradData2 : GradData
{
    private int layerCount;

    public GradData2(int _layerCount)
    {
        layerCount = _layerCount;
    }

    public override Vector4 GetScale(float scale)
    {
        //For the 2D noise shader, 3 different scales provided in XYZ (for RGB channels of output), with scale factor in W
        return new Vector4((float)count, (float)(count >> 1), (float)(count >> 2), scale);
    }

    protected override void InitGrads()
    {
        int[] counts = new int[] { count, count >> 1, count >> 2 };

        grads = new Vector4[counts[0] + counts[1] + counts[2]];

        int o = 0;

        for (int l = 0; l < layerCount; l++)
        {
            for (int i = 0; i < counts[l]; i++)
            {
                Vector2 grad = Random.insideUnitCircle.normalized;

                grads[i+o].x = grad.x;  
                grads[i+o].y = grad.y;
                grads[i+o].z = 0;
                grads[i+o].w = i;
            }

            Shuffle(o, counts[l]);

            o += counts[l];
        }
    }
}

public class GradData3 : GradData
{
    public override Vector4 GetScale(float scale)
    {
        //The 3D noise shader expects 3 different scales in XYZ, all with same count
        //  Interface currently simplified to use same scale for each channel of RGB
        float sc = scale * count;
        return new Vector4(sc, sc, sc, (float)count);
    }

    protected override void InitGrads()
    {
        grads = new Vector4[count];

        for (int i = 0; i < count; i++)
        {
            Vector3 grad = Random.onUnitSphere;

            grads[i].x = grad.x;
            grads[i].y = grad.y;
            grads[i].z = grad.z;
            grads[i].w = i;
        }

        Shuffle(0, count);
    }
}
