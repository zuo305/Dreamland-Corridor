Shader "Custom/Gaussian Blur"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_BlurSize("Blur Size", Float) = 1
	}

	SubShader
	{
		//通过CGINCLUDE可以把代码段插入到每个pass中去
		CGINCLUDE
		#include "UnityCG.cginc"

		sampler2D _MainTex;
		float4 _MainTex_TexelSize;
		float _BlurSize;

		struct a2v
		{
			float4 pos:POSITION;
			float4 uv:TEXCOORD0;
		};

		struct v2f
		{
			float4 pos:SV_POSITION;
			half2 uvs[5]:TEXCOORD0;
		};

		//竖着模糊
		v2f vertVertical(a2v v)
		{
			v2f o;
			o.pos = UnityObjectToClipPos(v.pos);
			o.uvs[0] = v.uv.xy;
			for (int i = 1; i < 3; i++)
			{
				o.uvs[i] = v.uv.xy;
				o.uvs[i + 2] = v.uv.xy;
				o.uvs[i].y -= i * _BlurSize * _MainTex_TexelSize.y;
				o.uvs[i + 2].y += i * _BlurSize * _MainTex_TexelSize.y;
			}
			return o;
		}

		//横着模糊
		v2f vertHorizontal(a2v v)
		{
			v2f o;
			o.pos = UnityObjectToClipPos(v.pos);
			o.uvs[0] = v.uv.xy;
			for (int i = 1; i < 3; i++)
			{
				o.uvs[i] = v.uv.xy;
				o.uvs[i + 2] = v.uv.xy;
				o.uvs[i].x -= i * _BlurSize * _MainTex_TexelSize.x;
				o.uvs[i + 2].x += i * _BlurSize * _MainTex_TexelSize.x;
			}
			return o;
		}

		fixed4 frag(v2f f) : SV_TARGET
		{
			fixed4 o;
			//这个数组一定要放到函数里面才能起效，函数外，GLSL编译会报错。不知道为啥。
			float weight[3] = {0.4026, 0.2442, 0.0545};
			o = tex2D(_MainTex,f.uvs[0]) * weight[0];
			for (int i = 1; i < 3; i++)
			{
			o += tex2D(_MainTex,f.uvs[i]) * weight[i];
			o += tex2D(_MainTex,f.uvs[i + 2]) * weight[i];
			}
			o.a = 1;
			return o;
		}

		ENDCG

		Pass
		{
			NAME "GAUSSIAN_BLUR_VERTICAL"
			CGPROGRAM
			#pragma vertex vertVertical
			#pragma fragment frag
			ENDCG
		}

		Pass
		{
			NAME "GAUSSIAN_BLUR_HORIZONTAL"
			CGPROGRAM
			#pragma vertex vertHorizontal
			#pragma fragment frag
			ENDCG
		}
	}
	Fallback "Diffuse"
}
