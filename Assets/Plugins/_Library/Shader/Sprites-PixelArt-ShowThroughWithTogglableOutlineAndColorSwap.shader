Shader "Sprites/Sprite Show Through With Togglable Outline And Color Swap" {
	Properties{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}		
		_OccludeColor("Occlusion Color", Color) = (1,1,1,1)
		_OutlineColor("Outline Color", Color) = (1,1,1,1)
		[PerRendererData] _showOutline("Show Outline", Float) = 1
		_Tolerance("ReplaceTolerance", Range(0,1)) = 0.001
		_Source1("Source Colour 1", Color) = (1,1,1,1)
		_Replace1("Replace Colour 1", Color) = (1,1,1,1)
		_Source2("Source Colour 2", Color) = (1,1,1,1)
		_Replace2("Replace Colour 2", Color) = (1,1,1,1)
		_Source3("Source Colour 3", Color) = (1,1,1,1)
		_Replace3("Replace Colour 3", Color) = (1,1,1,1)
		_Source4("Source Colour 4", Color) = (1,1,1,1)
		_Replace4("Replace Colour 4", Color) = (1,1,1,1)
		_Source5("Source Colour 5", Color) = (1,1,1,1)
		_Replace5("Replace Colour 5", Color) = (1,1,1,1)
		_Source6("Source Colour 6", Color) = (1,1,1,1)
		_Replace6("Replace Colour 6", Color) = (1,1,1,1)
		_pixelsPerUnit("Pixels Per Unit", Float) = 16
	}
		SubShader{
			Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"PreviewType" = "Plane"
			"CanUseSpriteAtlas" = "True"
		}

			Cull Off
			Lighting Off
			ZWrite Off

			Blend One OneMinusSrcAlpha

			// occluded pass
Pass
		{
			ZTest Greater

			CGPROGRAM
			#pragma target 3.0
			#pragma fragment frag
			#pragma vertex vert
			#pragma multi_compile _ UNITY_ETC1_EXTERNAL_ALPHA
			#include "UnityCG.cginc"
			#include "PixelArtLibrary.cginc"
			#include "ColorSwapLibrary.cginc"
			#include "OccludeAndTintLibrary.cginc"

		v2f vert(appdata_t IN)
		{
			v2f OUT;
			OUT.vertex = UnityObjectToClipPos(IN.vertex);
			OUT.texcoord = IN.texcoord;
			OUT.color = IN.color;;

			return OUT;
		}

		float4 _MainTex_TexelSize;
		float _showOutline;

		fixed4 frag(v2f IN) : SV_Target
		{
			fixed4 c = SampleSpriteTexture(IN.texcoord);

			if (_showOutline < 1)
			{
				return fixed4(0, 0, 0, 0);
			}

			if (c.a == 0) {
				// Get the neighbouring four pixels.
				fixed4 pixelUp = tex2D(_MainTex, IN.texcoord + fixed2(0, _MainTex_TexelSize.y));
				fixed4 pixelDown = tex2D(_MainTex, IN.texcoord - fixed2(0, _MainTex_TexelSize.y));
				fixed4 pixelRight = tex2D(_MainTex, IN.texcoord + fixed2(_MainTex_TexelSize.x, 0));
				fixed4 pixelLeft = tex2D(_MainTex, IN.texcoord - fixed2(_MainTex_TexelSize.x, 0));

				// If one of the neighbouring pixels is invisible, we render an outline.
				if (pixelUp.a != 0 || pixelDown.a != 0 || pixelRight.a != 0 || pixelLeft.a != 0)
				{
					c = SampleSpriteTextureTinted(IN.texcoord, _OutlineColor);

					fixed4 o = c;
					o *= IN.color; // multiply with source color from SpriteRenderer etc.
					o.rgb *= _OutlineColor.a;
					return o;
				}
			}
			else
			{
				c = SampleSpriteTextureFaded(IN.texcoord);
			}

			fixed4 o = c;

			o.rgb = ReplaceFirstSixColors(o.rgb);

			o = _OccludeColor.a * o;

			o *= IN.color; // multiply with source color from SpriteRenderer etc.

			o.rgb *= o.a;

			return o;
		}

		ENDCG
	}

			//////////////////////////////////////////////////////////////

			//////////////////////////////////////////////////////////////

			Pass
		{
			CGPROGRAM
			#pragma fragment frag
			#pragma vertex vert
			#pragma multi_compile _ UNITY_ETC1_EXTERNAL_ALPHA
			#include "UnityCG.cginc"
			#include "PixelArtLibrary.cginc"
			#include "ColorSwapLibrary.cginc"


		v2f vert(appdata_t IN)
		{
			v2f OUT;
			OUT.vertex = UnityObjectToClipPos(IN.vertex);
			OUT.texcoord = IN.texcoord;
			OUT.color = IN.color; // *_Color;

			return OUT;
		}

		fixed4 frag(v2f IN) : SV_Target
		{
			fixed4 c = SampleSpriteTexture(IN.texcoord);

			fixed4 o = c;

			o.rgb = ReplaceFirstSixColors(o.rgb);

			o *= IN.color; // multiply with source color from SpriteRenderer etc.

			o.rgb *= o.a;

			return o;
		}
			ENDCG
		}
	} // SubShader
} // Shader