using UnityEngine;
using System.Collections;

/// <summary>
/// Bow rope script.
/// </summary>
public class BowRope : MonoBehaviour
{
		/// <summary>
		/// The rope1 and rope2 line renderer referecnes.
		/// </summary>
		public LineRenderer rope1, rope2;

		/// <summary>
		/// The bow top point reference.
		/// </summary>
		public Transform bowTopPoint;

		/// <summary>
		/// The bow bottom point reference.
		/// </summary>
		public Transform bowBottomPoint;

		/// <summary>
		/// The arrow end point reference.
		/// </summary>
		public Transform arrowEndPoint;

		/// <summary>
		/// The color of the rope.
		/// </summary>
		public Color color;

		/// <summary>
		/// The width of the rope.
		/// </summary>
		public Vector2 width = new Vector2 (0.03f, 0.03f);

		/// <summary>
		/// The rope material.
		/// </summary>
		public Material ropeMaterial;

		// Use this for initialization
		void Start ()
		{
				///Setting up the references
				if (ropeMaterial == null) {
					ropeMaterial = new Material (Shader.Find ("Sprites/Default"));
				}

				if (rope1 == null) {
						rope1 = transform.Find ("Rope1").GetComponent<LineRenderer> ();
				}

				if (rope2 == null) {
						rope2 = transform.Find ("Rope2").GetComponent<LineRenderer> ();
				}

				if (bowTopPoint == null) {
						bowTopPoint = transform.parent.Find ("BowTopPoint");
				}

				if (bowBottomPoint == null) {
						bowBottomPoint = transform.parent.Find ("BowBottomPoint");
				}

				///Setting up ropes vertex count
				rope1.SetVertexCount (2);
				rope2.SetVertexCount (2);

				///Setting up ropes width
				rope1.SetWidth (width.x, width.y);
				rope2.SetWidth (width.x, width.y);
		        
				//Setting up material color
				ropeMaterial.color = color;

				///Setting up ropes material
				rope1.material = ropeMaterial;
				rope2.material = ropeMaterial;
		}
	
		void LateUpdate ()
		{
				//Draw the rope of the bow
				if (arrowEndPoint == null) {
						rope1.SetPosition (0, bowTopPoint.position);
						rope1.SetPosition (1, bowBottomPoint.position);
			
						rope2.SetPosition (0, Vector3.zero);
						rope2.SetPosition (1, Vector3.zero);
						return;
				}

				rope1.SetPosition (0, bowTopPoint.position);
				rope1.SetPosition (1, arrowEndPoint.position);

				rope2.SetPosition (0, arrowEndPoint.position);
				rope2.SetPosition (1, bowBottomPoint.position);
		}
}