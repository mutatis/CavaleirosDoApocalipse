using UnityEngine;
using System.Collections;

public class Criador : MonoBehaviour 
{

	public GameObject cria;
	public float y;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			Instantiate(cria, new Vector3(transform.position.x + 2, y, 0), transform.rotation);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			Instantiate(cria, new Vector3(transform.position.x + 2, y, 0), transform.rotation);
		}
	}
}
