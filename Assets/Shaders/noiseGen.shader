Shader "Unlit/noiseGen2"
{
    Properties
    {
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 100

        Pass
        {
            ZTest Always Cull Off ZWrite Off
            Fog { Mode off }

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float4 _Grad[256];
            float4 _Scale;
            
            float test(float3 index)
            {
                uint idx = index.x % 256;
                uint idy = index.y % 256;
                return abs(_Grad[idx].x * _Grad[idy].x);
            }

            float perlin(float3 index)
            {
                //uint _Count = (uint)_Scale.w;

                uint _Count = 256;

                uint2 bf;
                uint4 bg;
                uint4 bh;
                uint4 bi;
                float3 u;
                float3 v;
                float2 uv;
                float3 sv;
                float2 av;
                float2 cv;

                //float3 t = (index + 10000.0);
                float3 t = index;
                uint3 b0 = uint3(t) % _Count;
                uint3 b1 = (b0 + 1) % _Count;
                float3 r0 = (t - floor(t));
                float3 r1 = r0 - 1.0;

                bf.x = (uint)_Grad[b0.x].w;
                bf.y = (uint)_Grad[b1.x].w;

                bg.x = (uint)_Grad[(bf.x + b0.y) % _Count].w;
                bg.y = (uint)_Grad[(bf.y + b0.y) % _Count].w;
                bg.z = (uint)_Grad[(bf.x + b1.y) % _Count].w;
                bg.w = (uint)_Grad[(bf.y + b1.y) % _Count].w;

                bh.x = (uint)_Grad[(bg.x + b0.z) % _Count].w;
                bh.y = (uint)_Grad[(bg.y + b0.z) % _Count].w;
                bh.z = (uint)_Grad[(bg.z + b0.z) % _Count].w;
                bh.w = (uint)_Grad[(bg.w + b0.z) % _Count].w;

                bi.x = (uint)_Grad[(bg.x + b1.z) % _Count].w;
                bi.y = (uint)_Grad[(bg.y + b1.z) % _Count].w;
                bi.z = (uint)_Grad[(bg.z + b1.z) % _Count].w;
                bi.w = (uint)_Grad[(bg.w + b1.z) % _Count].w;

                sv = (-2.0 * r0 + 3.0) * r0 * r0;

                uv.x = dot(_Grad[bh.x], float4(r0.x, r0.y, r0.z, 0));
                uv.y = dot(_Grad[bh.y], float4(r1.x, r0.y, r0.z, 0));
                //uv.x = dot(_Grad[(bg.x + b0.z) % _Count], float4(r0.x, r0.y, r0.z, 0));
                //uv.y = dot(_Grad[(bg.y + b0.z) % _Count], float4(r1.x, r0.y, r0.z, 0));
                av.x = lerp(uv.x, uv.y, sv.x);

                uv.x = dot(_Grad[bh.z], float4(r0.x, r1.y, r0.z, 0));
                uv.y = dot(_Grad[bh.w], float4(r1.x, r1.y, r0.z, 0));
                //uv.x = dot(_Grad[(bg.z + b0.z) % _Count], float4(r0.x, r1.y, r0.z, 0));
                //uv.y = dot(_Grad[(bg.w + b0.z) % _Count], float4(r1.x, r1.y, r0.z, 0));
                av.y = lerp(uv.x, uv.y, sv.x);

                cv.x = lerp(av.x, av.y, sv.y);

                uv.x = dot(_Grad[bi.x], float4(r0.x, r0.y, r1.z, 0));
                uv.y = dot(_Grad[bi.y], float4(r1.x, r0.y, r1.z, 0));
                //uv.x = dot(_Grad[(bg.x + b1.z) % _Count], float4(r0.x, r0.y, r1.z, 0));
                //uv.y = dot(_Grad[(bg.y + b1.z) % _Count], float4(r1.x, r0.y, r1.z, 0));
                av.x = lerp(uv.x, uv.y, sv.x);

                uv.x = dot(_Grad[bi.z], float4(r0.x, r1.y, r1.z, 0));
                uv.y = dot(_Grad[bi.w], float4(r1.x, r1.y, r1.z, 0));
                //uv.x = dot(_Grad[(bg.z + b1.z) % _Count], float4(r0.x, r1.y, r1.z, 0));
                //uv.y = dot(_Grad[(bg.w + b1.z) % _Count], float4(r1.x, r1.y, r1.z, 0));
                av.y = lerp(uv.x, uv.y, sv.x);

                cv.y = lerp(av.x, av.y, sv.y);


                float pr = (lerp(cv.x, cv.y, sv.z) + 0.6) * 0.85;
                return saturate(pr);
            }
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            fixed4 frag(v2f i) : SV_Target
            {
                float j = _Scale.w / 3.0;
                float r = perlin(float3(i.uv.x * _Scale.x, i.uv.y * _Scale.x , 0.7));
                float g = perlin(float3(i.uv.x * _Scale.y, i.uv.y * _Scale.y, j + 0.7));
                float b = perlin(float3(i.uv.x * _Scale.z, i.uv.y * _Scale.z, 1.9 * j + 0.7));
                
               // r = test(float3(i.uv.x * 256, i.uv.y * 256, 0));

                return fixed4(r, g, b, 1.0);
            }
            ENDCG
        }
    }
}
