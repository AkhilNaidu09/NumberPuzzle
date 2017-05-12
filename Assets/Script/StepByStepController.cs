using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepByStepController : MonoBehaviour {

	public int row, col;
	GameController gameMN;

	// Use this for initialization
	void Start () {
		GameObject gameManager = GameObject.Find ("GameController");
		gameMN = gameManager.GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}	

	void OnMouseDown(){
		Debug.Log ("Row is row:" + row + "Col is:" + col);
		gameMN.countStep += 1;
		gameMN.col = col;
		gameMN.row = row;
		gameMN.startControl = true;
	}
}
