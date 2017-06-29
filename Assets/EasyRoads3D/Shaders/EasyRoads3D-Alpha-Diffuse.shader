Shader "EasyRoads3D/Transparent/Diffuse" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}

}

SubShader {
	Tags { "Queue"="Geometry+1"}
	LOD 200
	Offset -5, -5

CGPROGRAM
#pragma surface surf Lambert decal:blend
#pragma target 2.0

sampler2D _MainTex;
fixed4 _Color;
float _RefrDistort;



struct Input {
	float2 uv_MainTex;
	float4 color : Color;
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
	o.Albedo = c.rgb;
	o.Alpha = c.a * IN.color.a;
}
ENDCG
}

Fallback "Transparent/VertexLit"
}
