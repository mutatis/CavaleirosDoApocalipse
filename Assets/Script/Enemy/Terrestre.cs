using UnityEngine;
using System.Collections;

public class Terrestre : MonoBehaviour 
{
	float x;
	int mult;
	public Animator anim;
	bool anda;

	// Use this for initialization
	void Start () 
	{
		Vector3 theScale = transform.localScale;
		x = Movment.playerTrans.x;
		mult = Random.Range (-2, 2);
		if(mult == 0)
		{
			anim.enabled = false;
		}
		else if(mult == -2)
		{
			mult = -1;
		}
		else if(mult == 2)
		{
			mult = 1;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
		else if(mult == 1)
		{
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(anda)
		{
			transform.Translate(((x / 2) * mult) * Time.deltaTime, 0, 0);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Play")
		{
			anda = true;
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Play")
		{
			anda = true;
		}
	}
}
