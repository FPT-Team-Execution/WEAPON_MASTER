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
	public Collider2D boudary;

	public BoxCollider2D sensorCollider;

	AudioManager audioManager;
	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		animator = GetComponent<Animator>();
		enemyCollider = GetComponent<BoxCollider2D>();
		audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
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
			audioManager.PlaySFX(audioManager.enemyHurt, 1f);
			Die();
		}
		else
		{
			audioManager.PlaySFX(audioManager.enemyHurt, 1f);
			currentHealth -= damage;
			animator.SetTrigger("Hurt");
		}
	}
	private void Die()
	{
		audioManager.PlaySFX(audioManager.enemyDead, 1f);
		//play animation for die
		animator.SetTrigger("Death");
		//disable enemy
		//enabled = false;
		enemyCollider.enabled = false;
		//GetComponent<SpriteRenderer>().enabled = false;
		isDead = true;
		boudary.isTrigger = true;
	}
}
