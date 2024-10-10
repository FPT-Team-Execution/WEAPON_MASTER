using Assets.Scripts.Level2.Scripts;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] private float speed = 3f; // Speed of the enemy
	private Transform player; // Reference to the player's transform
	private Enemy enemy;
	private EnemyAttack enemyAttack;
	private Animator Animator;
	void Start()
	{
		player = GameObject.FindWithTag("Player").transform;
		enemy = GetComponent<Enemy>();
		enemyAttack = GetComponent<EnemyAttack>();
		Animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Health.isDeath == false)
		{
			MoveTowardsPlayer();
		}
	}

	// Function to move the enemy towards the player
	private void MoveTowardsPlayer()
	{
		if (player != null && !enemy.isDead && !enemyAttack.playerInRange)
		{
			Animator.SetInteger("AnimState", 2);
			transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
			if (transform.position.x < player.position.x)
			{
				transform.localScale = new Vector3(-0.7f, 0.7f, 1);
			}
			else
			{
				transform.localScale = new Vector3(0.7f, 0.7f, 1);
			}
		}
	}
}
