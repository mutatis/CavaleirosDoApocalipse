using UnityEngine;
using System.Collections;

public class AttackFlecha : MonoBehaviour 
{
	/*public float attackDistance = 16;
	private RaycastHit2D[] targets;
	private bool isAttacking = false;
	public int attack;
	*/

	public Vector2 final;
	public float mouseY;
	public Transform mira;
	public Transform mira2;
	public GameObject objMira;
	bool ok;
	public GameObject flecha;
	public static AttackFlecha attackF;
	float num;

	void Awake()
	{
		attackF = this;
	}
	
	void Update ()
	{
		final = (Vector2)transform.position + (Vector2)mira2.position;
		if(Input.GetMouseButton(0))
		{
		
			objMira.SetActive(true);

			mouseY = Input.GetAxis("Mouse Y")*2;

			mira.Rotate(0, 0, num);

			if(mira.eulerAngles.z > 1 && mira.eulerAngles.z < 90)
			{
				if(ok)
				{
					num = -1;
					//mira.eulerAngles = new Vector3(0, 0, mira.rotation.z + 1f);
				}
				else
				{
					num = 1;
					//mira.eulerAngles = new Vector3(0, 0, mira.rotation.z - 1f);
				}
			}
			else if(mira.eulerAngles.z < 1 && num == -1)
			{
				num = 0;
			}
			else if(mira.eulerAngles.z > 90 && num == 1)
			{
				num = 0;
			}
		}

		if(Input.GetMouseButtonUp(0))
		{
			Instantiate(flecha, transform.position, transform.rotation);
			StartCoroutine("GO");
		}

		if(mouseY > 0)
		{
			ok = true;
			//mira.eulerAngles = new Vector3(0, 0, mira.rotation.z + 1f);
		}
		else if(mouseY < 0)
		{
			ok = false;
			//mira.eulerAngles = new Vector3(0, 0, mira.rotation.z - 1f);
		}
	}

	IEnumerator GO()
	{
		yield return new WaitForSeconds(0.2f);
		mira.eulerAngles = new Vector3(0, 0, 3);
		objMira.SetActive(false);
	}
}