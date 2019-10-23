using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour 
{
	public GameObject buttons;
	public Animator bookAnim;

	void Start()
	{
		
		AnimationClip clip;
		AnimationEvent evt;
		evt = new AnimationEvent ();
		evt.intParameter = 001;
		evt.time = 1.0f;
		evt.functionName = "AnimationShowButton";
		clip = bookAnim.runtimeAnimatorController.animationClips[0];
		clip.AddEvent (evt);
	}

	void AnimationShowButton()
	{
		buttons.SetActive (true);
	}
	// Update is called once per frame
	void Update () 
	{
		
	}
}
