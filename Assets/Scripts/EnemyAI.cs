using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float walkSpeed = 2f;
	public float chaseSpeed = 3f;
	public float chaseTimeout;
	public float[] patrolWaitTimes;
	public Transform[] waypoints;

	private EnemyVision enemyVision;
	private NavMeshAgent nav;
	private GameObject player;
	private float endChaseTimer;
	private float patrolTimer;
	private int waypointIndex = 0;
	private Light pointLight;
	private Light spotLight;
	private bool lightLerping = false;
	private float lerpTime = 0.5f;

	void Awake()
	{
		enemyVision = GetComponent<EnemyVision> ();
		nav = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		pointLight = GetComponent<Light>();
		spotLight = GetComponentsInChildren<Light>()[1];
		pointLight.intensity = 0;
		spotLight.intensity = 0;
	}

	void Update()
	{
		if (enemyVision.canSeePlayer || enemyVision.lastSightingLoc != enemyVision.resetLoc)
		{
			Chase ();
			if(!lightLerping && pointLight.intensity == 0)
			{
				StartCoroutine("Enrage");
			}
		} 
		else
		{
			Patrol ();
			if(!lightLerping && pointLight.intensity == 8)
			{
				StartCoroutine("CalmDown");
			}
		}

		Debug.Log (pointLight.intensity);

	}

	void Chase()
	{
		Vector3 vecToPlayer = player.transform.position - transform.position;

		nav.speed = chaseSpeed;

		nav.destination = enemyVision.lastSightingLoc;

		if (nav.remainingDistance <= nav.stoppingDistance)
		{
			endChaseTimer += Time.deltaTime;

			if (endChaseTimer > chaseTimeout)
			{
				enemyVision.lastSightingLoc = enemyVision.resetLoc;
				endChaseTimer = 0f;
			}
		}

		if (Vector3.SqrMagnitude (vecToPlayer) < 2 && enemyVision.canSeePlayer)
		{
			//make player take damage
		}
	}

	void Patrol()
	{
		nav.speed = walkSpeed;
		if (nav.destination == enemyVision.resetLoc || nav.remainingDistance < nav.stoppingDistance)
		{
			patrolTimer += Time.deltaTime;

			if (patrolTimer >= patrolWaitTimes [waypointIndex])
			{
				if (waypointIndex == waypoints.Length - 1)
				{
					waypointIndex = 0;
				} 
				else
				{
					waypointIndex++;
				}

				patrolTimer = 0;
			} 
		}
		else
		{
			patrolTimer = 0;
		}

		nav.destination = waypoints [waypointIndex].position;
	}

	private IEnumerator Enrage()
	{
		lightLerping = true;

		for(float t=0; t<1; t+=Time.deltaTime/lerpTime)
		{
			pointLight.intensity = Mathf.Lerp(0, 8, t);
			spotLight.intensity = Mathf.Lerp(0, 8, t);
			yield return null;
		}
		pointLight.intensity = 8;
		spotLight.intensity = 8;
		lightLerping = false;
	}

	private IEnumerator CalmDown()
	{
		lightLerping = true;

		for(float t=0; t<1; t+=Time.deltaTime/lerpTime)
		{
			pointLight.intensity = Mathf.Lerp(8, 0, t);
			spotLight.intensity = Mathf.Lerp(8, 0, t);
			yield return null;
		}
		pointLight.intensity = 0;
		spotLight.intensity = 0;
		lightLerping = false;
	}
}
