using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Student : MonoBehaviour {

	public float noiseRate;
	public float progressRate;
	public Slider progressBar;
	public Slider noiseBar;
	public GameObject table, canvas;
	public Table tableScript;
	public bool activitySwitch = false, facingRight, selected, isSeated, firstInLine = false, playAnimation;
	private float noiseratefloat;
	private IEnumerator coroutine;
	public float moveSpeed;
	public float offset = 0.05f;
	public Sprite standingPose;
	public Sprite[] sittingPose;
	public SpriteRenderer renderer;
	public Image progressFill, noiseFill;
	public GameObject chair, progressCircle, noiseCircle, tutIndic;
	public Animator animator;

	void Start () 
	{
		animator = GetComponent<Animator> ();
		renderer = GetComponent<SpriteRenderer> ();
		coroutine = AddNoise();
		selected = false;
		isSeated = false;
		progressCircle.gameObject.SetActive (false);
		noiseCircle.gameObject.SetActive (false);
//		BeginStudent ();
	}

	void Update () 
	{
//		animator.SetBool("IsSeated", isSeated);
		if (isSeated && !selected) 
		{
			progressCircle.gameObject.SetActive (true);
			noiseCircle.gameObject.SetActive (true);
		}
		if (TutorialScript.Instance.isTutorialOn && isSeated && !selected && table != null) 
		{
			TutorialScript.Instance.tutTable = table;
		}
//		if (progressBar.value == 100) 
//		{
//			if (tableScript.isRunning) 
//			{
//				tableScript.seatedNum--;
//				Destroy (this.gameObject);
//			} 
//			else if (tableScript.seatedNum == 1) 
//			{
//				tableScript.StopIt ();
//				tableScript.seatedNum--;
//				Destroy (this.gameObject);
//			}
//		}

//		if (progressBar.value == progressBar.maxValue) 
//		{
//			table.GetComponent<Table> ().total.value = table.GetComponent<Table> ().total.value - 10;
//			Destroy (this.gameObject);
//		}
		if (Input.GetMouseButton (0)) 
		{

//			if (!selected) {
//				selected = true;
//			} 
			if (selected && !Menu.Instance.isPaused) {
				transform.position = Vector2.Lerp (transform.position, Camera.main.ScreenToWorldPoint (Input.mousePosition), moveSpeed);
			}
		}
//		if (selected) 
//		{
//			transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), moveSpeed);
//		}
		else if (selected) 
		{
			selected = false;
//			Debug.Log ("Selected");
		}
		if (isSeated) 
		{
			animator.Play ("Sitting");
			if (facingRight) 
			{
//				renderer.sprite = sittingPose [0];
				renderer.flipX = false;
				renderer.sprite = standingPose;
//				playAnimation = true;
			} 
			else 
			{
//				renderer.sprite = sittingPose [1];
				renderer.flipX = true;
				renderer.sprite = standingPose;
//				playAnimation = true;
			}
		} 
		else 
		{
			renderer.sprite = standingPose;
			animator.Play ("Idle");
		}
//		if (playAnimation) 
//		{
//			animator.Play ("Man2Sitting");
//		}
	}

//	void OnTriggerEnter2D(Collider2D col)
//	{
//		Debug.Log ("lol");
//	}

	void OnMouseDown()
	{
		if (!selected && firstInLine) 
		{
			selected = true;
		}	
	}

	IEnumerator AddNoise ()
	{
		Debug.Log ("working");
		while (activitySwitch) 
		{
			yield return new WaitForSeconds (0.5f);
			Debug.Log ("counting");
			noiseBar.value = noiseBar.value + noiseRate;
			progressBar.value = progressBar.value + progressRate;
			progressFill.fillAmount += progressRate*0.01f;
			noiseFill.fillAmount += noiseRate*0.01f;
//			noiseRate = noiseRate + (progressBar.value * 0.001f);
//			progressRate = progressRate + (noiseBar.value * 0.001f / 2f);
		}
	}

	public void BeginStudent()
	{
		Debug.Log ("Started");
		StartCoroutine (coroutine);
	}

	public void StopStudent()
	{
		Debug.Log ("Finish");
		StopCoroutine (coroutine);
	}

//	IEnumerator AddProgress()
//	{
//		
//	}

	public void Clear()
	{
		isSeated = false;
		StopStudent ();
		chair.GetComponent<Chair> ().student = null;
		chair.GetComponent<Chair> ().studentScript = null;
		chair.GetComponent<Chair> ().studentSeated = false;
//		studentScript.isSeated = false;
//		studentScript.StopStudent ();
//		studentScript = null;
//		student = null;
//		studentSeated = false;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Student") 
		{
			Physics2D.IgnoreCollision (col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		}
	}
}
