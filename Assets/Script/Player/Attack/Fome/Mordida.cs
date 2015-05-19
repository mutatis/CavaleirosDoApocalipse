using UnityEngine;
using System.Collections;

public class Mordida : MonoBehaviour 
{
	//bool attack;
	public PolygonCollider2D box;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = PlayerAll.playerTrans.transform.position;
	}

	public void Attack()
	{
		//attack = true;
		StopCoroutine("GO");
		//box.enabled = true;
		StartCoroutine("GO");
	}

	IEnumerator GO()
	{
		yield return new WaitForSeconds (0.7f);
		box.enabled = false;
		//attack = false;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			//if(attack)
			Destroy(collision.gameObject);
		}
	}
	void OnCollisionStay2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
		//	if(attack)
				Destroy(collision.gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
		//	if(attack)
			Destroy(collision.gameObject);
		}
	}
	
	void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
		//	if(attack)
			Destroy(collision.gameObject);
		}
	}
}