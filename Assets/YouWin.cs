using UnityEngine;
using System.Collections;

public class YouWin : MonoBehaviour {
	private GameObject player;
	private PlayerInventory playerInventory;
	private bool finished = false;

	private TextManager textM;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
		playerInventory = player.GetComponent<PlayerInventory> ();

		textM = GameObject.FindGameObjectWithTag ("Text").GetComponent<TextManager> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject == player && !finished) {
			finished = true;
			textM.UpdateText ("You made it to the end of the Game! You Win!");
		}
	}
}
