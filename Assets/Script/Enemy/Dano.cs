using UnityEngine;
using System.Collections;

public class Dano : MonoBehaviour {

	int tiro;
	public int life;
	public SpriteRenderer sprite;
	public BoxCollider2D box;

	// Use this for initialization
	void Start () 
	{
		life = Random.Range (0, 3);
		if (life == 1)
			sprite.color = Color.white;
		else if (life == 2)
			sprite.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(tiro >= life)
		{
			Destroy(gameObject);
		}
	}

	IEnumerator GO()
	{
		sprite.color = Color.red;
		yield return new WaitForSeconds(0.2f);
		sprite.color = Color.white;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Tiro")
		{
			Destroy(collision.gameObject);
			sprite.color = Color.white;
			tiro++;
			StartCoroutine("GO");
		}
		else if(collision.gameObject.tag == "Slash")
		{
			sprite.color = Color.white;
			tiro ++;
			StartCoroutine("GO");
		}
		else if(collision.gameObject.tag == "Espinho")
		{
			box.isTrigger = true;
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Tiro")
		{
			sprite.color = Color.white;
			Destroy(collision.gameObject);
			tiro++;
			StartCoroutine("GO");
		}
		else if(collision.gameObject.tag == "Slash")
		{
			sprite.color = Color.white;
			tiro ++;
			StartCoroutine("GO");
		}
		else if(collision.gameObject.tag == "Espinho")
		{
			box.isTrigger = true;
		}
	}
}
