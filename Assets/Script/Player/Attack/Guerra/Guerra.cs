﻿using UnityEngine;
using System.Collections;

public class Guerra : MonoBehaviour
{

	Vector2 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
	public TrailRenderer trail;
	public BoxCollider2D box;

	// Use this for initialization
	void Start () 
	{
		trail.enabled = false;
		box.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButton(0))
		{
			trail.enabled = true;
			box.enabled = true;
			pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			print (pos);
			transform.position = pos;
		}
		else if(Input.GetMouseButtonUp(0))
	    {
			StartCoroutine("GO");
		}
	}

	IEnumerator GO()
	{
		yield return new WaitForSeconds (trail.time);
		trail.enabled = false;
		box.enabled = false;
	}
}