Shader "Custom/Fireball"
{
    Properties
    {
        [MainTexture] _MainTexture("Main Texture", 2D) = "red" {}
        [MainColor] _BaseColor("Base Color", Color) = (1, 1, 1, 1)
        _SecondColor("Second Color", Color) = (1, 1, 1, 1)

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
                half4 _MainTexture_ST;
                half4 _BaseColor;
                half4 _SecondColor;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = IN.uv;
                OUT.uv = TRANSFORM_TEX(IN.uv, _MainTexture);
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                return lerp(_BaseColor, _SecondColor, _MainTexture_ST);
            }
            ENDHLSL
        }
    }
}
