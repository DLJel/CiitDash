using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour {

	public Slider total;
	public float totalrate;
	public GameObject[] chairs;
	public float[] chairValue = new float[4];
	public int seatedNum = 0;
	private int index = 0;
	private IEnumerator begin;
	public bool isRunning = false;
	public GameManager manager;
	public float counter, maxCounter = 10f;
	public Chair[] chairscript;
	private bool allfalse = false;

	void Start () 
	{
		total.gameObject.SetActive (false);
		manager = GameObject.FindGameObjectWithTag ("Manager").GetComponent<GameManager> ();
		foreach (GameObject chair in chairs) 
		{
			Chair chairScript = chair.GetComponent<Chair> ();
			chairScript.index = index;
			index++;
		}
		begin = BeginTable ();
		counter = maxCounter;
		for (int i = 0; i < chairs.Length; i++) 
		{
			chairscript[i] = chairs [i].GetComponent<Chair> ();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		Check ();
		foreach(float chairValues in chairValue)
		{
			totalrate += chairValues;
		}
		if (!allfalse) 
		{
			total.gameObject.SetActive (false);
		}
		else
		{
			total.gameObject.SetActive (true);
		}
		totalrate = totalrate / (chairs.Length * 2);
		if (total.value == total.maxValue) 
		{
			isRunning = false;
			StopCoroutine (begin);
			total.value = 0;
			totalrate = 0f;
			Bells.Instance.ChangeLife (false);
//			foreach (GameObject chair in chairs) 
//			{
//				Chair chairscript = chair.GetComponent<Chair> ();
//				chairscript.DestroyStudent ();
//			}
			for (int i = 0; i < chairs.Length; i++) 
			{
				Chair chairscript = chairs [i].GetComponent<Chair> ();
				if (chairscript.student != null) 
				{
					Debug.Log ("Destroyed " + i + " Table.");
					chairscript.DestroyStudent ();
				}
			}
		}
//		if (seatedNum != 0) 
//		{
//			total.gameObject.SetActive (true);
//		}
//		else 
//		{
//			total.gameObject.SetActive (false);
//		}
//		foreach (GameObject chair in chairs) 
//		{
//			if (chair.GetComponent<Chair> ().student != null) 
//			{
//				x++;
//				if (x > 1) 
//				{
//					onlyOne = false;
//				} 
//				else if (x <= 1) 
//				{
//					onlyOne = true;
//				}
//			}
//		}
//		if (seatedNum > 0) 
//		{
//			isRunning = true;
//		}
	}

	public void Check()
	{
//		foreach (GameObject chair in chairs) 
//		{
//			Chair chairScript = chair.GetComponent<Chair> ();
//			if (chairScript.studentSeated) 
//			{
//				seatedNum++;
//			}
//		}
//		seatedNum = seatedNum + amount;
		foreach (Chair chairscriptindi in chairscript) 
		{
			if (!chairscriptindi.studentSeated) 
			{
				allfalse = false;
			} 
			else 
			{
				allfalse = true;
				break;
			}
		}
	}

	IEnumerator BeginTable()
	{
		while (isRunning) 
		{
			yield return new WaitForSeconds (3);
			total.value = total.value + totalrate;
		}
	}

	public void BeginTableSwitch()
	{
		isRunning = true;
		StartCoroutine (begin);
	}

	public void Discipline()
	{
		total.value = total.value * .50f;
		GameManager.Instance.disciplineBar.maxValue = GameManager.Instance.disciplineBar.maxValue + .5f;
//		totalrate = totalrate * .50f;
//		for (int i = 0; i < chairs.Length; i++) 
//		{
//			if (chairs [i] != null) 
//			{
//				Chair chairScript = chairs [i].GetComponent<Chair> ();
//				chairScript.DisciplineStudent ();
//			} 
//		}
		foreach (GameObject chair in chairs) 
		{
			Chair chairscript = chair.GetComponent<Chair> ();

			if (chairscript.student != null) 
			{
				chairscript.DisciplineStudent ();
			}
		}
	}

	public void OnMouseOver()
	{
		if (manager.canDiscipline && isRunning) 
		{
			if (Input.GetMouseButtonDown (0)) 
			{
				Discipline ();
				manager.canDiscipline = false;
				manager.disciplineBar.value = 0;
			}
		} 
	}
	public void StopIt()
	{
		StopCoroutine (begin);
	}
}
