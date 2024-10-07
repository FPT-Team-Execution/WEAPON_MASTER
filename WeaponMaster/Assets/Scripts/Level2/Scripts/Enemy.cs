using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D collider2D;
    public int maxHealth = 100;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //play animation for hurt

        if (currentHealth < 0) {
            Die();
        }
    }
    private void Die()
    {
        print("Enemy Die");
        //play animation for die

        //disable enemy
        enabled = false;
        collider2D.enabled = false  ;
    }
}
