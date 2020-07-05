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

            float4 _Grad[768];
            float4 _Scale;
            
            float perlin2(float2 index, uint _Count, uint o)
            {
                uint2 bf;
                uint4 bg;
                float3 u;
                float3 v;
                float2 sv;
                float4 uv;
                float2 av;

                float2 t = index + 10000.0;
                uint2 b0 = uint2(t) % _Count;
                uint2 b1 = (b0 + 1) % _Count;
                float2 r0 = (t - floor(t));
                float2 r1 = r0 - 1.0;

                bf.x = (uint)_Grad[b0.x+o].w;
                bf.y = (uint)_Grad[b1.x+o].w;

                //bg.x = (uint)_Grad[((bf.x + b0.y) % _Count) + o].w;
                //bg.y = (uint)_Grad[((bf.y + b0.y) % _Count) + o].w;
                //bg.z = (uint)_Grad[((bf.x + b1.y) % _Count) + o].w;
                //bg.w = (uint)_Grad[((bf.y + b1.y) % _Count) + o].w;

                bg.x = (bf.x + b0.y) % _Count;
                bg.y = (bf.y + b0.y) % _Count;
                bg.z = (bf.x + b1.y) % _Count;
                bg.w = (bf.y + b1.y) % _Count;

                sv = (-2.0 * r0 + 3.0) * r0 * r0;

                uv.x = dot(_Grad[bg.x+o], float4(r0.x, r0.y, 0, 0));
                uv.y = dot(_Grad[bg.y+o], float4(r1.x, r0.y, 0, 0));
                uv.z = dot(_Grad[bg.z+o], float4(r0.x, r1.y, 0, 0));
                uv.w = dot(_Grad[bg.w+o], float4(r1.x, r1.y, 0, 0));

                av.x = lerp(uv.x, uv.y, sv.x);
                av.y = lerp(uv.z, uv.w, sv.x);

                float pr = (lerp(av.x, av.y, sv.y) + 0.6) * 0.85;

                return saturate(pr);
            }
            
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float4 sc = _Scale * _Scale.w;

                uint s0 = (uint)_Scale.x;
                uint s1 = (uint)_Scale.y;
                uint s2 = (uint)_Scale.z;

                float r = perlin2(float2(i.uv.x * sc.x, i.uv.y * sc.x), s0, 0);
                float g = perlin2(float2(i.uv.x * sc.y, i.uv.y * sc.y), s1, s0);
                float b = perlin2(float2(i.uv.x * sc.z, i.uv.y * sc.z), s2, s0+s1);

                return fixed4(r, g, b, 1.0);
             }
             ENDCG
         }
    }
}
