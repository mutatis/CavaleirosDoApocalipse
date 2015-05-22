using UnityEngine;
using System.Collections;

public class GerenciaM : MonoBehaviour 
{
	public GameObject retry;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(PlayerAll.playerTrans.life <= 0)
		{
			retry.SetActive(true);
			Time.timeScale = 0;
		}
	}
}
