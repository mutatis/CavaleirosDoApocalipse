using UnityEngine;
using System.Collections;

/// <summary>
/// UI Element Events.
/// </summary>
public class Events : MonoBehaviour
{
		/// <summary>
		/// The bubble pop sound effect.
		/// </summary>
		public AudioClip bubblePop;

		/// <summary>
		/// Load the game scene.
		/// </summary>
		public void LoadGame ()
		{
				Application.LoadLevel ("Game");
		}

		/// <summary>
		/// Load the menu scene.
		/// </summary>
		public void LoadMenu ()
		{
				Application.LoadLevel ("Menu");
		}

		/// <summary>
		/// Load the how to play scene.
		/// </summary>
		public void LoadHowToPlay ()
		{
				Application.LoadLevel ("HowToPlay");
		}

		/// <summary>
		/// Load the scores scene.
		/// </summary>
		public void LoadScore ()
		{
				Application.LoadLevel ("Score");
		}

		/// <summary>
		/// Play the bubble pop sound effect.
		/// </summary>
		public void PlayBubblePop ()
		{
				if (bubblePop == null) {
						return;
				}
				AudioSource.PlayClipAtPoint (bubblePop, Vector3.zero, 1);
		}
}