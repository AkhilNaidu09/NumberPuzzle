using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeOn : MonoBehaviour {

	GameController gameMN;

	// Use this for initialization
	void Start () {
		GameObject gameManager = GameObject.Find ("GameController");
		gameMN = gameManager.GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnClick(){
		if (gameMN.mute) {
			gameMN.mute = false;
		} else {
			gameMN.mute = true;
		}
	}
}
