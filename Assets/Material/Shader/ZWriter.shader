Shader "MyShader/ZTest02"
{
   Properties {
        _MainTex("纹理图片",2D)=""{}
        _SecondTex("纹理图片二",2D)=""{}
        _DiffuseColor("漫反射颜色值",Color)=(1,0,0,1)
        _MainTexColor("混合颜色",COLOR) = (1,0,0,1)
        _SecondColor("混合颜色",COLOR) = (1,0,0,1)
    }
    SubShader {
        Pass
        {
            Lighting On
            Material{
                Diffuse[_DiffuseColor]
            }
            //设置纹理
            SetTexture[_MainTex]
            {
                ConstantColor[_MainTexColor]
                //融合纹理和其他
                //ComBine:融合命令
                Combine texture * Constant
            }
            SetTexture[_SecondTex]
            {
                ConstantColor[_SecondColor]
                Combine texture lerp(Constant) previous
            }

        }
        
    }
    FallBack "Diffuse"
}
