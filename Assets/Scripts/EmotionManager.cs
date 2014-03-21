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
			FaceManager.Instance.Mouth.Shake();
			FaceManager.Instance.LeftEye.Shake();
			FaceManager.Instance.RightEye.Shake();
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


		FaceManager.Instance.Mouth.Color = Color.green;
		FaceManager.Instance.LeftEye.Color = Color.green;
		FaceManager.Instance.RightEye.Color = Color.green;

		FaceManager.Instance.Mouth.Shape = mouthShape;
		FaceManager.Instance.LeftEye.Shape = leftEyeShape;
		FaceManager.Instance.RightEye.Shape = rightEyeShape;

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
		
		FaceManager.Instance.Mouth.Color = Color.yellow;
		FaceManager.Instance.LeftEye.Color = Color.yellow;
		FaceManager.Instance.RightEye.Color = Color.yellow;
		
		FaceManager.Instance.Mouth.Shape = mouthShape;
		FaceManager.Instance.LeftEye.Shape = leftEyeShape;
		FaceManager.Instance.RightEye.Shape = rightEyeShape;
	}
	
	private void generateSurpriseFace() {
		
		bool[,] leftEyeShape = new bool[3,3] {{T, T, T},
											  {T, T, T},
											  {T, T, T}};
		
		bool[,] rightEyeShape = new bool[3,3] {{T, T, T},
											   {T, T, T},
											   {T, T, T}};
		
		FaceManager.Instance.Mouth.Color = Color.magenta;
		FaceManager.Instance.LeftEye.Color = Color.magenta;
		FaceManager.Instance.RightEye.Color = Color.magenta;

		FaceManager.Instance.LeftEye.Shape = leftEyeShape;
		FaceManager.Instance.RightEye.Shape = rightEyeShape;
	}
}
