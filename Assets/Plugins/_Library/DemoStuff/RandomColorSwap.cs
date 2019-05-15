using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorSwap : MonoBehaviour
{
	public Color colorFrom;

	public Color colorTo;


    // Start is called before the first frame update
    void Start()
    {
		Color color = Color.Lerp(colorFrom, colorTo, Random.value);

		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.material.SetColor("_Replace1", color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
