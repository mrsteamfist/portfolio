using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

	public Transform[] Lanes;
	public int StartLane = 0;
	public int CurrentLane = 0;
	public float Speed = 10.0f;
	public Sprite LeftSprite;
	public Sprite RightSprite;
	public Sprite DefaultSprite;
	public SpriteRenderer Skier;

	protected Vector2? startSwipe;
	protected Vector2 lastPos;
	protected float moveDistance = 0.0f;
	protected bool canMove=false;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	public void Start()
	{
		canMove=true;
		transform.SetPositionAndRotation(Lanes[StartLane].position, Lanes[StartLane].rotation);
	}

	// Update is called once per frame
	void Update ()
	{
		// if the user is not in a move
		if(canMove && moveDistance == 0.0f)
		{
			if (Input.GetMouseButton(0))
			{
				if (startSwipe == null)
					startSwipe = Input.mousePosition;
				lastPos = Input.mousePosition;
			}
			else if(startSwipe != null)
			{
				float delta = lastPos.x - startSwipe.Value.x;
				//Debug.Log("Delta " + delta);
				if (delta > 0 && CurrentLane < Lanes.Length -1)
					//delta > Lanes[CurrentLane+1].position.x - Lanes[CurrentLane].position.x)
				{
					moveDistance = Lanes[CurrentLane+1].position.x - Lanes[CurrentLane].position.x;
					CurrentLane++;
					Skier.sprite = RightSprite;
				}
				else if(delta < 0 && CurrentLane > 0)
					//delta > Lanes[CurrentLane-1].position.x - Lanes[CurrentLane].position.x)
				{
					moveDistance = Lanes[CurrentLane-1].position.x - Lanes[CurrentLane].position.x;
					CurrentLane--;
					Skier.sprite = LeftSprite;
				}
				startSwipe = null;
			}
		}
	}

	public void Stop()
	{
		moveDistance = 0.0f;
		canMove=false;
	}

	public void Stop(Vector2 at)
	{
		moveDistance = at.x - transform.position.x;
		canMove=false;
	}

	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		if (moveDistance != 0.0f)
		{
			var move = Time.deltaTime * Speed;
			if (moveDistance < 0.0f)
			{
				move *= -1.0f;
				if (moveDistance > move)
					move = moveDistance;
			}
			else
			{
				 if (moveDistance < move)
					move = moveDistance;
			}

			transform.Translate(move,0.0f,0.0f);
			moveDistance -= move;
		}
		else
		{
			if (canMove)
				Skier.sprite = DefaultSprite;
		}
	}
}
