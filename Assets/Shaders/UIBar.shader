Shader "UI/UIBar" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
		_FillAmount ("FillAmount" , Float) = 1
		_BarColor ("Bar Color", Color) = (1, 1, 1, 1)
		_BackColor ("Back Color", Color) = (0, 0, 0, 0)
	}
	SubShader {
		Tags {
			"RenderType"="Transparent"
		}
		Cull Off
		Blend SrcAlpha OneMinusSrcAlpha

		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata {
				float4 vertex : POSITION;
				float4 color : COLOR;
				float2 uv : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				float4 color : COLOR;
				float2 uv : TEXCOORD0;
			};

			uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
			uniform float _FillAmount;
			uniform float4 _BarColor;
			uniform float4 _BackColor;
			
			v2f vert (appdata v) {
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.color = v.color;
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target {
				fixed4 tcol = tex2D(_MainTex, i.uv);
				fixed4 col = float4(tcol.rrr, tcol.a) * i.color;
				fixed fill = (1 - step(tcol.g, 1 - _FillAmount));
				col += fill * _BarColor * tcol.a;
				col += (1 - fill) * _BackColor * tcol.a * (1 - tcol.r);
				return col;
			}
			ENDCG
		}
	}
}
