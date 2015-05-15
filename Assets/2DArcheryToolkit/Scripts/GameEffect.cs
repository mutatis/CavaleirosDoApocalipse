using UnityEngine;
using System.Collections;

/// <summary>
/// Game effect script.
/// </summary>
public class GameEffect : MonoBehaviour
{
		/// <summary>
		/// Hide the effect.
		/// </summary>
		public void Hide ()
		{
				///Hide the effect using animator
				GetComponent<Animator> ().SetBool ("Show", false);
		}
}