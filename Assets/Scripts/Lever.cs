using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {
	public GameObject output;
	public bool win;

	public void WinCheck()
	{
		for (int n = 0; n < output.GetComponent<Output>().leds.Count; n++)
		{
			if (output.GetComponent<Output>().leds[n].GetComponent<Led>().active == false)
			{
				win = false;
				break;
			}
			else win = true;
		}
	}
	public void Quit() {
		Application.Quit();
	}
	private void Update() {
		Debug.Log(win);
	}
}
