using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{

	public float smooth;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3(Movment.playerTrans.transform.position.x + smooth, 0, -10);
	}
}
