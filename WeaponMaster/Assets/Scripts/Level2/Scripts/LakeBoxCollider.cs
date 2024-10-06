using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeBoxCollider : MonoBehaviour
{
    [SerializeField]private float slowDownSpeed;
	[SerializeField]private PlayerMovement PlayerMovement;

	private float oldSpeed = 0f;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		var isHitPLayer = collision.tag == "Player";
		if (isHitPLayer)
		{
			oldSpeed = PlayerMovement.speed;
			PlayerMovement.speed -= slowDownSpeed;
			if(PlayerMovement.speed < 0)
				PlayerMovement.speed = 2;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		PlayerMovement.speed = oldSpeed;
	}
}
