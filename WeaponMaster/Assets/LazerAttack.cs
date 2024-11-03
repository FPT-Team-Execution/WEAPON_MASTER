using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerAttack : MonoBehaviour
{
    private HealthBar healthBar;
    [SerializeField] private float damege;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        GameObject healthBarObject = GameObject.FindWithTag("PlayerHealth");
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        if (healthBarObject != null)
        {
            healthBar = healthBarObject.GetComponent<HealthBar>();
        }
    }


    private void Deactive()
    {
        boxCollider.size = new Vector2(0.0001f, boxCollider.size.y);
        gameObject.SetActive(false);

    }

    private void setSizeBoxCollider()
    {
        boxCollider.size = new Vector2(2.5f, boxCollider.size.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            healthBar.Damage(damege);
        }
    }


}
