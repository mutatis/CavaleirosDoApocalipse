using UnityEngine;
using System.Collections;

public class Movment : MonoBehaviour 
{
	public float x;
	public static Movment playerTrans;
	public float jumpF;
	bool jump = true;

	void Awake()
	{
		playerTrans = this;
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(x * Time.deltaTime, 0, 0);
		if(Input.GetKeyDown(KeyCode.UpArrow) && jump)
		{
			rigidbody2D.velocity = new Vector2(0, jumpF);
			jump = false;
		}
	}

	public void Jump()
	{
		if(jump)
		{
			rigidbody2D.velocity = new Vector2(0, jumpF);
			jump = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			Destroy(collision.gameObject);
		}
		if(collision.gameObject.tag == "Ground")
		{
			jump = true;
		}
	}
}
