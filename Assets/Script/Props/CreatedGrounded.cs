using UnityEngine;
using System.Collections;

public class CreatedGrounded : MonoBehaviour 
{

	public GameObject chao;
	public Vector2 limitX;
	public Vector2 limitY;
	public Vector2 limitAlt;
	public Transform pos;
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

			if(pos.position.y < limitAlt.x)
			{
				y = Random.Range(0, limitY.y);
			}
			else if(pos.position.y > limitAlt.y)
			{
				y = Random.Range(limitY.x, 0);
			}
			else
			{
				y = Random.Range(limitY.x, limitY.y);
			}

			Instantiate(chao, new Vector3(transform.position.x + x, transform.position.y + y, 0), transform.rotation);
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			x = Random.Range(limitX.x, limitX.y);

			if(pos.position.y < limitAlt.x)
			{
				y = Random.Range(0, limitY.y);
			}
			else if(pos.position.y > limitAlt.y)
			{
				y = Random.Range(limitY.x, 0);
			}
			else
			{
				y = Random.Range(limitY.x, limitY.y);
			}

			Instantiate(chao, new Vector3(transform.position.x + x, transform.position.y + y, 0), transform.rotation);
		}
	}
}
