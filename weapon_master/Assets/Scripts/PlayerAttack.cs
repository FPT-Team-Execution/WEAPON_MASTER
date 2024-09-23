using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform weaponPoint;
    
    [SerializeField] private List<GameObject> weapons;

    private float cooldownTimer = Mathf.Infinity; //1

    private Animator anim;
    private PlayerMovement PlayerMovement;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        PlayerMovement = GetComponent<PlayerMovement>();
    
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && PlayerMovement.canAttack())
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        weapons[WeaponThrow()].transform.position = weaponPoint.position;
        //set the direction of player to weapon direction
        weapons[WeaponThrow()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int WeaponThrow()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (!weapons[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
