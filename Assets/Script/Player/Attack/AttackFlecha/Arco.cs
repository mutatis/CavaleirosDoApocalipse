using UnityEngine;
using System.Collections;

public class Arco : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = Movment.playerTrans.transform.position;
	}
}
