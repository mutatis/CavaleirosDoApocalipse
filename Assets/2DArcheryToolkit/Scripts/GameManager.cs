using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Game manager.
/// </summary>
public class GameManager : MonoBehaviour
{
		/// <summary>
		/// The static instance for this class.
		/// </summary>
		public static GameManager instance;

		void Start ()
		{ 
				///Setting up the instance
				if (instance == null) {
						instance = this;
				}
		}

		/// <summary>
		/// Check the number of arrows,if equals zero then load the score scene
		/// </summary>
		public void CheckArrowsNumber ()
		{
				if (DataManager.NumberOfArrows == 0) {
						///Save the new score
						try {
								DataManager.SaveNewScore ();
						} catch (Exception ex) {
								Debug.Log (ex.Message);
						}
						StartCoroutine ("LoadScoreScene");
				}
		}

		/// <summary>
		/// Load the score scene coroutine.
		/// </summary>
		private IEnumerator LoadScoreScene ()
		{
				yield return new WaitForSeconds (2);
				Application.LoadLevel ("Score");
		}
}