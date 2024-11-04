using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] public float speed = 3;
	private Rigidbody2D rb;
	Vector2 movement;
	private Animator anim;
	AudioManager audioManager;
    public HealthBar healthBar;

    private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
        GameObject healthBarObject = GameObject.FindWithTag("PlayerHealth");
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        if (healthBarObject != null)
        {
            healthBar = healthBarObject.GetComponent<HealthBar>();
        }
        else
        {
            Debug.LogError("Không tìm thấy đối tượng với tag 'playerHealth'");
        }
    }

	private void Update()
	{
		if (Health.isDeath == false)
		{
			ProcessInputs();
		}
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
		if (Mathf.Abs(moveX) > 0.01f || Mathf.Abs(moveY) > 0.01f)
			anim.SetInteger("AnimState", 1);
		else
		{
			anim.SetInteger("AnimState", 0);
		}
		movement = new Vector2(moveX, moveY).normalized;
	}

	private void Move()
	{
		if (!Health.isDeath)
		{
			rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
		}
		else
		{
			rb.velocity = new Vector2(movement.x * 0, movement.y * 0);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.tag == "NextLevel")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		if (collision.tag == "healthBoost")
		{
			if (Health.totalHealth < 1)
			{
				Health.totalHealth += 0.2f;
				if (Health.totalHealth > 1)
				{
					Health.totalHealth = 1;
				}
				healthBar.SetSize(Health.totalHealth);
			}

		}

    }

}