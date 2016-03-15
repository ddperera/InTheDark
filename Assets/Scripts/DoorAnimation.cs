using UnityEngine;
using System.Collections;

public class DoorAnimation : MonoBehaviour {
	public bool keyRequired;
	public AudioClip doorSwishClip;
	public AudioClip doorLocked;
	public bool inTrigger = false;

	private Animator anim;
	private GameObject player;
	private PlayerInventory playerInventory;
	private AudioSource audio;

	private TextManager textM;

	void Awake(){
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerInventory = player.GetComponent<PlayerInventory> ();

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
		if (inTrigger && !anim.GetBool("Open")) {
			if(Input.GetButton("Jump")){
				
				if (keyRequired) {
					if (playerInventory.hasKey) {
						anim.SetBool ("Open", true);
						if (!audio.isPlaying) {
							audio.clip = doorSwishClip;
							audio.Play ();
						}
					} else { //player was not able to open the door
						if (!audio.isPlaying) {
							audio.clip = doorLocked;
							audio.Play ();
						}
						textM.UpdateText ("The door is locked");
					}
					
				} else {
					anim.SetBool ("Open", true);
					//anim.IsInTransition (0) && 
					if (!audio.isPlaying) {
						audio.clip = doorSwishClip;
						audio.Play ();
					}
				}
			}
		}
	}
}
