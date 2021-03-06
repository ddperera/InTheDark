﻿using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
	public AudioClip getKey;

	private bool inTrigger = false;
	private bool keyPicked = false;
	private GameObject player;
	private PlayerInventory playerInventory;
	private AudioSource audio;

	private TextManager textM;

	void Awake(){
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
		if (inTrigger && !keyPicked) {
			if (Input.GetButton ("Jump")) {
				if (!audio.isPlaying ) {
					audio.clip = getKey;
					audio.Play ();
				}
				textM.UpdateText ("You picked up a key");
				playerInventory.hasKey = true;
				keyPicked = true;
				GetComponent<Transform> ().GetChild (0).gameObject.SetActive (false);
			}
		}
	}
}
