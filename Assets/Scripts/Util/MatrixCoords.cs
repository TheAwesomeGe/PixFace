using UnityEngine;
using System;

public class MatrixCoords {

	private int lin;
	private int col;
	
	public int Lin {
		get {
			return lin;
		}
	}
	
	public int Col {
		get {
			return col;
		}
	}
	
	public MatrixCoords(int lin, int col) {
		this.lin = lin;
		this.col = col;
	}
	
	public static bool operator ==(MatrixCoords c1, MatrixCoords c2) {
		return c1.Lin == c2.Lin && c1.Col == c2.Col;
	}
	
	public static bool operator !=(MatrixCoords c1, MatrixCoords c2) {
		return c1.Lin != c2.Lin || c1.Col != c2.Col;
	}
	
	public override int GetHashCode() {
		return lin ^ col;
	}
	
	public override bool Equals(object c) {
		return c is MatrixCoords && this == (MatrixCoords)c;
	}
	
	public override string ToString() {
		return "Lin: " + lin + " Col: " + col;
	}
	
	public float DistanceTo(MatrixCoords c) {
		return Mathf.Sqrt(Mathf.Pow(this.Lin - c.Lin, 2) + Mathf.Pow(this.Col - c.Col, 2)); 
	}
}
