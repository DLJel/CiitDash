using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour 
{
	public AudioClip hoverButton, pressButton;
	public AudioSource source;

	void Start () {
		
	}

	void Update () {
		
	}

	void OnMouseEnter()
	{
		source.PlayOneShot (hoverButton);
		Debug.Log (this.gameObject);
	}

	void OnMouseDown()
	{
		
	}
}
