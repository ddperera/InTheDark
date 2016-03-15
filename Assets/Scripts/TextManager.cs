using UnityEngine;
using System.Collections;

public class TextManager : MonoBehaviour {

	public float timeToReset = 1.5f;

	private GUIText text;
	private float timeSinceLastUpdate;

	void Start(){
		text = GetComponent<GUIText> ();
		UpdateText ("");
	}
		
	void Update(){
		if (Input.GetButton ("Jump") && (Time.time - timeSinceLastUpdate > timeToReset)) {
			UpdateText ("");

		}
	}

	public void UpdateText(string txt){
		text.text = txt;
		timeSinceLastUpdate = Time.time;
	}
}
