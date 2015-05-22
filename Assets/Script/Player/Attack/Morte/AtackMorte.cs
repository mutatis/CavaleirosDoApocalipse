using UnityEngine;
using System.Collections;

public class AtackMorte : MonoBehaviour 
{
	private Vector2 direction;
	private Vector2 direction2;

	public float vel;
    public float range;

	[HideInInspector]
	public int segue = 2;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{		
		if(segue == 1)
		{
			direction = (MouseMorte.mouse.transform.position - transform.position);
			direction.Normalize();
			transform.Translate(direction / vel);
		}
		else if(segue == 2)
		{
			direction2 = (PlayerAll.playerTrans.transform.position - transform.position);
			direction2.Normalize();
			transform.Translate(direction2 / vel);	
		}
	}

	public void Attack()
	{
		segue = 1;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "PointMorte")
		{
            print(collision.collider.gameObject.name);
			segue = 2;
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "PointMorte")
		{
			segue = 2;
		}
	}
}