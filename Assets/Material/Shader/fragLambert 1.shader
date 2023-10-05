Shader "Unlit/fragLambert"
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
                fixed3 worldNormalDir : TEXCOORD0;
            };


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.pos);
                o.worldNormalDir =  UnityObjectToWorldNormal(v.normal);
                //o.worldNormalDir = worldNormalDir;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed3 amb = UNITY_LIGHTMODEL_AMBIENT.xyz;
               // fixed3 worldNormal = normalize(i.worldNormalDir);
                fixed3 worldLight = normalize(_WorldSpaceLightPos0.xyz);
                fixed3 diff = _LightColor0.rgb * _Diffuse.rgb * max(0,dot(i.worldNormalDir,worldLight));
                fixed3 tmpcolor = diff + amb;
                return fixed4(tmpcolor,1) ;
            }
            ENDCG
        }
    }
}
