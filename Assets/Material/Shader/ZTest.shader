Shader "MyShader/ZTest"
{
    Properties
    {
    _DiffuseColorFrount("正面漫反射",COLOR) = (1,0,0,1)
    _DiffuseColorBack("反面漫反射",COLOR) = (1,0,0,1)
    _EmissionColor("自发光",COLOR) = (1,0,0,1)
    } 
    SubShader
    {
        //pass
        //{
        //    Lighting On
        //    Cull Back
        //    Material{
        //        DIFFUSE[_DiffuseColorFrount]
        //    }
        //}
        pass
        {
            Lighting On
            Cull Front
            Material{
                DIFFUSE[_DiffuseColorBack]
                Emission[_EmissionColor]
            }
        }
    }
    FallBack "Diffuse"
}
