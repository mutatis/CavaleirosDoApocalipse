using UnityEngine;
using System.Collections;

public class CreatedGrounded : MonoBehaviour 
{

	public GameObject chao;
	public Vector2 limitX;
	public Vector2 limitY;
	float x, y;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			x = Random.Range(limitX.x, limitX.y);
			y = Random.Range(limitY.x, limitY.y);
			Instantiate(chao, new Vector3(transform.position.x + x, transform.position.y + y, 0), transform.rotation);
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			x = Random.Range(limitX.x, limitX.y);
			y = Random.Range(limitY.x, limitY.y);
			Instantiate(chao, new Vector3(transform.position.x + x, transform.position.y + y, 0), transform.rotation);
		}
	}
}
