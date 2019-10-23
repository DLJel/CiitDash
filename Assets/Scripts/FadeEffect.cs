using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour 
{
	public Image img;

	void Start () 
	{
		img = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnEnable()
	{
		img.color = new Color (1, 1, 1, 0);
		FadeIn ();
	}

	public void FadeIn()
	{
		for (float i = 0; i <= 1; i = i + .01f * Time.deltaTime) 
		{
			img.color = new Color (1, 1, 1, i);
			Debug.Log ("fade");
		}

	}
}
