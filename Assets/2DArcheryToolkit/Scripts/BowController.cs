using UnityEngine;
using System.Collections;

public class BowController : MonoBehaviour
{
		/// <summary>
		/// The bow arrow prefab.
		/// </summary>
		public GameObject bowArrowPrefab;

		/// <summary>
		/// The current arrow.
		/// </summary>
		private GameObject currentArrow;

		/// <summary>
		/// The angle variable.
		/// </summary>
		private float angle;

		/// <summary>
		/// The angle offset variable.
		/// </summary>
		private float angleOffset;

		/// <summary>
		/// The click position.
		/// </summary>
		private Vector3 clickPosition;

		/// <summary>
		/// The click limit point.
		/// </summary>
		public Transform clickLimitPoint;

		/// <summary>
		/// The direction variable.
		/// </summary>
		private Vector3 direction;

		/// <summary>
		/// The temp euler angle.
		/// </summary>
		private Vector3 tempEulerAngle;

		/// <summary>
		/// The arrow force.
		/// </summary>
		private Vector2 arrowForce;

		/// <summary>
		/// Whether the click began on screen.
		/// </summary>
		private bool clickBegan;

		/// <summary>
		/// Whether to lanuch the arrow.
		/// </summary>
		private bool lanuchTheArrow;

		/// <summary>
		/// The distance variable.
		/// </summary>
		private Vector3 distance;

		/// <summary>
		/// The arrow position.
		/// </summary>
		private Vector3 arrowPosition;

		/// <summary>
		/// The screen touch.
		/// </summary>
		private Touch screenTouch;

		/// <summary>
		/// Whether the current platform is  mobile.
		/// </summary>
		private bool mobilePlatform;

		/// <summary>
		/// The arrow swoosh sound effect.
		/// </summary>
		public AudioClip arrowSwooshSFX;

		/// <summary>
		/// The arrow component reference.
		/// </summary>
		private Arrow arrowComponent;

		/// <summary>
		/// The bow rope component reference.
		/// </summary>
		public BowRope bowRopeComponent;

		/// <summary>
		/// The arrow parent reference.
		/// </summary>
		public Transform arrowParent;

		/// <summary>
		/// The rope transform reference.
		/// </summary>
		public Transform ropeTransform;

		// Use this for initialization
		void Start ()
		{
				///Setting up the references
				mobilePlatform = Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer;

				if (ropeTransform == null) {
						ropeTransform = transform.Find ("Rope");
				}

				if (clickLimitPoint == null) {
						clickLimitPoint = GameObject.Find ("ClickLimitPoint").transform;
				}

				if (bowRopeComponent == null) {
						bowRopeComponent = ropeTransform.GetComponent<BowRope> ();
				}

				if (arrowParent == null) {
						arrowParent = GameObject.Find ("UICanvas").transform;
				}

				///Create an arrow for the bow
				//CreateArrow ();
		}

		// Update is called once per frame
		void Update ()
		{
				///When the current platform is mobile (Android | IOS)
				if (mobilePlatform) {
						if (Input.touchCount != 0) {
								///Get the screen's first touch
								screenTouch = Input.GetTouch (0);
								if (screenTouch.phase == TouchPhase.Began) {
										///Click began
										ClickBegan (screenTouch.position);
								} else if (screenTouch.phase == TouchPhase.Moved) {
										///Click moved
										ClickMoved (screenTouch.position);
								} else if (screenTouch.phase == TouchPhase.Ended) {
										///Click released
										ClickReleased (screenTouch.position);
								}
						}
				} else {
						if (Input.GetMouseButtonDown (0)) {
								//Mouse click began
								ClickBegan (Input.mousePosition);
						} else if (Input.GetMouseButtonUp (0)) {
								//Mouse click released
								ClickReleased (Input.mousePosition);
						}
			
						if (clickBegan) {
								//Mouse click moved
								ClickMoved (Input.mousePosition);
						}
				}
		}

		void FixedUpdate ()
		{
				///Whether to launch the arrow
				if (lanuchTheArrow) 
				{
					///Reset lanuchTheArrow flag 
					lanuchTheArrow = false;
					///Launch the arrow
					LaunchTheArrow ();
				}
		}

		/// <summary>
		/// On Screen Click Began
		/// </summary>
		/// <param name="pos">Click position in pixels.</param>
		private void ClickBegan (Vector3 pos)
		{
			CreateArrow ();
			clickBegan = true;
		}

		/// <summary>
		/// On Screen Click Moved
		/// </summary>
		/// <param name="pos">Click position in pixels.</param>
		private void ClickMoved (Vector3 pos)
		{
				///Getting the click position in the world space
				clickPosition = Camera.main.ScreenToWorldPoint (pos);
				if (clickPosition.x >= clickLimitPoint.position.x) {//if the click positin is equals or more than the click limit point
						return;
				}

				///Calculate the direction
				direction = clickPosition - transform.position;
				
				///The angle between the click position and the bow position
			  	///To clamp the angle use Mathf.clamp function
				angle = Mathf.Atan2 (direction.x, -direction.y) * Mathf.Rad2Deg + 90;

				tempEulerAngle = transform.eulerAngles;
				tempEulerAngle.z = angle;
				transform.eulerAngles = tempEulerAngle;
			
				if (currentArrow != null) {
						///Pull or drag the arrow relative to click position
						distance = ropeTransform.position - clickPosition;
						arrowPosition = currentArrow.transform.position;
						arrowPosition.x = arrowComponent.rightClampPoint.position.x - distance.x;
						arrowPosition.y = arrowComponent.rightClampPoint.position.y - distance.y;
						currentArrow.transform.position = arrowPosition;
				}
		}

		/// <summary>
		/// On Screen Click Released
		/// </summary>
		private void ClickReleased (Vector3 pos)
		{
				if (clickBegan) {
						//reset flags
						clickBegan = false;
						clickPosition = Camera.main.ScreenToWorldPoint (pos);
						if (clickPosition.x < clickLimitPoint.position.x) {//if the click position is less than the click limit point
								lanuchTheArrow = true;
						}
				}
		}

		/// <summary>
		/// Create an arrow for the bow.
		/// </summary>
		public void CreateArrow ()
		{
		/*		if (DataManager.NumberOfArrows == 0) {
						return;
				}*/

				currentArrow = Instantiate (bowArrowPrefab, bowArrowPrefab.transform.position, bowArrowPrefab.transform.rotation) as GameObject;
				//Set the name of the arrow
				currentArrow.name = "Arrow";
				//Set the parent of the arrow
				currentArrow.transform.SetParent (transform);
				//Set the scale of the arrow
				currentArrow.transform.localScale = bowArrowPrefab.transform.localScale;
				//Enable the arrow
				currentArrow.SetActive (true);
				//Setting up the arrow end point reference
				bowRopeComponent.arrowEndPoint = currentArrow.transform.Find ("ArrowLowPoint");
				//Setting up the arrow componentd reference
				arrowComponent = currentArrow.GetComponent<Arrow> ();
		}

		/// <summary>
		/// Launch the arrow.
		/// </summary>
		private void LaunchTheArrow ()
		{
				/*if (currentArrow == null || DataManager.NumberOfArrows == 0) {
						return;
				}*/

				arrowForce = currentArrow.transform.up * arrowComponent.power;
		
				///Check the arrow's force magnitude(launch requirements : force magnitude less than or equas 150)
			/*	if (arrowForce.magnitude <= 150) {
						return;
				}*/
	
				///Decrease the number of arrows
			//	DataManager.NumberOfArrows--;
			
				bowRopeComponent.arrowEndPoint = null;
				currentArrow.transform.SetParent (arrowParent);
				///Enable the arrow's trail
				currentArrow.transform.Find ("ArrowLowPoint").Find ("trail").gameObject.SetActive (true);
				currentArrow.GetComponent<Rigidbody2D>().isKinematic = false;
				arrowComponent.launched = true;
				///Add force to the arrow
				currentArrow.GetComponent<Rigidbody2D>().AddForce (arrowForce, ForceMode2D.Force);
				///Play the launch sound effect
				if (arrowSwooshSFX != null) {
						AudioSource.PlayClipAtPoint (arrowSwooshSFX, Vector3.zero);
				}
				currentArrow = null;
		}
}