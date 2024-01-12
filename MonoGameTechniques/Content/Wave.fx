#if OPENGL
#define SV_POSITION POSITION
#define VS_SHADERMODEL vs_3_0
#define PS_SHADERMODEL ps_3_0
#else
#define VS_SHADERMODEL vs_4_0_level_9_1
#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

//* Post-processing shader with only pixel shader

texture ScreenTexture;

float Amplitude;
float Frequency;
float Time;

bool TintBlue;

sampler TextureSampler = sampler_state
{
    texture = <ScreenTexture>;
};

struct PSInput
{
    float4 Position : SV_POSITION;
    float4 Color : COLOR0;
    float2 TextureCoordinates : TEXCOORD0;
};;

float4 MainPS(PSInput input) : COLOR0
{
    input.TextureCoordinates += sin(input.TextureCoordinates.x * Frequency + Time) * Amplitude;
    float3 color = tex2D(TextureSampler, input.TextureCoordinates).rgb;

    if (TintBlue)
    {
        color.r *= 0.5;
        color.g *= 0.5;
    }
    
    return float4(color, 1);
}

technique BasicColorDrawing
{
    pass P0
    {
        PixelShader = compile PS_SHADERMODEL MainPS();
    }
};
