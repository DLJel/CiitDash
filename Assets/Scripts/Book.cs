using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour 
{
	public GameObject buttons, buttons1;
	public Animator bookAnim;

	void Start()
	{
		Time.timeScale = 1;
		bookAnim.Play ("Book");
		MainAnim ();
	}

	void AnimationShowButton()
	{
		buttons.SetActive (true);
		buttons1.SetActive (true);
	}
	// Update is called once per frame
	void Update () 
	{
		
	}

	void MainAnim()
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
}
