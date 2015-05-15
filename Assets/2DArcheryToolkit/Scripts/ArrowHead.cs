using UnityEngine;
using System.Collections;

/// <summary>
/// Arrow head script.
/// </summary>
public class ArrowHead : MonoBehaviour
{
		/// <summary>
		/// The name of the collision.
		/// </summary>
		private string collisionName;

		/// <summary>
		/// The arrow transform reference.
		/// </summary>
		private Transform arrowTransform;

		/// <summary>
		/// The plus score sprites.
		/// </summary>
		public Sprite[] plusScore;

		/// <summary>
		/// The arrow impact sound effect.
		/// </summary>
		public AudioClip arrowImpactSFX;

		/// <summary>
		/// The plus score effect animator.
		/// </summary>
		private static Animator plusScoreEffectAnimator;

		/// <summary>
		/// The plus arrow effect animator.
		/// </summary>
		private static Animator plusArrowEffectAnimator;

		/// <summary>
		/// The plus score sprite renderer.
		/// </summary>
		private static SpriteRenderer plusScoreEffectSpriteRenderer;

		/// <summary>
		/// The score effect game object.
		/// </summary>
		public GameObject plusScoreEffectGameObject;

		/// <summary>
		/// The score effect game object.
		/// </summary>
		public GameObject plusArrowEffectGameObject;

		// Use this for initialization
		void Start ()
		{
				///Setting up the references
				if (arrowTransform == null) {
						arrowTransform = transform.parent;
				}

				if (plusScoreEffectGameObject == null) {
						plusScoreEffectGameObject = GameObject.Find ("PlusScoreEffect");
				}

				if (plusArrowEffectGameObject == null) {
						plusArrowEffectGameObject = GameObject.Find ("PlusArrowEffect");
				}

				plusScoreEffectAnimator = plusScoreEffectGameObject.GetComponent<Animator> ();
				plusArrowEffectAnimator = plusArrowEffectGameObject.GetComponent<Animator> ();
				plusScoreEffectSpriteRenderer = plusScoreEffectGameObject.GetComponent<SpriteRenderer> ();
		}
	
		void OnCollisionEnter2D (Collision2D col)
		{
				///On collision with the target collider
				if (col.transform.tag == "TargetCollider" && col.gameObject.tag == "Enemy") {
						///Get the first contacts point
						arrowTransform.transform.position = col.contacts [0].point;
						///Hide arrow head
						arrowTransform.Find ("ArrowHead").gameObject.SetActive (false);
						///Fix the arrow position
						arrowTransform.rigidbody2D.isKinematic = true;
						///Get the collision name
						collisionName = col.transform.name;

						if (collisionName == "50Point-Collider") {
								///Add 2 extra arrow
								DataManager.NumberOfArrows += 2;
								DataManager.CurrentScore += 50;//Add 50 points
								plusScoreEffectSpriteRenderer.sprite = plusScore [4];
				
								///Show the plus arrow effect
								plusArrowEffectAnimator.SetTrigger("Show");
						} else if (collisionName == "40Point-Collider") {
								DataManager.CurrentScore += 40;//Add 40 points
								plusScoreEffectSpriteRenderer.sprite = plusScore [3];
						} else if (collisionName == "30Point-Collider") {
								DataManager.CurrentScore += 30;//Add 30 point
								plusScoreEffectSpriteRenderer.sprite = plusScore [2];
						} else if (collisionName == "20Point-Collider") {
								DataManager.CurrentScore += 20;//Add 20 points
								plusScoreEffectSpriteRenderer.sprite = plusScore [1];
						} else if (collisionName == "10Point-Collider") {
								DataManager.CurrentScore += 10;//Add 10 points
								plusScoreEffectSpriteRenderer.sprite = plusScore [0];
						}

						///Show the plus score effect
						plusScoreEffectAnimator.SetTrigger ("Show");

						///Play the arrow impact sound effect
						if (arrowImpactSFX != null) {
								AudioSource.PlayClipAtPoint (arrowImpactSFX, Vector3.zero);
						}
			      
						///Fade out the arrow's sprite per time
						GetComponentInParent<Animator> ().SetTrigger ("Hide");
			           ///Check the number of arrows
						GameManager.instance.CheckArrowsNumber();
				}
		}


}