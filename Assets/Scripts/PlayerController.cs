using UnityEngine;
using System.Collections;
using System;

public class PlayerController : GameObjectController
{

    public float moveSpeed;
    public float jumpForce;
    public float score;
    public bool GodMode;

    private float curSpeed;
	private float initialSpeed;

    private Rigidbody2D rigidBody;
	private Animator animator;
    private ObstacleController[] obstacles;

    public bool groundTouching;
    public bool isDead;
    public LayerMask groundLayer;
    private Collider2D collider;

    public GameManager theGameManager;

    /// <summary>
	/// rigidBody is variable to get script of the Rigidbody2D
	/// collider is variable to get script of the Collider2D
	/// animator is variable to get script of the Animator
	/// isDead is variable set when die
	/// startPos is variable to get position of beginning
	/// </summary>
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
		animator = GetComponent<Animator>();
        obstacles = FindObjectsOfType<ObstacleController>();
        isDead = false;
        this.startPos = transform.position;
		this.initialSpeed = moveSpeed;
    }

    /// <summary>
	/// This method set when die then restart the game,
	/// and set when press space our character fly
	/// have the speed of character(movement), set the score,
	/// then character set to always run to the front.
	///</summary>
    void FixedUpdate()
    {
        if (isDead)
        {
            if (groundTouching)
            {
                Debug.Log("dead");
                theGameManager.RestartGame();
                FindObjectOfType<AudioController>().stop();
                GetComponent<AudioSource>().Play();
                return;
            }
        }
        else if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && transform.position.y < 13 && score>1f)
        {
            if (groundTouching)
            {
                jump();
            }
            else
            {
                fly();
            }
        }
        curSpeed = rigidBody.velocity.y;
        score = transform.position.x - startPos.x;
        score *= 2;
        if(score>100 && score%250<1)
        {
            moveSpeed *= 1.03f;
        }
        groundTouching = Physics2D.IsTouchingLayers(collider, groundLayer);
        animator.SetBool("isTouchingGround", groundTouching);
        animator.SetFloat("verticalSpeed", curSpeed);
        run();
    }

    /// <summary>
    /// Set the character to jump.
    /// </summary>
    private void jump()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
    }

    /// <summary>
    /// Move the character.
    /// </summary>
    private void run()
    {
        rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
    }

    /// <summary>
    /// Set the character to fly.
    /// </summary>
    private void fly()
    {
        rigidBody.AddForce(new Vector2(0, 8 * jumpForce));
    }

    /// <summary>
    /// Set the animation of character to die when touch the obstacles, 
    /// and we have the GodMode so didn't take this method.
    /// </summary>
    /// <param name="other">The variable input for other collider.</param>
    /// <returns>Delay the animation of die.</returns>
    IEnumerator OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(other.gameObject.name);
        if (GodMode) yield break;
        if (other.gameObject.tag == "killTag")
        {
            for (int i = 0; i < obstacles.Length; i++)
            {
                obstacles[i].GetComponent<Collider2D>().isTrigger = true;
            }
            animator.SetBool("isDead", true);
            yield return new WaitForSeconds(0.1f);
            //Debug.Log("hit");
            isDead = true;
            //collider.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Encapsulate the method of run so we can call this method enough for set the character to move.
    /// </summary>
    public override void move()
    {
        run();
    }

    /// <summary>
    /// Reset the position of all object and effect.
    /// </summary>
    public override void reset()
    {
        //collider.isTrigger = false;
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].GetComponent<Collider2D>().isTrigger = false;
        }
        isDead = false;
        transform.position = startPos;
        //collider.gameObject.SetActive(true);
        animator.SetBool("isDead", false);
		moveSpeed = this.initialSpeed;
    }

    /// <summary>
    /// Active the GodMode for invurnable to die when touch the obstacles.
    /// </summary>
    public void god()
    {
        GodMode = !GodMode;
    }
}
