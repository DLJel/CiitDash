using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStudents : MonoBehaviour 
{
	public GameObject[] students;
	public GameObject[] studentsSpawned, chairs, studentsInWaiting;
	public Transform[] spawnArea;
	public bool canSpawn = false;
	public float spawnCounterMax;
	public float spawnCounterMin;
	private float spawnCounter;
	public Vector2 spawnoffset;
	public int maxStudent, spawnIndex = 0;

	void Start () 
	{
		chairs = GameObject.FindGameObjectsWithTag ("Chair");
		spawnCounter = spawnCounterMax;
		spawnoffset = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		studentsSpawned = GameObject.FindGameObjectsWithTag ("Student");
		if (maxStudent > studentsSpawned.Length && canSpawn) {
			SpawnAStudent ();
			canSpawn = false;
			spawnCounter = Random.Range(spawnCounterMin, spawnCounterMax);
		} 
		else if (!canSpawn) 
		{
			spawnCounter = spawnCounter - 1 * Time.deltaTime;
		}
		if (spawnCounter <= 0) 
		{
			canSpawn = true;
		}
		if (studentsInWaiting[0] != null && studentsInWaiting [0].GetComponent<Student> ().isSeated || studentsInWaiting [0] == null && studentsInWaiting [1] != null) 
		{
			studentsInWaiting [0] = null;
			spawnIndex--;
			for (int i = 0; i <= 10; i++) 
			{
				if (studentsInWaiting [i + 1] == null) 
				{
					break;
				}
				studentsInWaiting [i] = studentsInWaiting [i + 1];
				studentsInWaiting [i + 1] = null; 
				studentsInWaiting [i].transform.position = spawnArea [i].transform.position;
			}
		}
		if (studentsInWaiting [0] != null) 
		{
			studentsInWaiting [0].GetComponent<Student> ().firstInLine = true;
		}
//		if (studentsInWaiting [0] == null && studentsInWaiting [1] != null) 
//		{
//			
//		}
	}

	public void SpawnAStudent()
	{
		int index;
		index = Random.Range (0, students.Length);
		studentsInWaiting[spawnIndex] = Instantiate (students [index], spawnArea[spawnIndex].transform.position, Quaternion.identity) as GameObject;
		spawnIndex++;
//		spawnoffset.x = spawnoffset.x + .50f;
//		if (TutorialScript.Instance.isTutorialOn) 
//		{
//			TutorialScript.Instance.DragNDrop ();
//		}
	}
}
