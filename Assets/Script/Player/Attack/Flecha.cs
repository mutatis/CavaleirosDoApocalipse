using UnityEngine;
using System.Collections;

public class Flecha : MonoBehaviour
{
	Vector2 pos;
	private Vector2 direction2;
	private Transform player;
	float mouseY;

	// Use this for initialization
	void Start () 
	{
		transform.position = new Vector2(AttackFlecha.attackF.transform.position.x, AttackFlecha.attackF.transform.position.y);
		direction2 = AttackFlecha.attackF.mira2.position + transform.position;
		direction2.Normalize();
		if(AttackFlecha.attackF.mira.eulerAngles.z > 0 && AttackFlecha.attackF.mira.eulerAngles.z < 90)
		{
			transform.eulerAngles = AttackFlecha.attackF.mira.eulerAngles / 2;
		}
		else
		{
			transform.eulerAngles = AttackFlecha.attackF.mira.eulerAngles;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonUp(0))
		{

		}
		transform.Translate(0.2f, 0, 0);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			//Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			//Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}
