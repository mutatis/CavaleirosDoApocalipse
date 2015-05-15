using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

/// <summary>
/// Game data manager script.
/// </summary>
[DisallowMultipleComponent]
public class DataManager : MonoBehaviour
{
		/// <summary>
		/// The UI score text.
		/// </summary>
		public static Text scoreText;

		/// <summary>
		/// The UI arrows text.
		/// </summary>
		private static Text arrowsText;

		/// <summary>
		/// The current score.
		/// </summary>
		private static int currentScore;

		/// <summary>
		/// The number of arrows.
		/// </summary>
		private static int numberOfArrows;

		/// <summary>
		/// The name of the file.
		/// </summary>
		private static string fileName = "2dArchery.bin";

		/// <summary>
		/// The path of the file.
		/// </summary>
		private static string path;

		/// <summary>
		/// The player data reference.
		/// </summary>
		private static PlayerData playerData;

		/// <summary>
		/// Whether to initiate/load the player's on awake
		/// </summary>
		public bool initiatePlayerDataOnAwake = true;

		/// <summary>
		/// Whether to set the default data for the score and number of arrows on awake.
		/// </summary>
		public bool setDefaultDataOnAwake = true;

		void Awake ()
		{
				#if UNITY_IPHONE
					//Enable the MONO_REFLECTION_SERIALIZER(For IOS Platform Only)
					System.Environment.SetEnvironmentVariable ("MONO_REFLECTION_SERIALIZER", "yes");
				#endif

				if (initiatePlayerDataOnAwake) {

						///Load player data from the file
						playerData = LoadPlayerDataFromFile ();
						if (playerData == null) {
								///Define new player data
								playerData = new PlayerData ();
								///Save it to the file
								SavePlayerDataToFile ();
						}
				}

				if (setDefaultDataOnAwake) {

						///Setting up the references
						if (scoreText == null) {
								scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
						}

						if (arrowsText == null) {
								arrowsText = GameObject.Find ("ArrowsText").GetComponent<Text> ();
						}

						///Reset the current score
						ResetCurrentScore ();
						///Reset the number of arrows
						ResetNumberOfArrows ();

						//Apply the score on the score's UI text
						ApplyCurrentScoreOnUI ();
						//Apply the number of arrows on the arrow's UI text
						ApplyNumberOfArrowsOnUI ();
				}
		}

		/// <summary>
		/// Apply the current score on score's UI text.
		/// </summary>
		private static void ApplyCurrentScoreOnUI ()
		{
				if (scoreText == null) {
						return;
				}
				scoreText.text = "Score : " + currentScore;
		}

		/// <summary>
		/// Applies the number of arrows on arrow's UI text.
		/// </summary>
		private static void ApplyNumberOfArrowsOnUI ()
		{
				if (arrowsText == null) {
						return;
				}
				arrowsText.text = "Arrows : " + numberOfArrows;
		}

		/// <summary>
		/// Reset the number of arrows.
		/// </summary>
		public static void ResetNumberOfArrows ()
		{
				numberOfArrows = 20;
		}

		/// <summary>
		/// Reset the current score.
		/// </summary>
		public static void ResetCurrentScore ()
		{
				currentScore = 0;
		}

		///PlayerData class
		[System.Serializable]
		public class PlayerData
		{
				public int bestScore;
				public int previousScore;
		}

		/// <summary>
		/// Save the player data to the file.
		/// </summary>
		public static void SavePlayerDataToFile ()
		{
				Debug.Log ("Saving Player Data...");
				SettingUpFilePath ();
				if (string.IsNullOrEmpty (path)) {
						Debug.Log ("Null or Empty path");
						return;
				}
		
				if (playerData == null) {
						Debug.Log ("Null Data");
						return;
				}
		
				FileStream file = null;
				try {
						BinaryFormatter bf = new BinaryFormatter ();
						file = File.Open (path, FileMode.Create);
						bf.Serialize (file, playerData);
						file.Close ();
				} catch (Exception ex) {
						file.Close ();
						Debug.LogError ("Exception : " + ex.Message);
				}
		}

		/// <summary>
		/// Load the player data from the file.
		/// </summary>
		/// <returns>The player data.</returns>
		public static PlayerData LoadPlayerDataFromFile ()
		{
				Debug.Log ("Loading Player Data...");
				SettingUpFilePath ();
				if (string.IsNullOrEmpty (path)) {
						Debug.Log ("Null or Empty path");
						return null;
				}
				if (!File.Exists (path)) {
						Debug.Log (path + " is not exists");
						return null;
				}
		
				PlayerData playerData = null;
				FileStream file = null;
				try {
						BinaryFormatter bf = new BinaryFormatter ();
						file = File.Open (path, FileMode.Open);
						playerData = (PlayerData)bf.Deserialize (file);
						file.Close ();
				} catch (Exception ex) {
						file.Close ();
						Debug.LogError ("Exception : " + ex.Message);
				}
		
				return playerData;
		}

		public static void SaveNewScore ()
		{
				playerData.previousScore = currentScore;
				if (currentScore > playerData.bestScore) {
						playerData.bestScore = currentScore;
				}
				SavePlayerDataToFile ();
		}

		/// <summary>
		/// Settings up the path of the file ,relative to the current platform.
		/// </summary>
		private static void SettingUpFilePath ()
		{
				if (Application.platform == RuntimePlatform.Android) {//Android Platform
						path = Application.persistentDataPath;
				} else if (Application.platform == RuntimePlatform.IPhonePlayer) {//IOS Platform
						///Get iPhone Documents Path
						string dataPath = Application.dataPath;
						string fileBasePath = dataPath.Substring (0, dataPath.Length - 5);
						path = fileBasePath.Substring (0, fileBasePath.LastIndexOf ('/')) + "/Documents";
				} else {//Others
						path = Application.dataPath;
				}
		
				path += "/" + fileName;
		}

		/// <summary>
		/// Get or set the current score.
		/// </summary>
		/// <value>The current score.</value>
		public static int CurrentScore {
				get { return currentScore;}
				set {
						currentScore = value;
						ApplyCurrentScoreOnUI ();
				} 
		}

		/// <summary>
		/// Get or set the number of arrows.
		/// </summary>
		/// <value>The number of arrows.</value>
		public static int NumberOfArrows {
				get { return numberOfArrows;}
				set {
						numberOfArrows = value;
						///Apply number of arrows on arrow's UI text
						ApplyNumberOfArrowsOnUI ();
				}
		}
}