half DitheredAlpha(half albedoAlpha, half4 color, half cutoff, half transparency, half ditherSize, float4 positionCS)
{
#if !defined(_SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A) && !defined(_GLOSSINESS_FROM_BASE_ALPHA)
    half alpha = albedoAlpha * transparency;
#else
    half alpha = transparency;
#endif
 
#if defined(_ALPHATEST_ON)
    float DITHER_THRESHOLDS[16] =
    {
        1.0 / 17.0,  9.0 / 17.0,  3.0 / 17.0, 11.0 / 17.0,
        13.0 / 17.0,  5.0 / 17.0, 15.0 / 17.0,  7.0 / 17.0,
        4.0 / 17.0, 12.0 / 17.0,  2.0 / 17.0, 10.0 / 17.0,
        16.0 / 17.0,  8.0 / 17.0, 14.0 / 17.0,  6.0 / 17.0
    };
   
    float2 uv = positionCS.xy / _ScaledScreenParams.xy;
    uv *= _ScreenParams.xy;  
    uint index = (uint(uv.x) % 4) * 4 + uint(uv.y) % 4;
    // Returns > 0 if not clipped, < 0 if clipped based
    // on the dither
    clip(alpha - DITHER_THRESHOLDS[index]);
#endif
 
    return alpha;
}