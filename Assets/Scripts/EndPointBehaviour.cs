using UnityEngine;
using System.Collections;

public class EndPointBehaviour : MonoBehaviour {

	public int nextLevelIndex;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider coll)
	{
		Debug.Log(coll.gameObject.tag);
		if(coll.gameObject.CompareTag("Player"))
		{
			Debug.Log("Victory!");
			if (nextLevelIndex == 9) 
			{
				GameObject.Destroy (coll.gameObject);
			} 
			else 
			{
				Application.LoadLevel (nextLevelIndex);
			}
		}

	}
}
