using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thoughts : MonoBehaviour {

	private Student student;
	public GameObject thoughtBubble;
	public bool[] thoughtchance = new bool[4];
	public float thoughtcounter = 3, thoughtcountermax = 3;
	public bool isThinking = true;

	void Start () 
	{
		student = this.gameObject.GetComponent<Student> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (student.isSeated && thoughtcounter > 0 && isThinking) 
		{
			thoughtcounter = thoughtcounter - 1 * Time.deltaTime;
		} 
		else if (student.isSeated && thoughtcounter <= 0 && isThinking) 
		{
			Thinking ();
		}
	}

	void Thinking()
	{
		bool tf;
		tf = thoughtchance [Random.Range (0, thoughtchance.Length)];
		if (tf) 
		{
			thoughtBubble.SetActive (true);
			thoughtBubble.GetComponent<ThoughtBubble> ().check = true;
			isThinking = false;
		}
		else 
		{
			thoughtcounter = thoughtcountermax;
			isThinking = true;
		}
	}

	public void ResetThoughts()
	{
		isThinking = true;
		thoughtcounter = thoughtcountermax;
	}
}
