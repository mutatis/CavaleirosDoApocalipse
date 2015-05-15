using UnityEngine;
using System.Collections;

/// <summary>
/// Arrow script.
/// </summary>
public class Arrow : MonoBehaviour
{
        
		/// <summary>
		/// The target component.
		/// </summary>
		private static Target target;

		/// <summary>
		/// The bow controller component.
		/// </summary>
		public BowController bowControllerComponent;

		/// <summary>
		/// The left,right clamp point for the arrow.
		/// </summary>
		public Transform leftClampPoint, rightClampPoint;

		/// <summary>
		/// The arrow position.
		/// </summary>
		private Vector3 arrowPosition;

		/// <summary>
		/// Whether the arrow is launched.
		/// </summary>
		[HideInInspector]
		public bool launched;

		/// <summary>
		/// The launch power for the arrow.
		/// </summary>
		[HideInInspector]
		public float power;

		/// <summary>
		/// The power factor.
		/// </summary>
		private float powerFactor = 2000;
        
        

		void Start ()
		{
				///Setting up the references
				if (target == null) {
						target = GameObject.Find ("Target").GetComponent<Target> ();
				}

				if (bowControllerComponent == null) {
						bowControllerComponent = GameObject.Find ("Bow").GetComponent<BowController> ();
				}

				Transform arrowClamPoints = bowControllerComponent.transform.Find ("ArrowClampPoints");

				if (rightClampPoint == null) {
						rightClampPoint = arrowClamPoints.Find ("RightClampPoint");
				}

				if (leftClampPoint == null) {
						leftClampPoint = arrowClamPoints.Find ("LeftClampPoint");
				}
		}

		void Update ()
		{
				if (!launched) {
						ClampPosition ();
						CalculatePower ();
				}
		}

		/// <summary>
		/// Clamp the position of the arrow.
		/// </summary>
		private void ClampPosition ()
		{
				///Get the position of the arrow
				arrowPosition = transform.position;
				///Clamp the x-position between min and max points
				arrowPosition.x = Mathf.Clamp (arrowPosition.x, Mathf.Min (rightClampPoint.position.x, leftClampPoint.position.x), Mathf.Max (rightClampPoint.position.x, leftClampPoint.position.x));
				///Clamp the y-position between min and max points
				arrowPosition.y = Mathf.Clamp (arrowPosition.y, Mathf.Min (rightClampPoint.position.y, leftClampPoint.position.y), Mathf.Max (rightClampPoint.position.y, leftClampPoint.position.y));
				///Set new position for the arrow
				transform.position = arrowPosition;
		}

		/// <summary>
		/// Calculate the launch power for the arrow.
		/// </summary>
		private void CalculatePower ()
		{
				power = Vector2.Distance (transform.position, rightClampPoint.position) * powerFactor;
		}

		/// <summary>
		/// Destory the arrow and create new one.
		/// </summary>
		public void DestroyArrow ()
		{
				///Create new arrow
				bowControllerComponent.CreateArrow ();
				///Destroy the current arrow
				Destroy (gameObject);
		}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == ("Enemy")) 
		{
			Destroy (col.gameObject);
			Destroy (gameObject);
		}
	}
}