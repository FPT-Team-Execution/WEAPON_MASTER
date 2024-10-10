using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	private Animator animator;
	private BoxCollider2D enemyCollider;
	public int maxHealth = 100;
	public int currentHealth;
	public bool isDead = false;

	public BoxCollider2D sensorCollider;
	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		animator = GetComponent<Animator>();
		enemyCollider = GetComponent<BoxCollider2D>();
	}

	// Update is called once per frame
	void Update()
	{
		enemyCollider = GetComponent<BoxCollider2D>();
	}



	public void TakeDamage(int damage)
	{

		//play animation for hurt
		if (currentHealth <= 0)
		{
			isDead = true;
			Die();
		}
		else
		{
			currentHealth -= damage;
			animator.SetTrigger("Hurt");
		}
	}
	private void Die()
	{
		//play animation for die
		animator.SetTrigger("Death");
		//disable enemy
		//enabled = false;
		enemyCollider.enabled = false;
		//GetComponent<SpriteRenderer>().enabled = false;
	}
}
