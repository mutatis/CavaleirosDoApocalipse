using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerAll : MonoBehaviour 
{
	public float x;
	public static PlayerAll playerTrans;
	public float jumpF;
	public Slider sli;
	bool jump = true;
	float life = 1;
	public SpriteRenderer sprite;
	float tempo = 0.3f;

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
		if(collision.gameObject.tag == "Ground")
		{
			jump = true;
		}
	}
}
