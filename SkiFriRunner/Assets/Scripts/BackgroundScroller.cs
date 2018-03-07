using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

	public float scrollSpeed;
	public float tileSizeZ;

    private Vector2 savedOffset;
    private Vector3 startPosition;

	RectTransform t;
    
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	/*
	//Update is called once per frame
	void Update () {
		float x = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ * 4);
        x = x / tileSizeZ;
        x = Mathf.Floor (x);
        x = x / 4;
        Vector2 offset = new Vector2 ( savedOffset.x, x);
        float newPosition = Mathf.Repeat(savedOffset.x, Time.time * scrollSpeed - -4);
        transform.position = startPosition + Vector3.forward * newPosition;		
	}
	*/
	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		transform.position = startPosition += Vector3.up * scrollSpeed;
	}
}
