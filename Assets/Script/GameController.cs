using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public int row,col,countStep;
	public int sizeRow,sizeCol;
	public int rowBlank,colBlank; // Position of image blank
	int countPoint = 0;
	int countImageKey = 0;
	int temp;

	public bool startControl=false;

	public List<GameObject> imageKeyList;
	public List<GameObject> imageOfPictureList;
	public List<GameObject> checkPointList;

	GameObject[,] imageKeyMatrix;
	GameObject[,] imageOfPictureMatrix;
	GameObject[,] checkPointMatrix;

	// Use this for initialization
	void Start () {

		imageKeyMatrix = new GameObject[sizeRow, sizeCol];
		imageOfPictureMatrix = new GameObject[sizeRow, sizeCol];
		checkPointMatrix = new GameObject[sizeRow, sizeCol];
		CheckPointManager ();
		ImageKeyManager ();
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
				imageKeyMatrix [r, c] = imageKeyList [countPoint];
				countImageKey++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (startControl) {
			startControl = false;
			if (countStep == 1) {
				if (imageOfPictureMatrix [row, col].name.CompareTo ("blank") != 0) { // Check if position touch is image not image blank
					if (rowBlank != row && colBlank == col) {
						// Move
						countStep = 0; // Reset count step
					} else if (rowBlank == row && colBlank == col) {
						countStep = 0;
					} else if ((rowBlank == row && colBlank == col) || (rowBlank != row && colBlank != col)) {
						countStep = 0; // not move
					} else {
						countStep = 0; // not move
					}
				}
			}
		}
	}

	void SortImage(){
	
		// Sort
		temp = imageOfPictureMatrix [rowBlank, colBlank];
		imageOfPictureMatrix [rowBlank, colBlank] = null;
		imageOfPictureMatrix [rowBlank, colBlank] = imageOfPictureMatrix [row, col];
		imageOfPictureMatrix [row, col] = null;
		imageOfPictureMatrix [row, col] = temp; 
	
		// set move for image
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
