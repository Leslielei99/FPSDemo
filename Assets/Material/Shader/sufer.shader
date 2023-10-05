Shader "Unlit/sufer"
{
    Properties
    {
        _diff("∑¥…‰÷µ",COLOR) = (1,0,1,1)
    }
    SubShader
    {
            CGPROGRAM
                    #pragma surface surf Lambert
                    fixed4 _diff;    
                    struct Input{
                            float4 COLOR:COLOR;
                    };
                    void surf(Input In,inout SurfaceOutput o)
                    {
                        o.Albedo = _diff.rgb;
                        o.Alpha = _diff.a;
                    }
            ENDCG
       
       
    }
}
