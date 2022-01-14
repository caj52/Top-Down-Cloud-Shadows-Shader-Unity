Shader "Custom/CloudShadows"
{
    Properties
    {
        _ShadowDensity ("Shadow Density", Range(0.0, 1.0)) = .45
        _ShadowColor ("Shadow Color", Color) = (1,1,1,0)
        _MainTex ("Texture", 2D) = "white" {}
        _OpacityModifier("Opacity Modifier", float) = 0
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        LOD 200
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows alpha:fade
        
        #pragma target 3.0

        sampler2D _MainTex;
        fixed3 _ShadowColor;
        float _ShadowDensity;
        float _OpacityModifier;
        struct Input
        {
            float2 uv_MainTex;
        };
        
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            if(c.r<=_ShadowDensity)
            {
                c.a=abs(c.r-(1*abs(c.r-1)));
                c.a+= _OpacityModifier*c.a;
                c.a=clamp(c.a,0,.5);
                c.rgb*=_ShadowColor;
            }
            if(c.r>_ShadowDensity)
            {
                clip(o.Alpha - 1.0);
            }
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
