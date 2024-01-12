#if OPENGL
#define SV_POSITION POSITION
#define VS_SHADERMODEL vs_3_0
#define PS_SHADERMODEL ps_3_0
#else
#define VS_SHADERMODEL vs_4_0_level_9_1
#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

matrix WorldViewProjection;
float3 CameraPosition;
matrix World;

float3 DiffuseColor = float3(1, 1, 1);
float3 AmbientColor = float3(0.15, 0.15, 0.15);

float3 LightDirection = float3(0, 0, 1); //
float3 LightColor = float3(1, 0, 0); 

float3 SpecularPower = 4;
float3 SpecularColor = float3(1, 0, 0); 

texture Texture;
texture NormalMap;

bool UseDiffuse = true;
bool UseSpecular = true;
bool UseNormalMap = true;

sampler BasicTextureSampler = sampler_state
{
    texture = <Texture>;
    MinFilter = Anisotropic;
    MagFilter = Anisotropic;
    MipFilter = Linear; 
};

sampler NormalMapSampler = sampler_state
{
    texture = <NormalMap>;
    MinFilter = Anisotropic; 
    MagFilter = Anisotropic; 
    MipFilter = Linear; 
};

struct VertexShaderInput
{
    float4 Position : POSITION0;
    float2 UV : TEXCOORD0;
    float3 Normal : NORMAL0;
    float3 Tangent : TANGENT0;
    float3 Bitangent : BINORMAL0;
};

struct VertexShaderOutput
{
    float4 Position : SV_POSITION;
    float2 UV : TEXCOORD0;
    float3 ViewDirection : TEXCOORD1;
    float3 Normal : NORMAL0;
    float3x3 WorldToTangent : NORMAL1;
};

VertexShaderOutput MainVS(in VertexShaderInput input)
{
    VertexShaderOutput output = (VertexShaderOutput) 0;

    float3 worldPosition = mul(input.Position, World);
    output.Position = mul(input.Position, WorldViewProjection);
    output.UV = input.UV;
    output.Normal = normalize(mul(input.Normal, World));
    output.WorldToTangent[0] = normalize(mul(input.Tangent, World));
    output.WorldToTangent[1] = normalize(mul(input.Bitangent, World));
    output.WorldToTangent[2] = output.Normal;
    output.ViewDirection = normalize(worldPosition - CameraPosition);

    return output;
}

float4 MainPS(VertexShaderOutput input) : COLOR
{
    float3 diffuse = float3(0.5, 0.5, 0.5);
    if (UseDiffuse)
    {
        diffuse = DiffuseColor * tex2D(BasicTextureSampler, input.UV).xyz; // DiffuseColor * Texture
    }
    
    float3 normal = input.Normal;
    if (UseNormalMap)
    {
        normal = tex2D(NormalMapSampler, input.UV).rgb; // NormalMap
        normal = normal * 2 - 1; // Convert range from [0, 1] to [-1, 1]
        normal = normalize(mul(normal, input.WorldToTangent)); 
    }
    
    float3 lightDir = normalize(LightDirection); // Normalize LightDirection for correct dot product results
    float3 lighting = saturate(dot(lightDir, normal)) * LightColor; // Lambertian lighting
    
    if (UseSpecular)
    {
        float3 refl = reflect(lightDir, normal); // Calculate the reflection vector
        lighting += pow(saturate(dot(refl, normalize(input.ViewDirection))), SpecularPower) * SpecularColor; // Add Specular highlights
    }

    float3 output = (saturate(AmbientColor) + lighting) * diffuse; // Calculate the final color
    
    return float4(output, 1);
}

technique BasicColorDrawing
{
    pass P0
    {
        VertexShader = compile VS_SHADERMODEL MainVS();
        PixelShader = compile PS_SHADERMODEL MainPS();
    }
};
