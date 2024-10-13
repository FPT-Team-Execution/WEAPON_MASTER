using System.Collections;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask playerLayer;
    private Transform player;
    private Animator animator;
    private bool isDead = false;
    private bool isAttacking = false;
    [SerializeField] private float stopDistance = 1.5f;
    [SerializeField] private float attackCooldown = 2f;
    private float cooldownTimer = Mathf.Infinity;
    public HealthBar healthBar;
    public float damage = 0.02f;
    [SerializeField] private int maxHealth;
    private int currentHealth;


    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        GameObject healthBarObject = GameObject.FindWithTag("PlayerHealth");
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
        cooldownTimer += Time.deltaTime;

        if (!isDead && Health.isDeath == false)
        {
            MoveTowardsPlayer();
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isDead)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();

            }
        }
    }

    private void MoveTowardsPlayer()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer > stopDistance && !isAttacking)
            {
                animator.SetBool("moving", true);
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

                if (transform.position.x < player.position.x)
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                else
                    transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (distanceToPlayer <= stopDistance && cooldownTimer >= attackCooldown)
            {
                AttackPlayer();
            }
            else
            {
                animator.SetBool("moving", false);
            }
        }
    }

    private void AttackPlayer()
    {
        if (!isAttacking && cooldownTimer >= attackCooldown)
        {
            isAttacking = true;
            cooldownTimer = 0;
            animator.SetTrigger("attacking");


            StartCoroutine(CheckHitPlayer());
        }
    }

    private IEnumerator CheckHitPlayer()
    {
        yield return new WaitForSeconds(1.6f);

        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D hit in hitPlayers)
        {
            print("We hit " + hit.name);
        }

        isAttacking = false;
        animator.SetBool("moving", false);
    }

    public void Die()
    {
        isDead = true;
        animator.SetTrigger("ding");
    }

    private void SetTrigger()
    {
        animator.SetTrigger("standing");
        cooldownTimer = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }

    private void DamagePlayer()
    {
        healthBar.Damage(damage);
    }

    private void SetDisable()
    {
        BossMovement bossMovement = GetComponent<BossMovement>();
        bossMovement.enabled = false;
    }
}
