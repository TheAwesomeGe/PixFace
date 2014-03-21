using UnityEngine;

public class Cell : MonoBehaviour {
	private bool shaken;

	public Color Color {
		set {
			renderer.material.SetColor ("_Color", value);
		}
	}

	void Start() {
		shaken = false;
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
