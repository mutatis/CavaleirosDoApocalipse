using UnityEngine;
using System.Collections;

public class CriaACria : MonoBehaviour 
{
	public GameObject creat;
	public float x;

	// Use this for initialization
	void Start () 
	{
		Instantiate(creat, new Vector3(transform.position.x + x, transform.position.y, 0), transform.rotation);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
