Shader "Unlit/VertLambert"
{
    Properties
    {
       _Diffuse("漫反射颜色",COLOR) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="ForwardBase" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            fixed4 _Diffuse;

            struct appdata
            {
                float4 pos : POSITION;
                float3 normal : NORMAL;//法线
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                fixed3 color : COLOR;
            };


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.pos);
                fixed3 amb = UNITY_LIGHTMODEL_AMBIENT.xyz;
                fixed3 worldNormal = UnityObjectToWorldNormal(v.normal);
                fixed3 worldLight = normalize(_WorldSpaceLightPos0.xyz);
                 // fixed3 diff = _LightColor0.rgb * _Diffuse.rgb * max(0,dot(worldNormal,worldLight));

                fixed3 diff = _LightColor0.rgb * _Diffuse.rgb * (0.5*dot(worldNormal,worldLight)+0.5);
                o.color = diff + amb;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                    return fixed4(i.color,1) ;
            }
            ENDCG
        }
    }
}
