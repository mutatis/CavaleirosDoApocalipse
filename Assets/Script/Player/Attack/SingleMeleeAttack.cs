using UnityEngine;
using System.Collections;
using System.Linq;

public class SingleMeleeAttack : MonoBehaviour
{
    public float attackDistance = 16;
    private RaycastHit2D[] targets;
    //private bool isAttacking = false;
	public int attack;

   	public void Attack ()
    {
		/*if(Input.GetKeyDown(KeyCode.Space))
		{*/
			if(attack != 0)
			{

			}
			//attack.SetTrigger ("Attack");
	        //isAttacking = true;
	        //yield return new WaitForSeconds(0.2f);
			targets = Physics2D.RaycastAll((Vector2)transform.position, Vector2.right, attackDistance, 1 << LayerMask.NameToLayer("Enemy"));
	        if (targets.Length == 0)
				targets = Physics2D.RaycastAll((Vector2)transform.position, Vector2.right, attackDistance, 1 << LayerMask.NameToLayer("Enemy"));
	        if (targets.Length == 0)
				targets = Physics2D.RaycastAll((Vector2)transform.position, Vector2.right, attackDistance,1 << LayerMask.NameToLayer("Enemy"));


	        Debug.DrawLine((Vector2)transform.position, (Vector2)transform.position + new Vector2(4, 0));
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
	        //isAttacking = false;
		//}
    }
}