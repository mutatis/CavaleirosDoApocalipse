using UnityEngine;
using System.Collections;

public class Terrestre : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(((Movment.playerTrans.x / 2) * -1) * Time.deltaTime, 0, 0);
	}
}
