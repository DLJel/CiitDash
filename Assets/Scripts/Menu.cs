using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour 
{
	public GameObject pausepanel, mainButtons, book;
	private bool ispaused = false, delayStart = false;
	private float delay = 1f;
	public GameObject tutorial;
	private int switchindex;
	private static Menu instance;

	public static Menu Instance
	{
		get{ return instance; }
	}

	[SerializeField] public bool isPaused
	{
		get{ return ispaused; }
		set{ ispaused = value; }
	}

	void AnimationShowButton()
	{
		mainButtons.SetActive (true);
	}

	void Awake () 
	{
		instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		GameObject[] student;
		student = GameObject.FindGameObjectsWithTag ("Student");
		if (Input.GetKeyDown (KeyCode.P) || Input.GetKeyDown (KeyCode.Escape) && !isPaused) 
		{
			pausepanel.SetActive (true); 
			isPaused = true;
			foreach (GameObject stud in student) 
			{
				stud.GetComponent<Student>().canvas.SetActive (false);
			}
			Time.timeScale = 0;
		}
		else if (Input.GetKeyDown (KeyCode.P) || Input.GetKeyDown (KeyCode.Escape) && isPaused) 
		{
			pausepanel.SetActive (false); 
			isPaused = false;
			Time.timeScale = 1;
			foreach (GameObject stud in student) 
			{
				stud.GetComponent<Student>().canvas.SetActive (true);
			}
		}
	}

	public void StartButton()
	{
//		Time.timeScale = 1;
//		SceneManager.LoadScene ("First");
//		delayStart = true;
		switchindex = 1;
		Invoke ("MenuFuncs", delay);
	}

	public void ToMainMenu()
	{
		SceneManager.LoadScene ("TitleScreen");
	}

	public void HowToPlay()
	{
		tutorial.SetActive (true);
		mainButtons.SetActive (false);
	}

	public void Quit()
	{
		Application.Quit ();

	}

	public void MenuFuncs()
	{
		switch (switchindex) 
		{
		case 1:
			Time.timeScale = 1;
			SceneManager.LoadScene ("First");
			break;
		}
	}
}
