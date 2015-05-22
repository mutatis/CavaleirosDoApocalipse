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
	float vCome = 0.1f;
	float vVel = 0.5f;

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
	}

	IEnumerator Emagrece()
	{
		yield return new WaitForSeconds(2);
		StartCoroutine("Emagrecendo");
	}

	IEnumerator Emagrecendo()
	{
		yield return new WaitForSeconds (1);
		if(rig.mass >= 1)
		{
			rig.mass -= vCome;		
		}
		if(PlayerAll.playerTrans.x <= vel)
		{
			PlayerAll.playerTrans.x += vVel;
		}
		StartCoroutine ("Emagrecendo");
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

	void Bateu()
	{
		PlayerAll.playerTrans.x -= vVel;
		comeu += vCome;
		StartCoroutine("Emagrece");			
		StopCoroutine("Emagrecendo");
		if(comeu <= gorduraMax)
		{
			rig.mass = comeu;
		}
		else
		{		
			sprite.color = Color.white;
			comeu = gorduraMin;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			Destroy(collision.gameObject);
			Bateu ();
		}
	}
	void OnCollisionStay2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			Destroy(collision.gameObject);
			Bateu ();
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			Destroy(collision.gameObject);
			Bateu ();
		}
	}
	
	void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			Destroy(collision.gameObject);
			Bateu ();
		}
	}
}