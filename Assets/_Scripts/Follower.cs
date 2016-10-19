using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	public float repathDelay = 0.5f;

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
			if (target != null) {
				if (NavMesh.SamplePosition (target.position + target.rotation * offset, out destination, 10f, NavMesh.AllAreas)) {
					navAgent.SetDestination (destination.position);
				}
			}
			yield return new WaitForSeconds (repathDelay);
		}
	}
}
