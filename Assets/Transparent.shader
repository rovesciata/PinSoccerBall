Shader "Custom/Transparent"
{
    //Properties
    //{
    //    _Color ("Color", Color) = (1,1,1,1)
    //    _MainTex ("Albedo (RGB)", 2D) = "white" {}
    //    _Glossiness ("Smoothness", Range(0,1)) = 0.5
    //    _Metallic ("Metallic", Range(0,1)) = 0.0
    //}
    SubShader {
        Tags { "Queue" = "Transparent" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard alpha:fade 
        #pragma target 3.0

        struct Input {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o) {
            o.Albedo = fixed4(0.6f, 0.7f, 0.4f, 1);
            o.Alpha = 0.6;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
