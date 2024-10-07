using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Level2.Scripts
{
	public class PlayerAttack : MonoBehaviour
	{
		[SerializeField] private Transform attackPoint;
		[SerializeField] private float attackRange = 0.5f;
		[SerializeField] private LayerMask enemyLayers;

		private Animator anim;
		private float coolDownTime = 0f;
		private float attackCoolDown = 0.5f;

		private Queue<string> attackTriggers = new Queue<string>(new[] { "Attack1", "Attack2", "Attack3" });
	
		private void Awake()
		{
			anim = GetComponent<Animator>();
		}
		private void Update()
		{
			if (Input.GetMouseButton(0) && coolDownTime > attackCoolDown)
			{
				
				Attack();
				coolDownTime = 0;

			}
			coolDownTime += Time.deltaTime;
		}



		private void Attack()
		{
			//play attack animation
			anim.SetTrigger(attachTrigger());

			//Detect enemies in range of attack
			Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
			//Damage them
			foreach(Collider2D enemy in hitEnemies)
			{
				print("we hit" + enemy.name);
			}
		}

		/// <summary>
		/// method in Unity that is used to draw gizmos only when an object is selected in the scene view.
		/// </summary>
		private void OnDrawGizmosSelected()
		{
			if (attackPoint == null)
				return;
			Gizmos.DrawWireSphere(attackPoint.position, attackRange);
		}

		private String attachTrigger()
		{
			var attackTrigger = attackTriggers.Dequeue();
			attackTriggers.Enqueue(attackTrigger);
			return attackTrigger;
		}
	}
}
