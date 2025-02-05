Shader "Example/TestShaderDoc"
{
    // The _BaseColor variable is visible in the Material's Inspector, as a field
    // called Base Color. You can use it to select a custom color. This variable
    // has the default value (1, 1, 1, 1).
    Properties
    {
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
                half3 normal        : NORMAL;   
                float2 uv           : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                float2 uv           : TEXCOORD0;
            };

            // To make the Unity shader SRP Batcher compatible, declare all
            // properties related to a Material in a a single CBUFFER block with
            // the name UnityPerMaterial.
            CBUFFER_START(UnityPerMaterial)
                // The following line declares the _BaseColor variable, so that you
                // can use it in the fragment shader.
                half4 _BaseColor;
                half4 _SecondColor;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                VertexPositionInputs _VertexPosition = GetVertexPositionInputs(IN.positionOS.xyz);
                _VertexPosition.positionWS;
                VertexNormalInputs _NormalVertex = GetVertexNormalInputs(IN.positionOS.xyz);
                _NormalVertex.normalWS;
                OUT.uv = IN.uv;
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                // Returning the _BaseColor value.
                return lerp(_BaseColor, _SecondColor, (sin(_Time.y) + 1) / 2);
            }
            ENDHLSL
        }
    }
}
