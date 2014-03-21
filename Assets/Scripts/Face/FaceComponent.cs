using UnityEngine;

public abstract class FaceComponent : MonoBehaviour {
	public int Width;
	public int Height;
	public float Top;
	public float Left;
	
	private Cell[,] cells;

	public Color Color {
		set {
			foreach(Cell cell in cells)
				cell.Color = value;
		}
	}

	public bool[,] Shape {
		set {
			if(value.GetLength(0) == Height && value.GetLength(1) == Width) {
				for (int lin = 0; lin < Height; lin++) {
					for (int col = 0; col < Width; col++) {
						if (value[lin, col])
							cells[lin, col].TurnOn();
						else
							cells[lin, col].TurnOff();
					}
				}
			}
		}
	}
	
	void Awake() {
		cells = new Cell[Height, Width];
		
		GameObject cellPrefab = Resources.Load("Cell") as GameObject;
		
		for (int lin = 0; lin < Height; lin++) {
			
			for (int col = 0; col < Width; col++) {
				Cell cell = (Cell)((Transform)Instantiate(cellPrefab.transform, 
				                                          new Vector3(Left + col, Top - lin, 0), 
				                                          Quaternion.identity)).GetComponent("Cell");

				cells[lin, col] = cell;
			}
			
		}
	}

	
	public void TurnOff() {
		foreach(Cell cell in cells)
			cell.TurnOff();
	}
	
	public void Shake() {
		foreach(Cell cell in cells)
			cell.Shake();
	}
	
}
