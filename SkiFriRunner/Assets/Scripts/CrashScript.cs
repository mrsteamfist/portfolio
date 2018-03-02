using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashScript : MonoBehaviour {

	public MovementScript Mover;
	public Sprite CrashTexture;
	public SpriteRenderer SkierSkin;

	/// <summary>
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnCollisionEnter2D(Collision2D other)
	{
		ContactPoint2D[] points = new ContactPoint2D[1];
		if( other.GetContacts(points) > 0)
		{
			if(Mover != null)
				Mover.Stop(points[0].point);
			if(SkierSkin != null)
				SkierSkin.sprite = CrashTexture;
		}
	}

}
