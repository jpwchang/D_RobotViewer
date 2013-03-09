using UnityEngine;
using System.Collections;

public class RobotScript : MonoBehaviour {
    private Vector3 rotation;
	// Use this for initialization
	void Start () {
        rotation = new Vector3(0.0f, 0.15f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotation);
	}
}
