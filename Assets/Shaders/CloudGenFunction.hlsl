#ifndef MYHLSLINCLUDE_INCLUDED
#define MYHLSLINCLUDE_INCLUDED

void ProcessCloud_float(float4 Sample, float PosY, float BaseY, float QuadHeight, float2 SharpnessRange, out float3 Color, out float Alpha)
{
    float alpha = Sample.x * Sample.y;
    float y0 = BaseY - PosY;

    float y1 = saturate(abs(2.0 * y0) / QuadHeight);
    y1 = y1 * y1 * y1;
    y1 = lerp(SharpnessRange.x, SharpnessRange.y, y1);

    //float y2 = 1.0f - saturate(abs(y0 + (QuadHeight * 0.5)) / QuadHeight);
    //y2 = y2 * y2;

    Alpha = saturate((alpha - y1) / (SharpnessRange.y - SharpnessRange.x));

    //Color = lerp(float3(0.8, 0.8, 0.8), float3(1.2, 1.2, 1.2), y2);


    Alpha = Alpha * 1.0;
    Color = float3(0.6, 0.6, 0.6) * Sample.z + 0.4;
}

#endif