using UnityEngine;
using System.Collections;

public class Flecha : MonoBehaviour
{
	Vector2 pos;
	private Vector2 direction2;
	private Transform player;
	float mouseY;

	// Use this for initialization
	void Start () 
	{


	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonUp(0))
		{
			transform.position = AttackFlecha.attackF.transform.position;
			direction2 = AttackFlecha.attackF.final;
			direction2.Normalize();
		}
		transform.Translate(direction2 / 4);
	}
}
