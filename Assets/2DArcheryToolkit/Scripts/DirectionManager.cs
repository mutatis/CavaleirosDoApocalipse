using UnityEngine;
using System.Collections;

/// <summary>
/// Arrow's direction manager.
/// </summary>
public class DirectionManager : MonoBehaviour
{
		/// <summary>
		/// The angle of the arrow.
		/// </summary>
		private float angle;

		/// <summary>
		/// The velocity of the arrow.
		/// </summary>
		private Vector2 velocity;

		/// <summary>
		/// The top left screen point.
		/// </summary>
		private Vector2 topLeftScreenPoint;

		/// <summary>
		/// The bottom right screen point.
		/// </summary>
		private Vector2 bottomRightScreenPoint;

		/// <summary>
		/// The arrow position.
		/// </summary>
		private Vector2 arrowPosition;

		/// <summary>
		/// The position offset.
		/// </summary>
		private Vector2 offset = new Vector2 (8, 8);

		/// <summary>
		/// The x-poistion inside screen ,y-position inside screen flags.
		/// </summary>
		private bool xIn, yIn;

		/// <summary>
		/// The arrow rigd body component.
		/// </summary>
		private Rigidbody2D arrowRigdBody;

		void Start ()
		{
				///Calculate the top-left screen point
				topLeftScreenPoint = Camera.main.ScreenToWorldPoint (new Vector2 (0, Screen.height));
				///Calculate the bottom-right screen point
				bottomRightScreenPoint = Camera.main.ScreenToWorldPoint (new Vector2 (Screen.width, 0));

				//Get the rigidbody of the arrow
				if (arrowRigdBody == null) {
						arrowRigdBody = transform.GetComponent<Rigidbody2D>();
				}
		}

		void Update ()
		{
				///Get the velocity of the arrow
				velocity = arrowRigdBody.velocity;
				if (velocity.magnitude != 0 && !arrowRigdBody.isKinematic) {
						///Calculate the angle of the arrow
						angle = (Mathf.Atan2 (velocity.x, -velocity.y) * Mathf.Rad2Deg + 180);
						///Set the rotation of the arrow
						transform.rotation = Quaternion.AngleAxis (angle, transform.forward);
						///Check the arrow bounds
						CheckArrowBounds ();
				}
		}

		/// <summary>
		/// Check the arrow bounds.
		/// If the arrow position is out of screen , then destroy the arrow.
		/// </summary>
		private void CheckArrowBounds ()
		{
		       //Get the position of the arrow
				arrowPosition = transform.position;

				xIn = (arrowPosition.x >= topLeftScreenPoint.x - offset.x && arrowPosition.x <= bottomRightScreenPoint.x + offset.x);
				yIn = (arrowPosition.y >= bottomRightScreenPoint.y - offset.y && arrowPosition.y <= topLeftScreenPoint.y + offset.y);
			
				if (!(xIn && yIn)) {
						///Create new arrow
						GetComponent<Arrow> ().bowControllerComponent.CreateArrow ();
						///Destroy the current arrow
						Destroy (gameObject);
						///Check the number of arrows
//						GameManager.instance.CheckArrowsNumber();
						return;
				}
		}
}