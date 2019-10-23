using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStudents : MonoBehaviour 
{
	public GameObject[] students;
	public GameObject[] studentsSpawned, chairs;
	public GameObject spawnArea;
	public bool canSpawn = false;
	public float spawnCounterMax;
	public float spawnCounterMin;
	private float spawnCounter;
	public Vector2 spawnoffset;

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
		if (chairs.Length + 5 > studentsSpawned.Length && canSpawn) {
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
	}

	public void SpawnAStudent()
	{
		int index;
		index = Random.Range (0, students.Length);
		Instantiate (students[index], spawnoffset, Quaternion.identity);
		spawnoffset.x = spawnoffset.x + .50f;
	}
}
