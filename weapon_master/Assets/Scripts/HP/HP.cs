using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] private float playerHP;
    [SerializeField] private Transform player;
    [SerializeField] private float pushBackDistance;
    //[SerializeField] private Transform pushBackPoint;
    private BoxCollider2D playerCollider;

    private Animator anim;
    public float currentHP {  get; private set; }
    private bool dead = false;
    // Start is called before the first frame update
    void Awake()
    {
        currentHP = playerHP;
        anim = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    TakeDamage();
        //}
    }

    public void TakeDamage(float damage = 1)
    {
        //make sure returned min value is 0
        currentHP = Mathf.Clamp(currentHP - damage / 10, 0, playerHP);
        //take damage
        if (currentHP > 0)
        {
            anim.SetTrigger("hurt");
            //move player forward a litle bit
            player.position =  new Vector3(transform.position.x - pushBackDistance, transform.position.y, transform.position.z);

        }
        //game over
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                //GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                //game over execution
                playerCollider.enabled = false;
                GameOver.instance.GameOverActive();
            }
        
        }
        currentHP -= damage;
    }
}
