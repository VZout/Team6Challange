using UnityEngine;
using System.Collections;

public class HandRotator : MonoBehaviour {
	
	public float speed = 2;
	public float lerpSpeed = 3;
	private float x;
	private float y;
	private Quaternion lastRotation;
	private Quaternion tr;
	private bool rotating;
	
	// Use this for initialization
	void Start () {
		tr = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			x = Input.mousePosition.x;
			y = Input.mousePosition.y;
			rotating = true;
		} else if(Input.GetMouseButtonUp(0)) {
			rotating = false;
		}
		
		if(rotating) {
			
			if(x != Input.mousePosition.x) {
				tr = Quaternion.Euler(new Vector3(tr.eulerAngles.x, tr.eulerAngles.y + (x - Input.mousePosition.x) / speed, tr.eulerAngles.z));
				x = Input.mousePosition.x;
			}
			
			if(y != Input.mousePosition.y) {
				tr = Quaternion.Euler(new Vector3(tr.eulerAngles.x, tr.eulerAngles.y, tr.eulerAngles.z + (y - Input.mousePosition.y) / speed));
				y = Input.mousePosition.y;
			}
		}
		
		transform.rotation = Quaternion.Lerp(transform.rotation, tr, lerpSpeed * Time.deltaTime);
	}
}
