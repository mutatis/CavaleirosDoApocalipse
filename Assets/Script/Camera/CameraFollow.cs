using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	//public Transform target;
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 point = camera.WorldToViewportPoint(PlayerAll.playerTrans.transform.position);
		Vector3 delta = PlayerAll.playerTrans.transform.position - camera.ViewportToWorldPoint(new Vector3(0.1f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
		Vector3 destination = transform.position + delta;
		transform.position = Vector3.SmoothDamp(transform.position, new Vector3(destination.x, transform.position.y, transform.position.z), ref velocity, dampTime);
	}
}