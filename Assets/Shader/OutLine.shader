Shader "Outlined/Silhouetted Diffuse Transparent/Black" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" { }
	}

		CGINCLUDE
#include "UnityCG.cginc"

		struct appdata {
		float4 vertex : POSITION;
		float2 uv : TEXCOORD0;
	};

	struct v2f {
		float4 pos : SV_POSITION;
		float2 uv : TEXCOORD0;
	};

	sampler2D _MainTex;

	v2f vert(appdata v) {
		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		o.uv = v.uv;
		return o;
	}

	fixed4 frag(v2f i) : SV_Target{
	fixed4 texColor = tex2D(_MainTex, i.uv);
	// Si el color es negro, establece la transparencia a 0
	if (texColor.r == 0 && texColor.g == 0 && texColor.b == 0) {
		texColor.a = 0;
	}
	return texColor;
	}
		ENDCG

		SubShader {
		Tags{ "Queue" = "Transparent" }

			Pass{
				Name "BASE"
				ZWrite On
				Blend SrcAlpha OneMinusSrcAlpha

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				ENDCG
		}
	}

	Fallback "Diffuse"
}
