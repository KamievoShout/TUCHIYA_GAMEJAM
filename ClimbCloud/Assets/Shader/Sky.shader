Shader "Unlit/Sky"
{
    Properties
    {
        _SkyDayColor ("SkyDayColor", Color) = (1, 1, 1, 1)
        _SkyNightColor ("SkyNightColor", Color) = (1, 1, 1, 1)
        _SkyDownColor ("SkyDownColor", Color) = (1, 1, 1, 1)
        _Day ("Day", Range(0, 1)) = 0.5
        _Power ("Power", float) = 10.0

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float3 _SkyDayColor;
            float3 _SkyNightColor;
            float3 _SkyDownColor;
            float _Day;
            float _Power;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            void Posterize(float2 In, float2 Steps, out float2 Out)
            {
                Out = floor(In / (1 / Steps)) * (1 / Steps);
            }

            float4 frag (v2f i) : SV_Target
            {
                float2 uv = (float2)0;
                // Posterize(i.uv.xy, float2(25, 25), out uv);
                float3 col = (float3)0.;
                float3 skyUpColor = lerp(_SkyNightColor, _SkyDayColor, _Day);
                col = lerp(_SkyDownColor, skyUpColor, 1. / (1. + exp(-i.uv.y * _Power)));

                // col = floor(col / (1 / (float3)35)) * (1 / (float3)35);
                return float4((float3)col, 1.);
            }
            ENDCG
        }
    }
}
