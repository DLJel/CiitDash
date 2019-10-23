using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	public float initialCounter = 5;
	public Slider disciplineBar, gameOverBar;
	public GameObject gameOverScreen;
	private static GameManager instance;
	public float timer = 0f, gameOver, gameOverMax;//720f;
	public bool isGameOver = false;
	public GameObject clock;
	public int clockRounds;
	public int isSeated = 0;
	public static GameManager Instance
	{
		get{return instance; }
	}

	public Sprite[] clockHands;

	public SpriteRenderer renderer;

	public GameObject[] students, chairs;

	public Text howToPlay;
	public int studentNotSeated;
	public bool canDiscipline = true, bool1, bool2, bool3, bool4, bool5;

	void Start () 
	{
//		Time.timeScale = 0;
		Time.timeScale = 1;
		disciplineBar.maxValue = initialCounter;
		chairs = GameObject.FindGameObjectsWithTag("Chair");
	}

	void Awake()
	{
		instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		students = GameObject.FindGameObjectsWithTag ("Student");
		studentNotSeated = 0;
//		if (students.Length >= chairs.Length) 
//		{
//			isGameOver = true;
//		}
//		if (isGameOver) 
//		{
//			
//		}
		if (bool1 && bool2 || bool3 && bool4 || bool5) 
		{
			Debug.Log ("Works");
		}
		if (isGameOver) 
		{
			gameOver = gameOver - 1f * Time.deltaTime;
			gameOverBar.value = gameOver;
			gameOverBar.gameObject.SetActive (true);
			if (gameOver <= 0) 
			{
//				GameOver ();
				Bells.Instance.ChangeLife (false);
				gameOver = gameOverMax;
			}
		} 
		else if (!isGameOver) 
		{
			gameOver = gameOverMax;
			gameOverBar.gameObject.SetActive (false);
		}
		foreach (GameObject student in students) 
		{
			if (!student.GetComponent<Student> ().isSeated && !student.GetComponent<Student> ().selected || student.GetComponent<Student> ().selected) 
			{
				studentNotSeated++;
				if (studentNotSeated >= 5) 
				{
					isGameOver = true;
				} 
				else if (studentNotSeated <= 5) 
				{
					isGameOver = false;
				}
			}
		}
		if (!canDiscipline) 
		{
//			disciplineBar.maxValue = disciplineBar.maxValue + 1f;
			disciplineBar.value = disciplineBar.value + 1 * Time.deltaTime;
			if (disciplineBar.value == disciplineBar.maxValue) 
			{
				canDiscipline = true;
//				disciplineBar.value = 0;
			}
		}
		timer = timer + 1 * Time.deltaTime;
		if (timer > 3 && timer < 6) 
		{
			renderer.sprite = clockHands [1];
		}
		else if (timer > 6 && timer < 9) 
		{
			renderer.sprite = clockHands [2];
		}
		else if (timer > 9 && timer < 12) 
		{
			renderer.sprite = clockHands [3];
		}
		else if (timer > 12 && timer < 15) 
		{
			renderer.sprite = clockHands [0];
			timer = 0;
		}
	}

	public void GameOver()
	{
		gameOverScreen.SetActive (true);
		GameObject[] student;
		student = GameObject.FindGameObjectsWithTag ("Student");
		foreach (GameObject stud in student) 
		{
			Destroy (stud);
		}
		Time.timeScale = 0;
	}

	public void CanDiscipline(bool canI)
	{
		canDiscipline = canI;
	}
}
