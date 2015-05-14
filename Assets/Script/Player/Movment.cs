using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movment : MonoBehaviour 
{
	public float x;
	public static Movment playerTrans;
	public float jumpF;
	public Slider sli;
	bool jump = true;
	float life = 1;

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
		if(sli.value > life)
		{
			sli.value -= 0.01f;
		}
		else
		{
			sli.value = life;
		}
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
			life -= 0.1f;
			Destroy(collision.gameObject);
		}
		if(collision.gameObject.tag == "Ground")
		{
			jump = true;
		}
	}
}
