using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerAll : MonoBehaviour 
{
	public static PlayerAll playerTrans;

    //Parâmetros
    public float life = 1;
    public int score;

    //Componentes
	public int score;
    public Slider healthSlider;
	BoxCollider2D myBoxCollider;
	SpriteRenderer mySpriteRenderer;

	
	
	float intervaloFlash = 0.3f;
	

	void Awake()
	{
		playerTrans = this;
	}

	void Start () 
	{
        myBoxCollider = GetComponent<BoxCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
	}	
	
	void Update () 
	{
		if(healthSlider.value > life)
		{
			healthSlider.value -= 0.01f;
		}
		else
		{
			healthSlider.value = life;
		}
	}

	IEnumerator FlashOnDamage()
	{
		mySpriteRenderer.color = Color.red;
		yield return new WaitForSeconds (intervaloFlash);
		mySpriteRenderer.color = Color.white;
		StopCoroutine("FlashOnDamage");
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			life -= 0.1f;
			StartCoroutine("FlashOnDamage");
            Destroy(collision.gameObject);
		}
		else if(collision.gameObject.tag == "Espinho")
		{
			myBoxCollider.isTrigger = true;
			life = 0f;
			StartCoroutine("FlashOnDamage");
		}
		
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			life -= 0.1f;
			StartCoroutine("FlashOnDamage");
			Destroy(collision.gameObject);
		}
		else if(collision.gameObject.tag == "Espinho")
		{
			myBoxCollider.isTrigger = true;
            life = 0f;
			StartCoroutine("FlashOnDamage");
		}
	}
}
