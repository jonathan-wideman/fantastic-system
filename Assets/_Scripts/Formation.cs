using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Formation : MonoBehaviour {

	[System.Serializable]
	public class Position {
		public Vector3 inWorld;
		public Vector3 offset;
		public bool filled;
	}

	public struct PositionFollowerPair {
		public PositionFollowerPair(Position position, Follower follower, float distance) {
			this.position = position;
			this.follower = follower;
			this.distance = distance;
		}

		public Position position;
		public Follower follower;
		public float distance;
	}

	public List<Follower> followers;
	public List<Position> positions;

	// TODO: add dirty flag based on transform position, rotation
	// TODO: organize followers only if dirty
	// TODO: organize followers only when asked for a new path

	void Update () {
		OrganizeFollowers ();
	}

	public void OrganizeFollowers () {
		List<PositionFollowerPair> AvailablePairs = new List<PositionFollowerPair> ();
		for (int f = 0; f < followers.Count; f++) {
			followers [f].assignedFormation = false;
			for (int p = 0; p < positions.Count; p++) {
				UpdatePosition(positions[p]);
				AvailablePairs.Add(new PositionFollowerPair(positions[p], followers[f], Vector3.Distance(positions[p].inWorld, followers[f].transform.position)));
			}
		}
		AvailablePairs.Sort (delegate(PositionFollowerPair a, PositionFollowerPair b) {
			if (a.distance < b.distance) {
				return -1;
			} else if (a.distance > b.distance) {
				return 1;
			}
			return 0;
		});

		PositionFollowerPair pair;
		for (int i = 0; i < AvailablePairs.Count; i++) {
			pair = AvailablePairs [i];
			if (pair.position.filled == false && pair.follower.assignedFormation == false) {
				AssignFollowerToPosition (pair.position, pair.follower);
			}
		}
	}

	public void UpdatePosition (Position position) {
		// recalculate world coordinates for a Position and set it to unfilled
		position.filled = false;
		position.inWorld = transform.position + transform.rotation * position.offset;
		//positions [i] = pos;
		Debug.DrawLine (transform.position, position.inWorld, Color.blue, 0.01f);
	}

	public void AssignFollowerToPosition (Position position, Follower follower) {
		follower.assignedFormation = true;
		position.filled = true;
		follower.SetTarget (position.inWorld);
	}

}
