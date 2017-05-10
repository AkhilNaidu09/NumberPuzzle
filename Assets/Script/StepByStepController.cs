using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepByStepController : MonoBehaviour {

	public int row, col;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}	

	void OnMouseDown(){
		Debug.Log ("Row is row:" + row + "Col is:" + col);
	}
}
