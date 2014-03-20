using UnityEngine;
using System.Collections;

public abstract class CommandManager : MonoBehaviour {



	public void SetLeftEyeColor(Color color) {
		EyeManager.Instance.SetLeftEyeColor(color);
	}

	public void SetRightEyeColor(Color color) {
		EyeManager.Instance.SetRightEyeColor(color);
	}

}
