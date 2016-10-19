using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {

	public Formation formation;
	//public Transform target;
	public Vector3 targetPos;
	public bool hasTarget;
	public Vector3 offset;
	public float repathDelay = 0.5f;
	public bool assignedFormation = false;

	NavMeshAgent navAgent;
	NavMeshHit destination;

	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent> ();
		StartCoroutine (Repath ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Repath () {
		while (true) {
			/*
			if (formation != null) {
				//if (NavMesh.SamplePosition (target.position + target.rotation * offset, out destination, 10f, NavMesh.AllAreas)) {
				if (NavMesh.SamplePosition (formation.GetClosestOpenPosition (transform.position), out destination, 10f, NavMesh.AllAreas)) {
					navAgent.SetDestination (destination.position);
				}
			}
			*/
			if (hasTarget) {
				if (NavMesh.SamplePosition (targetPos, out destination, 10f, NavMesh.AllAreas)) {
					navAgent.SetDestination (destination.position);
				}
			}
			yield return new WaitForSeconds (repathDelay);
		}
	}

	public void SetTarget (Vector3 pos) {
		hasTarget = true;
		targetPos = pos;
	}

	public void ReleaseTarget () {
		hasTarget = false;
	}
}
