Shader "Custom/FlagMaterialShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_DisplaceTex("DisplacementTexture", 2D) = "white"{}
		//_Magnitude("Magnitude", Range(0, 0.2)) = 1
	}
		SubShader
		{
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
				sampler2D _DisplaceTex;
				//float _Magnitude;

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.uv, _MainTex);
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					float2 disp = tex2D(_DisplaceTex, i.uv).x; //pääty voi olla x, y tai xy
					disp = ((disp * 2) - 1)/* * _Magnitude*/; //näiden arvojen kanssa voi kikkailla jos kommentit pois täst ja rivilt 7, fuck wit these if u want i dont care im a comment not the cops

					fixed4 col = tex2D(_MainTex, i.uv + disp + float2(i.vertex.x / 100000 + _Time[0], 0));
					//fixed4 col = tex2D(_MainTex, i.uv + disp + float2(sin(i.vertex.x / 50 + _Time[1]), sin(i.vertex.y / 50 + _Time[1])));

					return col;
				}
				ENDCG
			}
		}
}
