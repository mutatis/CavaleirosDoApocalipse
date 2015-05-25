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

    private float heightOnLaunch;

	// Use this for initialization
	void Start () {
        localOrigin = transform.localPosition;
        origin = transform.position - transform.parent.position;
        parent = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 correctedOriginPoint = new Vector3(parent.position.x, heightOnLaunch, parent.position.y);
        target = correctedOriginPoint + origin + (direction * range);
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
        if (canThrow)
        {
            direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            print(direction);
            
            canThrow = false;
            transform.parent = null;
            heightOnLaunch = parent.position.y;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(target, Vector3.one);
    }
}
