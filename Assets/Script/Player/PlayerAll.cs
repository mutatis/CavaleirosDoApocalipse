using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerAll : MonoBehaviour 
{
	public static PlayerAll playerTrans;

	public float jumpF;
	public float x;
	public float limit;
	public float multip;

	public Slider sli;

	public BoxCollider2D box;

	public SpriteRenderer sprite;

	[HideInInspector]
	public bool jump = true;

	float life = 1;
	float tempo = 0.3f;
	float soma;

	void Awake()
	{
		playerTrans = this;
	}

	// Use this for initialization
	void Start () 
	{
		soma = limit + transform.position.x;
	}	
	
	// Update is called once per frame
	void Update () 
	{
		if(soma < transform.position.x)
		{
			x *= multip;
			soma = limit + transform.position.x;
		}

		if(sli.value > life)
		{
			sli.value -= 0.01f;
		}
		else
		{
			sli.value = life;
		}

		if(sli.value <= 0)
		{
			Application.LoadLevel("MudaCena");
		}

		transform.Translate(x * Time.deltaTime, 0, 0);

		if(Input.GetKeyDown(KeyCode.UpArrow) && jump)
		{
			rigidbody2D.AddForce(Vector2.up * jumpF, ForceMode2D.Impulse);
			//rigidbody2D.velocity = new Vector2(0, jumpF);
			jump = false;
		}
	}

	public void Jump()
	{
		if(jump)
		{
			rigidbody2D.AddForce(Vector2.up * jumpF, ForceMode2D.Impulse);
			//rigidbody2D.velocity = new Vector2(0, jumpF);
			jump = false;
		}
	}

	IEnumerator GO()
	{
		sprite.color = Color.red;
		yield return new WaitForSeconds (tempo);
		sprite.color = Color.white;
		StopCoroutine("GO");
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			life -= 0.1f;
			StartCoroutine("GO");
            Destroy(collision.gameObject);
		}
		else if(collision.gameObject.tag == "Espinho")
		{
			box.isTrigger = true;
			life -= 0.1f;
			StartCoroutine("GO");
		}
		else if(collision.gameObject.tag == "Ground")
		{
			jump = true;
		}
	}

	/*void OnCollisionExit2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ground")
		{
			jump = false;
		}
	}*/

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			life -= 0.1f;
			StartCoroutine("GO");
			Destroy(collision.gameObject);
		}
		else if(collision.gameObject.tag == "Espinho")
		{
			box.isTrigger = true;
			life -= 0.1f;
			StartCoroutine("GO");
		}
		else if(collision.gameObject.tag == "Ground")
		{
			jump = true;
		}
	}

	/*void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Ground")
		{
			jump = false;
		}
	}*/
}
