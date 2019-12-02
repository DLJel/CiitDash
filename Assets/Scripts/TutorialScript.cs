using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour 
{
	public SpawnStudents spawnScript;
	private static TutorialScript instance;
	public Canvas canv;
	public static TutorialScript Instance
	{
		get{return instance; }
	}
	public string[] tutorialText;
	public bool isTutorialOn, dragNDropFinished, pressTableFinished, pressed = false;
	public GameObject tutorialPanel, studentIndication, tutorialTextBox, yesNoChoice, nextChoice, tutStudent, tutTable;
	public Text tutorialTextbox;
	public int tutIndex = 0;
	public int fontSize;

	void Start () 
	{
		instance = this;
		fontSize = tutorialTextbox.fontSize;
		tutorialText = new string[20];
		tutorialText [0] = "Hello and welcome to CIIT Library!\nWould you like to play the tutorial?";
		tutorialText [1] = "Great!\nThe goal of the game is to ensure that the library is quiet and orderly.";
		tutorialText [2] = "For now, let's wait for a student to appear.";
		tutorialText [3] = "Now here's our first student!";
		tutorialText [4] = "It is a simple matter to move them.\nJust click then drag and drop them to any chair.";
		tutorialText [5] = "Now we wait.\nTake note of the two circles that appeared after you dragged them.";
		tutorialText [6] = "As well as the bar just below the table.";
		tutorialText [7] = "The green circle represents how much time a student has before leaving.";
		tutorialText [8] = "The red circle represents how much noise is the student generating. This affects the bar below the table.";
		tutorialText [9] = "The bar represents the total noise of the table.\nIf full, you will lose a life.";
		tutorialText [10] = "Now let's wait for a bit and watch it fill up.";
		tutorialText [11] = "Uh oh! Looks like the bar is half full! Everytime the bar is complete you will receive a warning.";
		tutorialText [12] = "You have three warnings before the library will be closed down.";
		tutorialText [13] = "To reduce the bar's noise level, just click on the table!";
		tutorialText [14] = "Take note that there is a cooldown before you can click again, as shown by this bar.";
		tutorialText [15] = "Well, that is all and enjoy your stay!";
		tutorialText [16] = "Well, that is all and enjoy your stay!";
		tutorialTextbox.text = tutorialText [0];
		tutorialPanel.SetActive (true);
		Time.timeScale = 0;

	}
	
	// Update is called once per frame
	void Update () 
	{
		tutorialTextbox.fontSize = fontSize;
		if (tutIndex == 17) 
		{
			tutorialPanel.SetActive (false);
			isTutorialOn = false;
			spawnScript.enabled = true;
			Time.timeScale = 1;
		}
		if (tutIndex == 14) 
		{
			pressTableFinished = true;
			tutorialPanel.SetActive (false);
			Time.timeScale = 1;
			Debug.Log ("Tutindex13");
		}
		if (tutIndex == 11) 
		{
			tutorialPanel.SetActive (false);
			dragNDropFinished = true;
			tutStudent.GetComponent<Student> ().tutIndic.SetActive (false);
			tutStudent.GetComponent<Student> ().tableScript.tutIndic.SetActive (false);
			Time.timeScale = 1;
		}

		if (tutIndex == 5) 
		{
			tutorialPanel.SetActive (false);
			Time.timeScale = 1;
		}
		if (tutIndex == 3) {
			tutorialPanel.SetActive (false);
			Time.timeScale = 1;
			tutIndex++;
		} 
		if (isTutorialOn && spawnScript.studentsInWaiting[0] != null && tutStudent == null) 
		{
//			YesTutorial ();
			tutStudent = spawnScript.studentsInWaiting[0];
			DragNDropTut();
		}
		if (tutStudent != null && tutStudent.GetComponent<Student> ().isSeated && !tutStudent.GetComponent<Student> ().selected && !dragNDropFinished) 
		{
			tutorialPanel.SetActive (true);
			studentIndication.SetActive (false);
			tutStudent.GetComponent<Student> ().tutIndic.SetActive (true);
			tutStudent.GetComponent<Student> ().tableScript.tutIndic.SetActive (true);
			Time.timeScale = 0;
		}
		if (isTutorialOn && dragNDropFinished && tutTable != null && tutTable.GetComponent<Table> ().total.value >= 50 && !pressTableFinished) 
		{
			Time.timeScale = 0;
			tutorialPanel.SetActive (true);
		}
	}

	public void YesTutorial()
	{
//		tutorialPanel.SetActive (true);
		yesNoChoice.SetActive(false);
		nextChoice.SetActive (true);
		isTutorialOn = true;
		fontSize = 13;
		tutIndex++;
		tutorialTextbox.text = tutorialText [tutIndex];
//		spawnScript.SpawnAStudent ();
//		studentIndication.SetActive (true);
//		spawnScript.enabled = false;
	}

	public void NoTutorial()
	{
		isTutorialOn = false;
		tutorialPanel.SetActive (false);
//		tutorialTextbox.text = tutorialText [1];
		Time.timeScale = 1;
	}

	public void NextTutorial()
	{
		tutIndex++;
		tutorialTextbox.text = tutorialText [tutIndex];
	}

	public void DragNDropTut()
	{
		tutorialPanel.SetActive (true);
		studentIndication.SetActive (true);
		spawnScript.enabled = false;
		tutorialTextbox.text = tutorialText [tutIndex];
		Time.timeScale = 0;
	}
}
