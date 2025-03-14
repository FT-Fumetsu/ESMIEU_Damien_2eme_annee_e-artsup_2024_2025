Shader "Custom/Fireball"
{
    Properties
    {
        [MainTexture] _mainTexture("Main Texture", 2D) = "red" {}
        [MainColor] [HDR] _baseColor("Base Color", Color) = (1, 1, 1, 1)
        [HDR] _secondColor("Second Color", Color) = (1, 1, 1, 1)
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
                half4 _baseColor;
                half4 _secondColor;
            CBUFFER_END

            TEXTURE2D(_mainTexture);
            SAMPLER(sampler_mainTexture);

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                    OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                    OUT.uv = IN.uv;
                //OUT.uv = TRANSFORM_TEX(IN.uv, _MainTexture);
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                half4 textureColor = SAMPLE_TEXTURE2D(_mainTexture, sampler_mainTexture, IN.uv);

                //return textureColor * _baseColor;
                return lerp(_baseColor, _secondColor, textureColor);
            }
            ENDHLSL
        }
    }
}
