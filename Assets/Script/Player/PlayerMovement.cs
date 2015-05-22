using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement playerMovement;

    //Parâmetros
    public float jumpForce;
    public float speed;
    public float speedIncreasePoint;
    public float newSpeedMultiplier;
    public bool canDoubleJump;

    //internal status
    [HideInInspector]
    public bool canJump = true;
    float soma;
    bool hasDoubleJumped;

    //Componentes
    Animator myAnimator;
    BoxCollider2D myBoxCollider;

    void Awake()
    {
        playerMovement = this;
    }

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        soma = speedIncreasePoint + transform.position.x;
    }

    void Update()
    {
        //Set animation
        if (canJump == true)
        {
            myAnimator.SetTrigger("Run");
        }
        else
        {
            myAnimator.SetTrigger("Jump");
        }

        //Set speed if above speed increase point
        if (soma < transform.position.x)
        {
            speed *= newSpeedMultiplier;
            soma = speedIncreasePoint + transform.position.x;
        }

        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    public void Jump()
    {
        if (canJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }
        else if (canDoubleJump && !hasDoubleJumped)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            hasDoubleJumped = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
		{
			canJump = true;
            hasDoubleJumped = false;
		}
    }
}
