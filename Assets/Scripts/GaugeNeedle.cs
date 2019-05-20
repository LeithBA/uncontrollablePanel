using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeNeedle : MonoBehaviour
{

    [Range(0.0f, 1.0f)]public float value = 0.5f;
    private float rotAngle;

    void Update()
    {
		value = Mathf.Clamp(value + Random.Range(-0.01f, 0.01f), 0.0f, 1.0f);

        Map(value, 0.0f, 1.0f, -45, 45);
		this.transform.rotation =  Quaternion.Euler(0, 0, -rotAngle);
    }

    void Map(float value, float from1, float to1, float from2, float to2)
    {
		rotAngle = (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

}
