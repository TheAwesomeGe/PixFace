using UnityEngine;
using System.Collections;

public class EyeManager : MonoBehaviour {
	public int width;
	public int height;
	public float top;
	public float left;
	public float right;
	
	private Cell[,] leftEye;
	private Cell[,] rightEye;
	
	private static EyeManager instance;
	
	public static EyeManager Instance {
		get {
			if(instance == null)
				instance = GameObject.Find("Managers").AddComponent<EyeManager>();
            return instance;
        }
	}
	
	private EyeManager() {
		instance = this;
	}
	
	void Awake() {
		leftEye = new Cell[height, width];
		rightEye = new Cell[height, width];
		
		GameObject cellPrefab = Resources.Load("Cell") as GameObject;
		
		for (int lin = 0; lin < height; lin++) {
		
			for (int col = 0; col < width; col++) {
				Cell leftCell = (Cell)((Transform)Instantiate(cellPrefab.transform, 
					new Vector3(left + col, top - lin, 0), Quaternion.identity)).GetComponent("Cell");
				
				Cell rightCell = (Cell)((Transform)Instantiate(cellPrefab.transform, 
					new Vector3(right - width + col, top - lin, 0), Quaternion.identity)).GetComponent("Cell");

				leftEye[lin, col] = leftCell;
				rightEye[lin, col] = rightCell;
			}
	
		}
	}
	
	public void SetLeftEyeColor(Color color) {
		foreach(Cell cell in leftEye)
			cell.SetColor(color);
	}
	
	public void SetRightEyeColor(Color color) {
		foreach(Cell cell in rightEye)
			cell.SetColor(color);
	}
	
	public void SetLeftEyeShape(bool[,] shape) {
		for (int lin = 0; lin < height; lin++) {
		
			for (int col = 0; col < width; col++) {
				if(shape[lin, col])
					leftEye[lin, col].TurnOn();
				else leftEye[lin, col].TurnOff();
			}
			
		}
	}
	
	public void SetRightEyeShape(bool[,] shape) {
		for (int lin = 0; lin < height; lin++) {
		
			for (int col = 0; col < width; col++) {
				if(shape[lin, col])
					rightEye[lin, col].TurnOn();
				else rightEye[lin, col].TurnOff();
			}
			
		}
	}
	
	public void Shake() {
		foreach(Cell cell in leftEye)
			cell.Shake();
		
		foreach(Cell cell in rightEye)
			cell.Shake();
	
	}
	
}

