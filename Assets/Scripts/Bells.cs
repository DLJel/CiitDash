using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bells : MonoBehaviour 
{
	private static Bells instance;
	public static Bells Instance
	{
		get{ return instance; }
	}
	public Sprite bellIdle, bellRinging, bellCross;
	public GameObject[] bells = new GameObject[3];
	public int lives = 3;

	void Start () 
	{
		
	}

	void Awake()
	{
		instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (lives == 0) 
		{
			GameManager.Instance.GameOver ();
		}
	}

	public void ChangeLife(bool life)
	{
		if (!life) 
		{
			SpriteRenderer renderer = bells [lives - 1].GetComponent<SpriteRenderer> ();
			renderer.sprite = bellCross;
			lives--;
		}
	}
}
