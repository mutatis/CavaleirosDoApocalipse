using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void PauseGame()
	{
		Time.timeScale = 0;
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;	
	}
}
