using UnityEngine;
using System.Collections;

public class AttackFlecha : MonoBehaviour 
{
	public float attackDistance = 16;
	private RaycastHit2D[] targets;
	private bool isAttacking = false;
	public int attack;
	public float mouseY;
	public static AttackFlecha attackF;
	public Vector2 final;

	void Awake()
	{
		attackF = this;
	}
	
	void Update ()
	{
		if(mouseY == 0)
		{
			mouseY = Input.GetAxis("Mouse Y");
		}
		if(Input.GetMouseButtonUp(0))
		{
			Debug.DrawLine((Vector2)transform.position, (Vector2)transform.position + new Vector2(4, mouseY));
			if(attack != 0)
			{
				
			}
			//attack.SetTrigger ("Attack");
			isAttacking = true;
			//yield return new WaitForSeconds(0.2f);
			targets = Physics2D.RaycastAll((Vector2)transform.position + new Vector2(0, mouseY), Vector2.right, attackDistance, 1 << LayerMask.NameToLayer("Enemy"));
			if (targets.Length == 0)
				targets = Physics2D.RaycastAll((Vector2)transform.position + new Vector2(0, mouseY), Vector2.right, attackDistance, 1 << LayerMask.NameToLayer("Enemy"));
			if (targets.Length == 0)
				targets = Physics2D.RaycastAll((Vector2)transform.position + new Vector2(0, mouseY), Vector2.right, attackDistance,1 << LayerMask.NameToLayer("Enemy"));
			
			final = (Vector2)transform.position + new Vector2(10, mouseY);
			Debug.DrawLine((Vector2)transform.position, (Vector2)transform.position + new Vector2(4, mouseY));
			// Debug.DrawLine((Vector2)transform.position + new Vector2(0, 2), (Vector2)transform.position + new Vector2(18, 2));
			audio.Play();
			//Debug.DrawLine((Vector2)transform.position, (Vector2)transform.position + new Vector2(15, 3));
			if(attack == 0)
			{
				for (int i = 0; i < targets.Length; i++)
				{
					Destroy(targets[i].collider.gameObject);
				}
			}
			else
			{
				for (int i = 0; i < targets.Length; i++)
				{
					Destroy(targets[i].collider.gameObject);
				}
			}
			isAttacking = false;
			mouseY = 0;
		}
	}
}