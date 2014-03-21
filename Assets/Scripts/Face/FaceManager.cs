using UnityEngine;

public class FaceManager : MonoBehaviour {
	public Eye RightEye;
	public Eye LeftEye;
	public Mouth Mouth;

	private static FaceManager instance;
	
	public static FaceManager Instance {
		get {
			if(instance == null)
				instance = GameObject.Find("Managers").AddComponent<FaceManager>();
			return instance;
		}
	}
	
	private FaceManager() {
		instance = this;
	}
}
