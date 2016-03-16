using UnityEngine;
using System.Collections;

public class YouWin : MonoBehaviour {
	public float timeForReset = 3f;

	private GameObject player;
	private bool finished = false;
	private float timeAfterFinish;

	private TextManager textM;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
		textM = GameObject.FindGameObjectWithTag ("Text").GetComponent<TextManager> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject == player && !finished) {
			finished = true;
			textM.UpdateText ("You made it to the end of the Game! You Win!");
			timeAfterFinish = Time.time;
		}
	}

	void Update(){
		if (finished && Time.time - timeAfterFinish > 3) {
			
			Application.LoadLevel (0);
			
		}
	}
}
