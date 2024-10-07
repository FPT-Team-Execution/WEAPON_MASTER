using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Level2.Scripts
{
	public class EnemyAttack : MonoBehaviour
	{
		[SerializeField] private Transform attackPoint;
		[SerializeField] private float attackRange = 0.5f;
		[SerializeField] private LayerMask player;

		private Animator anim;
		private float coolDownTime = 0f;
		private float attackCoolDown = 0.8f;
		public bool playerInRange = false;  // Track if player is in the trigger



		private void Awake()
		{
			anim = GetComponent<Animator>();
		}

		private void Update()
		{
			// Increment the cooldown time over time
			coolDownTime += Time.deltaTime;

			// Automatically attack if the player is in range and cooldown is over
			if (playerInRange && coolDownTime > attackCoolDown)
			{
				Attack();
				coolDownTime = 0;
			}
		}

		private void Attack()
		{
			// Play attack animation
			anim.SetTrigger("EAttack");
			StartCoroutine(CheckOverlapAfterDelay(1.6f));
		}

		// Coroutine to check for player overlap after a delay
		private IEnumerator CheckOverlapAfterDelay(float delay)
		{
			// Wait for the specified delay
			yield return new WaitForSeconds(delay);

			// Track hit player after the delay
			Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, player);

			// Damage them
			foreach (Collider2D enemy in hitPlayers)
			{
				print("we hit " + enemy.name);
				// Apply damage to the player or any other logic
			}
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.tag == "Player")
			{
				playerInRange = true; 
			}
		}


		private void OnTriggerExit2D(Collider2D collision)
		{
			if (collision.tag == "Player")
			{
				playerInRange = false;  
			}
		}
	}
}
