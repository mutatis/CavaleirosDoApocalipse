using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScore : MonoBehaviour 
{

	public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		text.text = PlayerAll.playerTrans.score + "";
	}
}
