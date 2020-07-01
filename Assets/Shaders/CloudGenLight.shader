Shader "Unlit/CloudGenLight"
{
    Properties
    {
        //Required parameters
        _MainTex ("Texture Noise", 2D) = "white" {}
        _CloudScale("Cloud Scale", Float) = 0.001
        _CloudColorLow("Cloud Color Low", Vector) = (1.000000,1.000000,1.000000,0.000000)
        _CloudColorHigh("Cloud Color High", Vector) = (1.200000,1.200000,1.200000,1.000000)

        _CloudCutoffLow("Sharpness_Low", Range(0.000000,1.000000)) = 0.100000
        _CloudCutoffHigh("Sharpness_High", Range(0.000000,1.000000)) = 1.000000
        
        _CloudCutoffMul ("Sharp 1 over Dif", Float   ) = 1.11111111111  // 1 / (high - low)
        _QuadBaseY("Quad_BaseY", Float) = 20.000000
        _HalfQuadHeight("Half Quad Height", Float) = 10.000000
        _InvQuadHeight("Inverse Quad Height", Float) = 0.1

        //For time animation
        //_TimeScale ("TimeScale", Range(0.100000,100.000000)) = 0.300000
        //_RelScaleSmall("TimeScale_RelSmall", Range(0.001000,2.000000)) = 0.500000
        //_RelScaleShade("TimeScale_RelShade", Range(0.001000,2.000000)) = 0.500000
        
        //For exponential power curves    
        //_CloudSmooth("Smoothness", Range(0.100000,10.000000)) = 0.100000
        //_CloudRound("Roundness", Range(0.100000,10.000000)) = 2.000000
        //_FalseFresnel("FalseFresnel", Range(0.010000,2.000000)) = 0.400000
    }
    SubShader
    {
        Blend SrcAlpha OneMinusSrcAlpha

        Tags 
        { 
            "Queue" = "Transparent"
            "RenderType" = "Transparent"
        }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            //FOG: #pragma multi_compile_fog
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                //FOG: UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float4 world : COLOR0;
            };

            sampler2D _MainTex;
            float _CloudScale;
            float _CloudCutoffLow;
            float _CloudCutoffHigh;
            float _CloudCutoffMul;
            float _QuadBaseY;
            float _HalfQuadHeight;
            float _InvQuadHeight;
            float4 _CloudColorLow;
            float4 _CloudColorHigh;
            //FOG:  float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.world = mul(unity_ObjectToWorld, v.vertex);
                //FOG: o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                //FOG: UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.world.xz * _CloudScale);

                float alpha = col.x * col.y;
                float y0 = _QuadBaseY - i.world.y;

                float y1 = saturate(abs(2.0f * y0 * _InvQuadHeight));
                y1 = y1 * y1 * y1;
                y1 = lerp(_CloudCutoffLow, _CloudCutoffHigh, y1);

                float y2 = 1.0f - saturate(abs(y0 + _HalfQuadHeight) * _InvQuadHeight);
                y2 = y2 * y2;

                alpha = saturate((alpha - y1) * _CloudCutoffMul);

                col = lerp(_CloudColorLow, _CloudColorHigh, y2);
                col = float4(col.xyz, col.a * alpha);

                //FOG: UNITY_APPLY_FOG(i.fogCoord, col);

                return col;
            }
            ENDCG
        }
    }
}
