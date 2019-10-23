using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour 
{
	public bool isSeated;
	public GameObject student;
	public GameObject table;
	public Table tableScript;
	public Student studentScript;
	public bool studentSeated = false;
	public float noiseBarValue = 0;
	public Vector3 offsetFacingRight, offsetFacingLeft;
	public bool facingRight;
	public int index;

	// Use this for initialization
	void Start () 
	{
		offsetFacingRight = new Vector3 (0.17f, 0.28f, 0);
		offsetFacingLeft = new Vector3 (-0.17f, 0.28f, 0);
		tableScript = table.GetComponent<Table> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (studentScript != null && studentScript.progressBar.value == studentScript.progressBar.maxValue) 
		{
			Destroy (student);
			tableScript.seatedNum--;
			if (tableScript.seatedNum == 0) 
			{
				tableScript.StopIt ();
			}
		}
		if (student != null) 
		{
			if (facingRight) 
			{
				studentScript.facingRight = true;
			} 
			else 
			{
				studentScript.facingRight = false;
			}
			if (!studentScript.selected)
			{
				if (facingRight) 
				{
					
					student.transform.position = this.transform.position + offsetFacingRight;
				} 
				else 
				{
					
					student.transform.position = this.transform.position + offsetFacingLeft;

				}
			}
			if (!studentSeated && !studentScript.selected) 
			{
				studentScript.BeginStudent ();
				studentSeated = true;
				studentScript.table = table;
				studentScript.tableScript = tableScript;
				studentScript.activitySwitch = true;
//				tableScript.Check (1);
			}
//			if (studentSeated && student.transform.position != this.transform.position) 
//			{
//				student = null;
//				studentScript = null;
//			}
			noiseBarValue = studentScript.progressBar.value;
			tableScript.chairValue [index] = noiseBarValue;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Student" && !col.gameObject.GetComponent<Student>().isSeated && student == null) 
		{
//			Debug.Log ("Seated");
			student = col.gameObject;
			studentScript = student.GetComponent<Student> ();
			studentScript.isSeated = true;
			studentScript.chair = this.gameObject;
			Debug.Log (isSeated);
			if (!tableScript.isRunning) 
			{
				tableScript.BeginTableSwitch ();
			}
		}
		if (col.gameObject.tag == "Student" && col.gameObject.GetComponent<Student> ().isSeated && student == null) 
		{
			col.gameObject.GetComponent<Student> ().Clear ();
			student = col.gameObject;
			studentScript = student.GetComponent<Student> ();
			studentScript.isSeated = true;
			studentScript.chair = this.gameObject;
		}
		Debug.Log ("Seated");
	}

	void OnTriggerStay2D(Collider2D col)
	{
		Debug.Log ("Seated");
//		student = col.gameObject;
//		studentScript = student.GetComponent<Student> ();
//		studentScript.isSeated = true;
		if (student != null && !studentScript.selected)
		{
			if (facingRight) 
			{

				student.transform.position = this.transform.position + offsetFacingRight;
			} 
			else 
			{

				student.transform.position = this.transform.position + offsetFacingLeft;

			}
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
//		if (col.gameObject == student) 
//		{
//			studentScript.isSeated = false;
//			studentScript.StopStudent ();
//			studentScript = null;
//			student = null;
//			studentSeated = false;
////			tableScript.Check (-1);
//		}
	}

	public void DestroyStudent()
	{
		studentScript.isSeated = false;
		studentScript.StopStudent ();
		Destroy (student);
		studentSeated = false;
	}

	public void DisciplineStudent()
	{
		studentScript.noiseBar.value = studentScript.noiseBar.value * .50f;
//		studentScript.noiseRate = studentScript.noiseRate * .50f;
	}
}
