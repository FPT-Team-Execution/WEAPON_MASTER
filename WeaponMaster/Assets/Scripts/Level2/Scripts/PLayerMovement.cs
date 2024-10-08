using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    private Rigidbody2D rb;
    Vector2 movement;
	private Animator anim;
	private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
    }

    private void Update()
    {
      ProcessInputs();

	}

	private void FixedUpdate()
	{
		Move();
	}
	private void ProcessInputs()
	{
		float moveX = Input.GetAxisRaw("Horizontal");
		if (moveX > 0.01f)
		{
			transform.localScale = new Vector3(0.7f, 0.7f, 1);
		}
		else if (moveX < -0.01f)
			transform.localScale = new Vector3(-0.7f, 0.7f, 1);
		float moveY = Input.GetAxisRaw("Vertical");
		//set animation 
		if (Mathf.Abs(moveX) >  0.01f || Mathf.Abs(moveY) > 0.01f)
			anim.SetInteger("AnimState", 1);
		else
		{
			anim.SetInteger("AnimState", 0);
		}
		movement = new Vector2 (moveX, moveY).normalized;
	}

	private void Move()
	{
		rb.velocity = new Vector2 (movement.x * speed, movement.y * speed);

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.tag == "NextLevel") {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}

	}

}