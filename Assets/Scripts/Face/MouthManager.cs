using UnityEngine;
using System.Collections;

public class MouthManager : MonoBehaviour {
	public int width;
	public int height;
	public float top;
	public float left;
	
	private Cell[,] cells;
	
	private static MouthManager instance;
	
	public static MouthManager Instance {
		get {
			if(instance == null)
				instance = GameObject.Find("Managers").AddComponent<MouthManager>();
            return instance;
        }
	}
	
	private MouthManager() {
		instance = this;
	}
	
	void Awake() {
		cells = new Cell[height, width];
		
		GameObject cellPrefab = Resources.Load("Cell") as GameObject;
		
		for (int lin = 0; lin < height; lin++) {
		
			for (int col = 0; col < width; col++) {
				Cell cell = (Cell)((Transform)Instantiate(cellPrefab.transform, 
					new Vector3(left + col, top - lin, 0), Quaternion.identity)).GetComponent("Cell");

				cells[lin, col] = cell;
			}
	
		}
	}
	
	public void SetColor(Color color) {
		foreach(Cell cell in cells) {
			cell.SetColor(color);
		}
	}
	
	public void SetShape(bool[,] shape) {
		for (int lin = 0; lin < height; lin++) {
		
			for (int col = 0; col < width; col++) {
				if(shape[lin, col])
					cells[lin, col].TurnOn();
				else cells[lin, col].TurnOff();
			}
	
		}
	}
	
	public void Shake() {
		foreach(Cell cell in cells)
			cell.Shake();
	}
	
}
