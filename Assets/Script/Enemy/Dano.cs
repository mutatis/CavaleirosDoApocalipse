using UnityEngine;
using System.Collections;

public class Dano : MonoBehaviour {

	public int health;
	public SpriteRenderer sprite;
	public BoxCollider2D box;
    public int scoreValue;

	// Use this for initialization
	void Start () 
	{
		health = Random.Range (0, 3);
		if (health == 1)
			sprite.color = Color.white;
		else if (health == 2)
			sprite.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	IEnumerator FlashOnDamage()
	{
		sprite.color = Color.red;
		yield return new WaitForSeconds(0.2f);
		sprite.color = Color.white;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Tiro")
		{
            TakeDamage(1);
		}
		else if(collision.gameObject.tag == "Slash")
		{
            TakeDamage(1);
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
            TakeDamage(1);
        }
        else if(collision.gameObject.tag == "Slash")
        {
            TakeDamage(1);
        }
        else if(collision.gameObject.tag == "Espinho")
        {
            box.isTrigger = true;
        }
    }

    void TakeDamage(int dano) 
    {
        health -= dano;
        if (health <= 0)
        {
            Die();
        }
        StartCoroutine("FlashOnDamage");
    }

    void Die()
    {
        PlayerAll.playerTrans.score += scoreValue;
        Destroy(gameObject);
    }
}
