Shader "Custom/IceBallShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_ScrollVector("Scroll Speed/Direction", vector) = (0.0, 20.0, 0.0, 0.0)
	}
	SubShader
	{
		// No culling or depth
		Tags { "RenderType" = "Opaque" }

		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _ScrollVector;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv += _ScrollVector * _Time.x;
				return o;
			}
			
			

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				// just invert the colors
				
				return col;
			}
			ENDCG
		}
	}
}
