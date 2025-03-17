Shader "Custom/BubblegumShader"
{
    Properties
    {
        [MainColor] [HDR] _BaseColor("Base Color", Color) = (1, 1, 1, 1)
        [HDR] _FlashColor("Flash Color", Color) = (1, 1, 1, 1)
        //_FlashFrequency ne marche pas, ça me fait une erreur quand je remplace le 2 dans le sin par cette property
        _FlashFrequency("Flash Frequency", Int) = 2
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
                half4 _BaseColor;
                half4 _FlashColor;
                float _FlashFrequency;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                    float lerpFactor = 0.5 + 0.5 * sin(_Time.y * _FlashFrequency);
                    OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz * lerp(1, 2, lerpFactor));
                    OUT.uv = IN.uv;
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                float lerpColor = 0.5 + 0.5 * sin(_Time.y * _FlashFrequency);
                return lerp(_BaseColor, _FlashColor, lerpColor);
            }
            ENDHLSL
        }
    }
}
