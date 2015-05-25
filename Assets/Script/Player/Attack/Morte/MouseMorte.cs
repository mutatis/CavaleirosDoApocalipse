using UnityEngine;
using System.Collections;

public class MouseMorte : MonoBehaviour 
{
	[HideInInspector]
	public Vector2 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
	public static MouseMorte mouse;

	void Awake()
	{
		mouse = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Attack()
	{
		pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = pos;
	}
}
