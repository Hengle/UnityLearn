Shader "Unlit/01"
{
    Properties
    {
        _Int("Int" , Int) = 2
        _Float("Float" , float) = 1.5
        _Rang("Range", range(0.0,2.0)) = 1.0
        _Color("Color", Color)= (1,1,1,1)
        _Vector("Vector",Vector) = (1,4,3,8)
        _MainTex ("Texture", 2D) = "white" {}
        _Cube("Cube",Cube) = "white"{}
        _3D("3D", 3D) = "black"
    }
    SubShader
    {
        //可选
        Tags 
        {
            "Queue" = "Transparent"  //渲染顺序
            "RenderType"="Opaque"    //渲染类型，着色器替换功能
            "DisableBatching" = "True" //关闭合批
            "ForceNoShadowCasting" = "True" //控制是否投射阴影
            "IgnoreProjector"="True" //受不受projector影响，通常用于透明物体
            "CanUseSpriteAltas" = "False" //是否用于图片的shader
            "PreviewType" = "Plane" //用于shader面板预览的类型
        }
        
        //可选
        // Cull （off/back/font)   渲染裁切， 
        // ZTest (Always, Less Greater, LEqual/Gequal/Equal/NotEqual) 深度测试
        // Zwrite (off,on) 深度写入
        //Blend (SrcFactor DstFactor) 混合 
        // LOD 100  不同情况下使用不同的LOD达到性能提升 ，代码可控制

        //必须
        Pass
        {
            //Tags{} 可以在每个pass通道里面定义， 如果外面有，则以外面为准

            //CG语言缩写的代码，主要是顶点片元着色器
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }

    //Fallback "xxxxxxx" Fallback Off  //当上面shader运行不了的情况会使用fallback渲染
}
