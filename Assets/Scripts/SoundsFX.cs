using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsFX : MonoBehaviour 
{
	public static AudioClip hoverButton;
	static AudioSource src;
	public static SoundsFX fxInstance;

	void Start () 
	{
		src = GetComponent<AudioSource> ();
//		fxInstance = this;
		hoverButton = Resources.Load<AudioClip> ("ButtonHover");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public static void playSound(string clip)
	{
		switch(clip)
		{
			case "buttonHover":
				src.PlayOneShot (hoverButton);
				break;
		}
			
	}
}
