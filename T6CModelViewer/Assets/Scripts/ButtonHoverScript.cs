using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonHoverScript : MonoBehaviour {
	[SerializeField]
	private string title;
	[SerializeField]
	private string information;
	[SerializeField]
	private Canvas canvasPrefab;
	private Canvas canvas;
	private Text titleText;
	private Text descText;
	private Image seperatorRect;
	[SerializeField]
	private Manager gm;
	[SerializeField]
	public Vector3 adjustor;
	private Material startMaterial;
	[SerializeField]
	private Material hoverMaterial;
	[SerializeField]
	private float lerpTime = 4;
	private bool visible = false;
	private bool hover = false;

	void Start() {
		startMaterial = GetComponent<Renderer> ().material;
		canvas = Instantiate (canvasPrefab, canvasPrefab.transform.position, canvasPrefab.transform.rotation) as Canvas;

		for(int i = 0; i < canvas.GetComponentsInChildren<Text>().Length; i++) {
			if(canvas.GetComponentsInChildren<Text>()[i].tag == "Title") {
				titleText = canvas.GetComponentsInChildren<Text>()[i];
				titleText.text = title;
			}

			if(canvas.GetComponentsInChildren<Text>()[i].tag == "Desc") {
				descText = canvas.GetComponentsInChildren<Text>()[i];
				descText.text = information;
			}

			if(canvas.GetComponentsInChildren<Image>()[i].tag == "Sep") {
				seperatorRect = canvas.GetComponentsInChildren<Image>()[i];
			}
		}
	
		DisableText ();
	}

	void Update() {
		if(visible) {
			titleText.color = Color.Lerp(titleText.color, new Color(1,1,1,1), lerpTime * Time.deltaTime);
			descText.color = Color.Lerp(descText.color, new Color(1,1,1,1), lerpTime * Time.deltaTime);
			seperatorRect.color = Color.Lerp(seperatorRect.color, new Color(1,1,1,1), lerpTime * Time.deltaTime);
		} else {
			titleText.color = Color.Lerp(titleText.color, new Color(1,1,1,0), lerpTime * Time.deltaTime);
			descText.color = Color.Lerp(descText.color, new Color(1,1,1,0), lerpTime * Time.deltaTime);
			seperatorRect.color = Color.Lerp(seperatorRect.color, new Color(1,1,1,0), lerpTime * Time.deltaTime);
		}

		canvas.transform.rotation = Quaternion.RotateTowards (
			canvas.transform.rotation,
			Camera.main.transform.rotation,
			360);
	}

	void OnMouseEnter() {
		EnableText ();
		GetComponent<Renderer> ().material = hoverMaterial;
	}

	void OnMouseExit() {
		DisableText ();
		GetComponent<Renderer> ().material = startMaterial;
	}

	void EnableText() {
		visible = true;
		hover = true;
		Vector3 bpos = transform.position;
		Vector3 currentPos = canvas.transform.position;
		canvas.transform.position = bpos + new Vector3(adjustor.x, adjustor.y, 0);
		canvas.transform.Translate (transform.forward * adjustor.z);
	}

	void DisableText() {
		hover = false;
		visible = false;
	}
}
