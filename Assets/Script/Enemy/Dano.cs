using UnityEngine;
using System.Collections;

public class Dano : MonoBehaviour {

	int tiro;
	public SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(tiro >= 2)
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
			tiro++;
			StartCoroutine("GO");
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Tiro")
		{
			Destroy(collision.gameObject);
			tiro++;
			StartCoroutine("GO");
		}
	}
}
