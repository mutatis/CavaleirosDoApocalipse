using UnityEngine;
using System.Collections;

public class Mordida : MonoBehaviour 
{
	//bool attack;
	public PolygonCollider2D box;

	public SpriteRenderer sprite;

	public Rigidbody2D rig;

	public float gorduraMax;

	float comeu;
	float vel;
	float gorduraMin;

	// Use this for initialization
	void Start () 
	{
		vel = PlayerAll.playerTrans.x;
		comeu = rig.mass;
		gorduraMin = rig.mass;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = PlayerAll.playerTrans.transform.position;
		if(comeu <= gorduraMax)
		{
			rig.mass = comeu;
		}
		else
		{
			StartCoroutine("Emagrece");
		}
	}

	IEnumerator Emagrece()
	{
		sprite.color = Color.gray;
		yield return new WaitForSeconds(2);
		rig.mass = gorduraMin;
		PlayerAll.playerTrans.x = vel;
		sprite.color = Color.white;
		comeu = gorduraMin;
	}

	public void Attack()
	{
		StopCoroutine("GO");
		StartCoroutine("GO");
	}

	IEnumerator GO()
	{
		yield return new WaitForSeconds (0.7f);
		box.enabled = false;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			Destroy(collision.gameObject);
			PlayerAll.playerTrans.x -= 0.5f;
			comeu += 0.1f;
		}
	}
	void OnCollisionStay2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			Destroy(collision.gameObject);
			PlayerAll.playerTrans.x -= 0.5f;
			comeu += 0.1f;
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			Destroy(collision.gameObject);
			PlayerAll.playerTrans.x -= 0.5f;
			comeu += 0.1f;
		}
	}
	
	void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			Destroy(collision.gameObject);
			PlayerAll.playerTrans.x -= 0.5f;
			comeu += 0.1f;
		}
	}
}