fixed4 _Source1;
fixed4 _Replace1;
fixed4 _Source2;
fixed4 _Replace2;
fixed4 _Source3;
fixed4 _Replace3;
fixed4 _Source4;
fixed4 _Replace4;
fixed4 _Source5;
fixed4 _Replace5;
fixed4 _Source6;
fixed4 _Replace6;
float _Tolerance;

fixed3 ReplaceColor(fixed3 c, fixed4 source, fixed4 replace)
{
	fixed3 diff = abs(c.rgb - source.rgb);

	float factor = step(length(diff) / _Tolerance, 0.5);

#if defined(SHADER_API_PSSL) // Playstation 4
	return lerp(c, (fixed3)replace, factor);
#else
	return lerp(c, replace, factor);
#endif
}

fixed3 ReplaceFirstSixColors(fixed3 color)
{
	color.rgb = ReplaceColor(color.rgb, _Source1, _Replace1);
	color.rgb = ReplaceColor(color.rgb, _Source2, _Replace2);
	color.rgb = ReplaceColor(color.rgb, _Source3, _Replace3);
	color.rgb = ReplaceColor(color.rgb, _Source4, _Replace4);
	color.rgb = ReplaceColor(color.rgb, _Source5, _Replace5);
	color.rgb = ReplaceColor(color.rgb, _Source6, _Replace6);

	return color;
}