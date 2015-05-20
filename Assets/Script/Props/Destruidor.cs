using UnityEngine;
using System.Collections;

public class Destruidor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag != null)
		{
			Destroy (collision.gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag != null)
		{
			Destroy (collision.gameObject);
		}
	}
}
