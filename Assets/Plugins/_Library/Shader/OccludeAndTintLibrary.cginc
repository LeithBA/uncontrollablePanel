float4 _OccludeColor;
float4 _OutlineColor;

fixed4 SampleSpriteTextureFaded(float2 uv)
{
	fixed4 color = tex2D(_MainTex, uv);

#if UNITY_ETC1_EXTERNAL_ALPHA
	if (_AlphaSplitEnabled)
		color.a = tex2D(_AlphaTex, uv).r;
#endif //UNITY_ETC1_EXTERNAL_ALPHA

	fixed4 tintedColor = _OccludeColor.a * color;

	return tintedColor;
}

fixed4 SampleSpriteTextureTinted(float2 uv)
{
	fixed4 color = tex2D(_MainTex, uv);

#if UNITY_ETC1_EXTERNAL_ALPHA
	if (_AlphaSplitEnabled)
		color.a = tex2D(_AlphaTex, uv).r;
#endif //UNITY_ETC1_EXTERNAL_ALPHA

	fixed4 tintedColor = _OccludeColor;
	tintedColor.a = color.a * _OccludeColor.a;

	return tintedColor;
}
