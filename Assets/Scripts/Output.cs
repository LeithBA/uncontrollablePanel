using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Output : MonoBehaviour {

	public List<GameObject> leds, gauges;
	GameObject ledsContainer, gaugesContainer;

	void Start ()
	{
		ledsContainer = transform.Find("Leds").gameObject;
		gaugesContainer = transform.Find("Gauges").gameObject;

		for (int i = 0; i < ledsContainer.transform.childCount; i ++)
		{
			leds.Add(ledsContainer.transform.GetChild(i).gameObject);
		}

		for (int i = 0; i < gaugesContainer.transform.childCount; i ++)
		{
			gauges.Add(gaugesContainer.transform.GetChild(i).gameObject);
		}
	}
}
