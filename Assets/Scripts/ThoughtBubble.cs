using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBubble : MonoBehaviour 
{
	public float thinktimer = 3, thinktimermax = 3;
	public bool check;
	public Thoughts thoughtscript;
	public Sprite[] emotions;
	public AnimationClip[] emotionsClip;
	public Animator curEmotion;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		if (check) 
		{
			thinktimer = thinktimer - 1 * Time.deltaTime;
		}
		if (thinktimer <= 0 && check) 
		{
			check = false;
			thoughtscript.ResetThoughts ();
			thinktimer = thinktimermax;
			this.gameObject.SetActive (check);
		}
	}

	void OnEnable()
	{
		Debug.Log ("Active");
	}
}
