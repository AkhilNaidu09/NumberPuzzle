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
		ToggleSound ();
	}

	void ToggleSound()
	{
		//Converting Mouse Pos to 2D (vector2) World Pos
		Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		RaycastHit2D hit=Physics2D.Raycast(rayPos, Vector2.zero, 0f);

		if (hit)
		{
			if(hit.transform.name == "Volume")
			{
				if (gameMN.mute) {
					gameMN.mute = false;
				} else {
					gameMN.mute = true;
				}
			}
		}
	}
}
