using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
	public float speed = 0.1f;
	public float speedVerticalNormalized = 0.7f;

    // Update is called once per frame
    void Update()
    {
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		Vector2 direction = new Vector2(x, y);

		if (direction.magnitude > 1f)
		{
			direction = direction.normalized;
		}

		x *= speed;
		y *= speed * speedVerticalNormalized;

		transform.position += new Vector3(x, y);
    }
}
