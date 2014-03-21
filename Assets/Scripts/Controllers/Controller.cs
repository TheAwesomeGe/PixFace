using UnityEngine;

public class Controller : MonoBehaviour {

	public Color LeftEyeColor {
		set {
			FaceManager.Instance.LeftEye.Color = value;
		}
	}

	public bool[,] LeftEyeShape {
		set {
			FaceManager.Instance.LeftEye.Shape = value;
		}
	}

	public Color RightEyeColor {
		set {
			FaceManager.Instance.RightEye.Color = value;
		}
	}

	public bool[,] RightEyeShape {
		set {
			FaceManager.Instance.RightEye.Shape = value;
		}
	}

	public Color MouthColor {
		set {
			FaceManager.Instance.Mouth.Color = value;
		}
	}

	public bool[,] MouthShape {
		set {
			FaceManager.Instance.Mouth.Shape = value;
		}
	}
}
