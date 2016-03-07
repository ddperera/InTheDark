﻿using UnityEngine;
using System.Collections;

public class EnemyVision : MonoBehaviour {

	public float fovAngle = 100f;
	public bool canSeePlayer;
	public Vector3 lastSightingLoc;

	private GameObject player;
	private SphereCollider visionVolume;
	private NavMeshAgent nav;
	public Vector3 resetLoc;
	private bool playerLightOn;

	void Awake()
	{
		resetLoc = new Vector3 (999f, 999f, 999f);

		nav = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		visionVolume = GetComponent<SphereCollider> ();
		lastSightingLoc = resetLoc;
	}

	void OnTriggerStay(Collider other)
	{

		if (other.gameObject == player) 
		{
			canSeePlayer = false;

			Vector3 dir = other.transform.position - transform.position;
			float angleToPlayer = Vector3.Angle (dir, transform.forward);
			float visionDist = playerLightOn ? visionVolume.radius : visionVolume.radius/2.0f;

			if (angleToPlayer < fovAngle * 0.5f) 
			{
				RaycastHit hitInfo;

				if (Physics.Raycast (transform.position, dir, out hitInfo, visionVolume.radius)) 
				{
					if (hitInfo.collider.gameObject == player && hitInfo.distance <= visionDist) 
					{
						canSeePlayer = true;
						lastSightingLoc = player.transform.position;
					}
				}
			}


		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player)
		{
			canSeePlayer = false;
		}
	}

	float CalculatePathLength(Vector3 targetPosition)
	{
		NavMeshPath path = new NavMeshPath ();
		if (nav.enabled)
		{
			nav.CalculatePath (targetPosition, path);
		}

		Vector3[] allWaypoints = new Vector3[path.corners.Length + 2];

		allWaypoints [0] = transform.position;
		allWaypoints [allWaypoints.Length - 1] = targetPosition;

		for (int i = 0; i < path.corners.Length; i++)
		{
			allWaypoints [i + 1] = path.corners [i];
		}

		float pathLength = 0;

		for (int i = 0; i < allWaypoints.Length - 1; i++)
		{
			pathLength += Vector3.Distance (allWaypoints [i], allWaypoints [i + 1]);
		}

		return pathLength;
	}
}