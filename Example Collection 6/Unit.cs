﻿using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
	public Transform target;
	float speed = 2;
	Vector3[] path;
	int targetIndex;

	private Vector3 targetOldPosition;

	void Start ()
	{
		targetOldPosition = target.position;
		PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
	}

	void Update()
	{
		if (target.position != targetOldPosition)
		{
			PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
			targetOldPosition = target.position;
			Debug.Log("Is firing");
		}
	}

	public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
	{
		if (pathSuccessful)
		{
			path = newPath;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	IEnumerator FollowPath()
	{
		Vector3 currentWaypoint = path[0];

		while (true)
		{
			if (transform.position == currentWaypoint)
			{
				targetIndex ++;
				if (targetIndex >= path.Length)
				{
					targetIndex = 0;
					path = new Vector3[0];
					yield break;
				}
				currentWaypoint = path[targetIndex];
			}

			transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
			yield return null;

		}
	}

	public void OnDrawGizmos()
	{
		if (path != null)
		{
			for (int i = targetIndex; i < path.Length; i ++)
			{
				Gizmos.color = Color.black;
				Gizmos.DrawCube (path[i], Vector3.one);

				if (i == targetIndex)
				{
					Gizmos.DrawLine(transform.position, path[i]);
				}
				else
				{
					Gizmos.DrawLine(path[i - 1], path[i]);
				}
			}
		}
	}
}