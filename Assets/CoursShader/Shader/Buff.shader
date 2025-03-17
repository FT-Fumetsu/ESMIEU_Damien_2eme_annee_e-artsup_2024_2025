    Shader "Custom/BuffShader"
{
    Properties
    {
        [MainTexture] _mainTexture("Main Texture", 2D) = "red" {}
        [MainColor] _BuffColor("Buff Color", Color) = (1, 1, 1, 1)
        _BuffPower("Buff Power", Float) = 0.5
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" }

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS   : POSITION;
                float2 uv           : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                float2 uv           : TEXCOORD0;
            };

            CBUFFER_START(UnityPerMaterial)
                half4 _BuffColor;
                float _BuffPower;
            CBUFFER_END

            TEXTURE2D(_mainTexture);
            SAMPLER(sampler_mainTexture);


            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                    OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                    OUT.uv = IN.uv;
                return OUT;
            }

            half4 frag() : SV_Target
            {
                half4 InvertTextureColor = 1 - TextureColor;
                half4 TextureBuffedColor = IN.color * _BuffColor * _BuffPower
                return lerp(TextureBuffedColor, InvertTextureColor, _BuffPower)
            }
            ENDHLSL
        }
    }
}
