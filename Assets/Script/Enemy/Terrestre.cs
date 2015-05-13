using UnityEngine;
using System.Collections;

public class Terrestre : MonoBehaviour 
{
	float x;
	// Use this for initialization
	void Start () 
	{
		x = Movment.playerTrans.x;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(((x / 2) * -1) * Time.deltaTime, 0, 0);
	}
}
