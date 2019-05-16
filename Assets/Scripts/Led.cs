using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Led : MonoBehaviour {

	[Range(0.0f, 1.0f), SerializeField] float hue, saturation, brightness;

	void Start()
	{
		hue = Random.Range(-0.0f, 1.0f);
	}
	void Update () 
	{
		hue = hue + Random.Range(-0.01f, 0.01f);
		if (hue < 0)
			hue++;
		else if (hue > 1)
			hue--;
		this.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(hue, saturation, brightness);
	}
}
