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
	Vector2 dir;
	bool attack;
	bool roda = true;
	float mousex;
	float mousey;
	Vector3 mouseposition;

	void Awake()
	{
		attackF = this;
	}
	
	void Update ()
	{
		
		mouseY = Input.GetAxis("Mouse Y")*2;

		if(attack)
		{
			objMira.SetActive(true);
			final = (Vector2)transform.position + (Vector2)mira2.position;
			if(Input.GetMouseButton(0))
			{
				mousex = (Input.mousePosition.x);
				mousey = (Input.mousePosition.y);
				mouseposition = Camera.main.ScreenToWorldPoint(new Vector3 (mousex,mousey,0));
				dir = (Vector2)transform.position + new Vector2(4, mouseY);
				if(roda)
				{
					if(mouseposition.y < transform.position.y - 1)
					{
						mira.eulerAngles = new Vector3(0, 0, 35);
					}
					else if(mouseposition.y > transform.position.y + 1)
					{
						mira.eulerAngles = new Vector3(0, 0, -35);
					}
					else
					{
						mira.eulerAngles = new Vector3(0, 0, 0);
					}
					roda = false;
					//mira.eulerAngles = new Vector3(0, 0, dir.y);
					StartCoroutine("PA");
				}

				Debug.Log(mouseposition.y);
				if(roda == false)
				{
					if(mira.eulerAngles.z < 300 && mira.eulerAngles.z > 110 && mouseY < 0)
					{
						num = 0;
					}
					else if(mira.eulerAngles.z > 90 && mira.eulerAngles.z < 250 && mouseY > 0)
					{
						num = 0;
					}
					mira.Rotate(0, 0, num);

					/*if(mira.eulerAngles.z > 1 && mira.eulerAngles.z < 90)
					{*/
					if(mouseY != 0)
					{
						if(ok)
						{
							num = 4f;
							//mira.eulerAngles = new Vector3(0, 0, mira.rotation.z + 1f);
						}
						else
						{
							num = -4f;
							//mira.eulerAngles = new Vector3(0, 0, mira.rotation.z - 1f);
						}
					}
					else
					{
						num = 0;
					}
				}
				/*else if(mira.eulerAngles.z < 1 && num == -1)
				{
					num = 0;
				}
				else if(mira.eulerAngles.z > 90 && num == 1)
				{
					num = 0;
				}*/
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
	}

	public void Attack()
	{
		attack = true;
	}

	public void StopAttack()
	{
		Instantiate(flecha, new Vector2(transform.position.x, transform.position.y-2), transform.rotation);
		StartCoroutine("GO");
		attack = false;
	}

	IEnumerator PA()
	{
		yield return new WaitForSeconds(0.05f);
		objMira.SetActive(true);
		yield return new WaitForSeconds(0.05f);
		roda = false;
	}

	IEnumerator GO()
	{
		yield return new WaitForSeconds(0.2f);
		roda = true;
		//mira.eulerAngles = new Vector3(0, 0, 3);
		objMira.SetActive(false);
	}
}