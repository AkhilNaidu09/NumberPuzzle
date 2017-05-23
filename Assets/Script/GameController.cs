using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	
	public int row,col,countStep;
	public int level;
	public int sizeRow,sizeCol;
	public int rowBlank,colBlank; // Position of image blank
	int countPoint = 0;
	int countImageKey = 0;
	GameObject temp;
	int countComplete = 0;
	public bool startControl=false;
	public bool checkComplete;
	public bool gameIsComplete;

	public List<GameObject> imageKeyList;
	public List<GameObject> imageOfPictureList;
	public List<GameObject> checkPointList;

	public AudioSource clickAudio;

	GameObject[,] imageKeyMatrix;
	GameObject[,] imageOfPictureMatrix;
	GameObject[,] checkPointMatrix;

	// Use this for initialization
	void Start () {
		clickAudio = GetComponent<AudioSource>();
		imageKeyMatrix = new GameObject[sizeRow, sizeCol];
		imageOfPictureMatrix = new GameObject[sizeRow, sizeCol];
		checkPointMatrix = new GameObject[sizeRow, sizeCol];
		if (level == 1) {
			ImageOfEasyLevel ();
		}
		if (level > 2) {
			Debug.Log ("Not implemented");
		}
		CheckPointManager ();
		ImageKeyManager ();
		for (int r = 0; r < sizeRow; r++) { // runRow
			for (int c = 0; c < sizeCol; c++) { // runCol
				if (imageOfPictureMatrix [r, c].name.CompareTo ("blank") == 0) {
					Debug.Log ("Ok");
					rowBlank = r;
					colBlank = c;
					break;
				}
			}
		}
	}

	void CheckPointManager(){
		for (int r = 0; r < sizeRow; r++) {
			for (int c = 0; c < sizeCol; c++) {
				checkPointMatrix [r, c] = checkPointList [countPoint];
				countPoint++;
			}
		}
	}

	void ImageKeyManager(){
		for (int r = 0; r < sizeRow; r++) {
			for (int c = 0; c < sizeCol; c++) {
				imageKeyMatrix [r, c] = imageKeyList [countImageKey];
				countImageKey++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (startControl) {
			startControl = false;
			if (countStep >= 1) {
				if (imageOfPictureMatrix [row, col].name.CompareTo ("blank") != 0) { // Check if position touch is image not image blank
					if (rowBlank != row && colBlank == col) {
						if (Mathf.Abs (row - rowBlank) == 1) { //  move 1 cell
							// move
							SortImage (); // call function ImageSort
							countStep = 0; // Reset count step
						} else {
							countStep = 0;
						}

					} else if (rowBlank == row && colBlank != col) {
						if (Mathf.Abs (col - colBlank) == 1) {
							// move
							SortImage ();
							countStep = 0;
						} else {
							countStep = 0;
						}

					} else if ((rowBlank == row && colBlank == col) || (rowBlank != row && colBlank != col)) {
						countStep = 0; // not move
					} else {
						countStep = 0; // not move
					}
				}
			}
		}
	}


	void FixedUpdate(){
		if (checkComplete) {
			checkComplete = false;
			for (int r = 0; r < sizeRow; r++) {
				for (int c = 0; c < sizeCol; c++) {
					if (imageKeyMatrix [r, c].gameObject.name.CompareTo (imageOfPictureMatrix [r, c].gameObject.name) == 0) {
						countComplete++;
					} else {
						break;
					}
				}
			}
			if (countComplete == checkPointList.Count) {
				gameIsComplete = true;
				GameOver ();
			} else {
				countComplete = 0;
			}
		}
	}

	void GameOver (){
		Debug.Log ("Game is completed");
		//Application.LoadLevel ("GameOver");
	}

	void SortImage(){
	
		// Sort
		temp = imageOfPictureMatrix [rowBlank, colBlank];  // Select image blank and save it in temp variable.
		imageOfPictureMatrix [rowBlank, colBlank] = null;
		imageOfPictureMatrix [rowBlank, colBlank] = imageOfPictureMatrix [row, col];
		imageOfPictureMatrix [row, col] = null;
		imageOfPictureMatrix [row, col] = temp; 
	
		// set move for image

		imageOfPictureMatrix [rowBlank, colBlank].GetComponent<ImageController> ().target = checkPointMatrix [rowBlank, colBlank]; // set new point for image blank
		imageOfPictureMatrix [row, col].GetComponent<ImageController> ().target = checkPointMatrix [row, col];
		imageOfPictureMatrix [rowBlank, colBlank].GetComponent<ImageController> ().startMove = true;
		imageOfPictureMatrix [row, col].GetComponent<ImageController> ().startMove = true;

		// set row and col for image blank

		rowBlank = row; // position  touch
		colBlank = col;
		clickAudio.Play ();
	}

	void ImageOfEasyLevel(){
		imageOfPictureMatrix [0, 0] = imageOfPictureList [0];
		imageOfPictureMatrix [0, 1] = imageOfPictureList [2];
 		imageOfPictureMatrix [0, 2] = imageOfPictureList [5];
		imageOfPictureMatrix [1, 0] = imageOfPictureList [4];
		imageOfPictureMatrix [1, 1] = imageOfPictureList [1];
		imageOfPictureMatrix [1, 2] = imageOfPictureList [7];
		imageOfPictureMatrix [2, 0] = imageOfPictureList [3];
		imageOfPictureMatrix [2, 1] = imageOfPictureList [6];
		imageOfPictureMatrix [2, 2] = imageOfPictureList [8]; // image blank

	}
}
