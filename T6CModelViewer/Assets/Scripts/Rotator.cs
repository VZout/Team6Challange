using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public Vector3 speed;
	
	void Update () {
		transform.Rotate (speed);
	}
}
