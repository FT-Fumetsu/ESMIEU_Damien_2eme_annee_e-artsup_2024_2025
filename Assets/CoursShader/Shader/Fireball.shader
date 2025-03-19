Shader "Custom/Fireball"
{
    Properties
    {
        [MainTexture] _MainTexture ("Texture", 2D) = "white" {}
        [MainColor] [HDR] _BaseColor ("Base Color", Color) = (1,1,1,1)
        [HDR] _SecondColor ("Secondary Color", Color) = (1,0,0,1)
        _FresnelColor ("Fresnel Color", Color) = (1,1,1,1)
        _FresnelPower ("Fresnel Power", Range(0.1, 5)) = 1.0
        _Speed ("Scroll Speed", Float) = 1.0
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
                float _Speed;
            CBUFFER_END

            sampler2D _MainTexture;

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionCS = UnityObjectToClipPos(IN.position);
                OUT.normalWS = UnityObjectToWorldNormal(IN.normal);
                OUT.uv = IN.uv + float2(0, _Time.y * _Speed);
                OUT.viewDirWS = normalize(UnityWorldSpaceViewDir(mul(unity_ObjectToWorld, IN.position).xyz));
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                half4 textureColor = tex2D(_MainTexture, IN.uv);
                textureColor = lerp(_BaseColor, _SecondColor, textureColor);
                
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
