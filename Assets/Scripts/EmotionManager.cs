using UnityEngine;
using System;
using System.Collections;

public class EmotionManager : MonoBehaviour {
	private const bool F = false;
	private const bool T = true;
	
	private int shakeTime;

	// Use this for initialization
	void Start () {	
		shakeTime = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			System.Random random = new System.Random();
			int emotion = random.Next(3);
			switch(emotion) {
			case 0:
				generateHappyFace();
				break;
			case 1:
				generateSadFace();
				break;
			case 2:
				generateSurpriseFace();
				break;
			}
		}
	}
	
	void FixedUpdate() {
		if(shakeTime == 0) {
			MouthManager.Instance.Shake();
			EyeManager.Instance.Shake();
			shakeTime = 10;
		}
		else shakeTime--;
	}
	
	private void generateHappyFace() {
		bool[,] mouthShape = new bool[3,7] {{T, F, F, F, F, F, T},
											{T, T, T, T, T, T, T},
											{F, F, F, F, F, F, F}};
		
		bool[,] leftEyeShape = new bool[3,3] {{F, F, F},
											  {F, T, T},
											  {F, T, T}};
		
		bool[,] rightEyeShape = new bool[3,3] {{F, F, F},
											   {T, T, F},
											   {T, T, F}};
		
		MouthManager.Instance.SetColor(Color.green);
		EyeManager.Instance.SetLeftEyeColor(Color.green);
		EyeManager.Instance.SetRightEyeColor(Color.green);
		
		MouthManager.Instance.SetShape(mouthShape);
		EyeManager.Instance.SetLeftEyeShape(leftEyeShape);
		EyeManager.Instance.SetRightEyeShape(rightEyeShape);
	}
	
	private void generateSadFace() {
		bool[,] mouthShape = new bool[3,7] {{T, T, T, T, T, T, T},
											{T, F, F, F, F, F, T},
											{F, F, F, F, F, F, F}};
		
		bool[,] leftEyeShape = new bool[3,3] {{F, F, F},
											  {F, T, T},
											  {F, T, T}};
		
		bool[,] rightEyeShape = new bool[3,3] {{F, F, F},
											   {T, T, F},
											   {T, T, F}};
		
		MouthManager.Instance.SetColor(Color.yellow);
		EyeManager.Instance.SetLeftEyeColor(Color.yellow);
		EyeManager.Instance.SetRightEyeColor(Color.yellow);
		
		MouthManager.Instance.SetShape(mouthShape);
		EyeManager.Instance.SetLeftEyeShape(leftEyeShape);
		EyeManager.Instance.SetRightEyeShape(rightEyeShape);
	}
	
	private void generateSurpriseFace() {
		
		bool[,] leftEyeShape = new bool[3,3] {{T, T, T},
											  {T, T, T},
											  {T, T, T}};
		
		bool[,] rightEyeShape = new bool[3,3] {{T, T, T},
											   {T, T, T},
											   {T, T, T}};
		
		MouthManager.Instance.SetColor(Color.magenta);
		EyeManager.Instance.SetLeftEyeColor(Color.magenta);
		EyeManager.Instance.SetRightEyeColor(Color.magenta);
		
		EyeManager.Instance.SetLeftEyeShape(leftEyeShape);
		EyeManager.Instance.SetRightEyeShape(rightEyeShape);
	}
}
