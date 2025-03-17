//    Shader "Custom/Fireball"
//{
//    Properties
//    {
//        [MainTexture] _MainTexture("Main Texture", 2D) = "red" {}
//        [MainColor] [HDR] _BaseColor("Base Color", Color) = (1, 1, 1, 1)
//        [HDR] _SecondColor("Second Color", Color) = (1, 1, 1, 1)
//        _FresnelColor ("Fresnel Color", Color) = (1, 1, 1, 1)
//        _FresnelPower ("Fresnel Power", Range(0, 10)) = 0
//    }

//    SubShader
//    {
//        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" }

//        Pass
//        {
//            HLSLPROGRAM
//            #pragma vertex vert
//            #pragma fragment frag

//            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

//            struct Attributes
//            {
//                float4 positionOS   : POSITION;
//                float2 uv           : TEXCOORD0;
//                half3 normal        : NORMAL;
//            };

//            struct Varyings
//            {
//                float4 positionHCS  : SV_POSITION;
//                float3 positionWS   : WS_POSITION;
//                float2 uv           : TEXCOORD0;
//                half3 normal        : NORMAL;
//            };

//            CBUFFER_START(UnityPerMaterial)
//                half4 _MainTexture_ST;
//                half4 _BaseColor;
//                half4 _SecondColor;
//                half4 _RimColor;
//                float _FresnelPower;
//            CBUFFER_END

//            TEXTURE2D(_MainTexture);
//            SAMPLER(sampler_MainTexture);

//            Varyings vert(Attributes IN)
//            {
//                Varyings OUT;
//                    OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
//                    OUT.positionWS = TransformObjectToWorld(IN.positionOS);
//                    OUT.uv = TRANSFORM_TEX(IN.uv, _MainTexture);
//                    OUT.normal = IN.normal;
//                return OUT;
//            }

//            half4 frag(Varyings IN) : SV_Target
//            {
//                half4 textureColor = SAMPLE_TEXTURE2D(_MainTexture, sampler_MainTexture, IN.uv + float2(0, 1) * _Time.x);
//                textureColor = lerp(_BaseColor, _SecondColor, textureColor);

//                float3 viewDirection = GetCameraPositionWS() - IN.positionWS;
//                float fresnel = pow(saturate(dot(normalize(IN.normal), normalize(viewDirection))), _FresnelPower);
//                half4 fresnelColor = _RimColor + (1 - fresnel);
//            }
//            ENDHLSL
//        }
//    }
//}
Shader "Custom/Fireball"
{
    Properties
    {
        [MainTexture] _MainTexture ("Texture", 2D) = "white" {}
        [MainColor] [HDR] _BaseColor ("Base Color", Color) = (1,1,1,1)
        [HDR] _SecondColor ("Secondary Color", Color) = (1,0,0,1)
        _FresnelColor ("Fresnel Color", Color) = (1,1,1,1)
        _FresnelPower ("Fresnel Power", Range(0.1, 5)) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct Attributes
            {
                float4 position : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float3 normalWS : NORMAL;
                float2 uv : TEXCOORD0;
                float3 viewDirWS : TEXCOORD1;
            };

            CBUFFER_START(UnityPerMaterial)
                half4 _MainTexture_ST;
                half4 _BaseColor;
                half4 _SecondColor;
                half4 _FresnelColor;
                float _FresnelPower;
            CBUFFER_END

            sampler2D _MainTexture;

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionCS = UnityObjectToClipPos(IN.position);
                OUT.normalWS = UnityObjectToWorldNormal(IN.normal);
                OUT.uv = IN.uv;
                OUT.viewDirWS = normalize(UnityWorldSpaceViewDir(mul(unity_ObjectToWorld, IN.position).xyz));
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                half4 textureColor = tex2D(_MainTexture, IN.uv);
                textureColor = lerp(_BaseColor, _SecondColor, textureColor.r);
                
                // Calcul du Fresnel
                float fresnel = pow(dot(IN.normalWS, IN.viewDirWS), _FresnelPower);
                fresnel = 1.0 - saturate(fresnel);
                
                half4 finalColor = textureColor + _FresnelColor * fresnel;
                return finalColor;
            }
            ENDCG
        }
    }
}
