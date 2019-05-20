using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	[SerializeField] AudioClip sound;
	private AudioSource AS;
	void Start () {
		AS = Camera.main.GetComponent<AudioSource>();
	}

	public void PlaySound () 
	{
		if (sound)
			AS.PlayOneShot(sound);
	}
}
