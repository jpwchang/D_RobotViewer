using UnityEngine;
using System.Collections;

public class DriveGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height), "Drive Subsystem");
    }
}
