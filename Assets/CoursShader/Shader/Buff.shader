    Shader "Custom/BuffShader"
{
    Properties
    {
        [MainTexture] _MainTexture("Main Texture", 2D) = "red" {}
        _BuffColor("Buff Color", Color) = (1, 1, 1, 1)
        _BuffPower("Buff Power", Range(0.0, 1.0)) = 1
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
                half4 color         : COLOR;
            };

            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                float2 uv           : TEXCOORD0;
                half4 color        : COLOR;
            };

            TEXTURE2D(_MainTexture);
            SAMPLER(sampler_MainTexture);

            CBUFFER_START(UnityPerMaterial)
                float4 _MainTexture_ST;
                half4 _BuffColor;
                float _BuffPower;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                    OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                    OUT.uv = TRANSFORM_TEX(IN.uv, _MainTexture);
                    OUT.color = IN.color;
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                half4 textureColor = SAMPLE_TEXTURE2D(_MainTexture, sampler_MainTexture, IN.uv);
                half4 invertTextureColor = 1 - textureColor;
                half4 textureBuffedColor = IN.color + (_BuffColor - IN.color) * _BuffPower;

                textureColor = lerp(textureColor, invertTextureColor, _BuffPower) + textureBuffedColor;

                return textureColor;
            }
            ENDHLSL
        }
    }
}
