using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour {

	public List<GameObject> buttons, levers;
	GameObject buttonsContainer, leversContainer;

	void Start ()
	{
		buttonsContainer = transform.Find("Buttons").gameObject;
		leversContainer = transform.Find("Levers").gameObject;

		for (int i = 0; i < buttonsContainer.transform.childCount; i ++)
		{
			buttons.Add(buttonsContainer.transform.GetChild(i).gameObject);
		}

		for (int i = 0; i < leversContainer.transform.childCount; i ++)
		{
			levers.Add(leversContainer.transform.GetChild(i).gameObject);
		}
	}

	void Update() {
		
	}
}
