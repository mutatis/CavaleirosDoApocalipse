using UnityEngine;
using System.Collections;

public class AttackMorte : MonoBehaviour {
    Transform parent;
    bool canThrow = true;
    Vector3 direction;
    Vector3 target;
    Vector3 origin;
    Vector3 localOrigin;
    public float distanceFromTarget;
    public float range;
    public float speed;
    public float minDistanceToReturn;
    public bool returning = false;

	// Use this for initialization
	void Start () {
        localOrigin = transform.localPosition;
        origin = transform.position - transform.parent.transform.position;
        parent = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
        target = parent.position + origin + (direction * range);
        print(target);
        if(!canThrow)
        {
            
            
            if (!returning)
            {
                distanceFromTarget = (target - transform.position).magnitude;
                transform.Translate((target - transform.position).normalized * speed * Time.deltaTime + PlayerMovement.playerMovement.speed * Vector3.right * Time.deltaTime);
                if (distanceFromTarget <= minDistanceToReturn)
                {
                    returning = true;
                    transform.parent = parent;
                }
            }
            else
            {
                distanceFromTarget = ((parent.position + origin) - transform.position).magnitude;
                transform.Translate(((parent.position + origin) - transform.position).normalized * speed * Time.deltaTime);
                if (distanceFromTarget <= minDistanceToReturn)
                {
                    canThrow = true;
                    returning = false;
                }
            }
        }
        else
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, localOrigin, Time.deltaTime * 15);
        }
	}

    public void Attack()
    {
        print("art" + Time.time.ToString());
        if (canThrow)
        {
            direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            print(direction);
            
            canThrow = false;
            transform.parent = null;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(target, Vector3.one);
    }
}
