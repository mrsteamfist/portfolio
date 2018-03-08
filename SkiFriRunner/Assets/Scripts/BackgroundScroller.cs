using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

	public float scrollSpeed;
	public float colWidth;
	public int numCols;
	public float loopLocation;
	public bool skipFirstCol;
	public float currnetCol;
	public float currentTime;

    private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		currentTime = 0f;
		startPosition = transform.position;
	}

	void FixedUpdate()
	{
		currentTime += Time.fixedDeltaTime;
		float up = currentTime * scrollSpeed;
		if (up > loopLocation)
		{
			currnetCol++;
			currentTime = 0;
			if (currnetCol >= numCols)
			{
				if (skipFirstCol)
					currnetCol = 1;
				else
					currnetCol = 0;
			}
		}
		float left = currnetCol * colWidth;
		transform.position = startPosition + (Vector3.up * up) + (Vector3.left * left);
	}
}
