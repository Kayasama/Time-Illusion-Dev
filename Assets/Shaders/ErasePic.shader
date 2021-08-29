Shader "Custom/ErasePic"
{
	Properties
	{

		_MainTex("Texture", 2D) = "white" {}

		_BlitTex("BlitTexture", 2D) = "white"{}
	}
		SubShader
	{
		Tags { "Queue" = "AlphaTest" "IgnoreProjector" = "True" "RenderType" = "TransparentCutout" }
		Cull off
		Pass
		{
			Tags{"LightMode" = "ForwardBase"}

		
			// 开启alpha混合
			Blend SrcAlpha OneMinusSrcAlpha

		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#include "Lighting.cginc"
		#include "UnityCG.cginc"

		// Use shader model 3.0 target, to get nicer looking lighting

		sampler2D _MainTex;
		float4 _MainTex_ST;
		sampler2D _BlitTex;

		struct a2v
		{
			float4 vertex : POSITION;
			float4 texcoord : TEXCOORD0;
		};

		struct v2f
		{
			float4 pos : SV_POSITION;
			float3 worldNormal : TEXCOORD0;
			float3 worldPos : TEXCOORD1;
			float3 uv : TEXCOORD2;
			float4 paintPos : TEXCOORD3;
		};

		
		// 相机的投影矩阵
		float4x4 paintCameraVP;
		
		v2f vert(a2v v)
		{
			v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                
                // 下面三行是通过投影矩阵将顶点变换到像素坐标系中([0, 1])
				float4 paintPos = mul(paintCameraVP, mul(unity_ObjectToWorld, v.vertex));
				paintPos /= paintPos.w; // 除以w分量，如果是相机正交投影可以省略
				o.paintPos.xy = paintPos.xy * 0.5 + 0.5; // 将[-1, 1] 变换到 [0, 1]
                return o;
		}

			fixed4 frag(v2f i) : SV_TARGET0
            {
                fixed4 texcolor = tex2D(_MainTex,i.uv);
                // 划过的轨迹r值为1，所以1 - r作为原图片的alpha值输出
				float mask = tex2D(_BlitTex, i.paintPos).r;
				return fixed4(texcolor.rgb, 1 - mask);
            }

		
		ENDCG
		}
	}
		
}
