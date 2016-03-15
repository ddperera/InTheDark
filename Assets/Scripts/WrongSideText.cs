using UnityEngine;
using System.Collections;

public class WrongSideText : MonoBehaviour {

	public AudioClip doorLocked;
	public bool inTrigger = false;

	private GameObject player;
	private AudioSource audio;

	private TextManager textM;

	void Awake(){
		audio = GetComponent<AudioSource> ();
		player = GameObject.FindGameObjectWithTag ("Player");

		textM = GameObject.FindGameObjectWithTag ("Text").GetComponent<TextManager> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject == player) {
			inTrigger = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject == player) {
			inTrigger = false;
		}
	}

	void Update(){
		if (inTrigger && Input.GetButton ("Jump")) {
			if (!audio.isPlaying) {
				audio.clip = doorLocked;
				audio.Play ();
			}
			textM.UpdateText ("The door closed from the other side");
		}
	}
}
