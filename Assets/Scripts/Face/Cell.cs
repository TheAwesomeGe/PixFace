using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cell : MonoBehaviour {
	private bool shaken;
	
	void Start() {
				shaken = false;
	}
	
	void Update() {
	
	}
	
	public void SetColor(Color color) {
		renderer.material.SetColor("_Color", color);
	}
	
	public void TurnOff() {
		gameObject.SetActive(false);
	}
	
	public void TurnOn() {
		gameObject.SetActive(true);
	}
	
	public void Shake() {
		if(shaken)
			transform.position += transform.up*0.5f;
		else transform.position -= transform.up*0.5f;
		
		shaken = !shaken;
	}
		
}
