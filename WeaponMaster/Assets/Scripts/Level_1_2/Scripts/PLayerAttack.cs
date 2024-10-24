﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

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
		private int attackDamage = 50;

		private Queue<string> attackTriggers = new Queue<string>(new[] { "Attack1", "Attack2", "Attack3" });

		AudioManager audioManager;

		private void Awake()
		{
			anim = GetComponent<Animator>();
			audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
		}
		private void Update()
		{
			if (Input.GetMouseButton(0) && coolDownTime > attackCoolDown && !Health.isDeath)
			{

				Attack();
				coolDownTime = 0;

			}
			coolDownTime += Time.deltaTime;
		}

        private void Attack()
        {
            anim.SetTrigger(attachTrigger());
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
			audioManager.PlaySFX(audioManager.playerAttack, 1f);
            // Damage them
            foreach (Collider2D enemy in hitEnemies)
            {
                BossMovement boss = enemy.GetComponent<BossMovement>();
                if (boss != null)
                {
                    boss.TakeDamage(attackDamage);
                }
                else
                {
                    var targetEnemy = enemy.GetComponent<Enemy>();
                    if (targetEnemy != null)
                    {
                        targetEnemy.TakeDamage(attackDamage);
                    }
                }
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
