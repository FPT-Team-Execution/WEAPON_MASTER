using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsHit : MonoBehaviour
{
    [SerializeField] private int destroyReachNum;
    private int hitCount = 0;
    [SerializeField] private GameObject trap;
    [SerializeField]private HP hp;

    private void Awake()
    {
        //hp = GetComponent<HP>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print( collision.tag);

        if (collision.tag == "Weapon")
        {
            hitCount++;
            if (destroyReachNum == hitCount)
                trap.SetActive(false);
        }
 
        if (collision.tag == "Player")
        {
            print("Player take dame");
            hp.TakeDamage();
        }
    }

   
}
