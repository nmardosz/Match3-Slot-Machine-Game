Shader "Custom/SlotSpinShader" {
	Properties {
                 _MainTex ("Base (RGB)", 2D) = "white" {}
             }
     SubShader {
             Lighting Off
             AlphaTest Greater 0.5
             
         Tags
         { 
             "Queue"="Transparent" 
             "IgnoreProjector"="True" 
             "RenderType"="Transparent" 
             "PreviewType"="Plane"
             "CanUseSpriteAtlas"="True"
         }
         
         Cull Off
         Lighting Off
         ZWrite Off
         Fog { Mode Off }
         Blend One OneMinusSrcAlpha
         LOD 200
         
     CGPROGRAM
     #pragma surface surf NoLighting
     #include "UnityCG.cginc"
     
     fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten){
         fixed4 c;
         c.rgb = s.Albedo;
         c.a = s.Alpha;
         return c;
     }
     
     sampler2D _MainTex;
     
     struct Input {
         float2 uv_MainTex;
         float3 worldPos;
     };
     
     void surf (Input IN, inout SurfaceOutput o) {
         clip ((IN.worldPos.y /*Adding a value where this text is will change at what height the sprite will not be rendered*/));
         half4 c = tex2D (_MainTex, IN.uv_MainTex);
         o.Albedo = c.rgb;
         o.Alpha = c.a;
     }
     ENDCG
    }
     FallBack "Diffuse"
}
