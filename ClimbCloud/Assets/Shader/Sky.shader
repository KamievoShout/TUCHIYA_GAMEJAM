Shader "Unlit/Sky"
{
    Properties
    {
        _SkyUpColor ("SkyUpColor", Color) = (1, 1, 1, 1)
        _SkyDownColor ("SkyDownColor", Color) = (1, 1, 1, 1)
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

            float3 _SkyDownColor;
            float3 _SkyUpColor;
            float _Power;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                float3 col = (float3)0.;
                col = lerp(_SkyDownColor, _SkyUpColor, 1. / (1. + exp(-i.uv.y * _Power)));
                return float4((float3)col, 1.);
            }
            ENDCG
        }
    }
}
