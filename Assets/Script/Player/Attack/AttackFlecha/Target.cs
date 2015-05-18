using UnityEngine;
using System.Collections;

/// <summary>
/// Arrow Target script.
/// </summary>
[ExecuteInEditMode]
public class Target : MonoBehaviour
{
		/// <summary>
		/// The lower point transform.
		/// Used to create an area for the target
		/// </summary>
		public Transform lp;
		
		/// <summary>
		/// The top point transform.
		/// Used to create an area for the target
		/// </summary>
		public Transform tp;

		/// <summary>
		/// The traget position.
		/// </summary>
		private Vector3 tragetPosition;

		/// <summary>
		/// The minimum postion.
		/// </summary>
		private Vector3 minPostion;

		/// <summary>
		/// The max postion.
		/// </summary>
		private Vector3 maxPostion;

		/// <summary>
		/// The color of the area's lines.
		/// </summary>
		private Color linesColor = Color.green;

		// Use this for initialization
		void Start ()
		{
			/*	///Setting up the references
				if (lp == null) {
						lp = GameObject.Find ("TargetArea").transform.Find ("LP").transform;
				}

				if (tp == null) {
						tp = GameObject.Find ("TargetArea").transform.Find ("TP").transform;
				}*/
		         
				//Set random position for the target using the lp(lower point) and the tp(top point)
				SetRandomPosition ();
		}

		void Update ()
		{
				#if UNITY_EDITOR
		           ///Draw target area
					DrawArea();
				#endif
		}

		/// <summary>
		/// Set a random position for the target using the area.
		/// </summary>
		public void SetRandomPosition ()
		{
/*				minPostion = lp.position;
				maxPostion = tp.position;*/
				tragetPosition = transform.position;
				tragetPosition.x = Random.Range (minPostion.x, maxPostion.x);///random x-position
				tragetPosition.y = Random.Range (minPostion.y, maxPostion.y);///random y-position
				transform.position = tragetPosition;
		}

		/// <summary>
		/// Draw the area of the target.
		/// </summary>
		private void DrawArea ()
		{
/*				minPostion = lp.position;
				maxPostion = tp.position;*/
				Debug.DrawLine (minPostion, new Vector3 (maxPostion.x, minPostion.y, minPostion.z), linesColor);
				Debug.DrawLine (new Vector3 (minPostion.x, maxPostion.y, maxPostion.z), maxPostion, linesColor);
				Debug.DrawLine (minPostion, new Vector3 (minPostion.x, maxPostion.y, minPostion.z), linesColor);
				Debug.DrawLine (new Vector3 (maxPostion.x, minPostion.y, maxPostion.z), maxPostion, linesColor);
		}
}