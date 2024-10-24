using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	private RectTransform bar;
	private Animator playerAnimator;
	private GameObject gameOverCanvas;
	private GameObject player;
	AudioManager audioManager;

	// Start is called before the first frame update
	void Start()
	{
		bar = GetComponent<RectTransform>();
		SetSize(Health.totalHealth);

		// Tìm đối tượng có tag "playerHealth" và lấy component HealthBar
		GameObject healthBarObject = GameObject.FindWithTag("PlayerHealth");
		audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

		// Tìm đối tượng Player bằng tag và lấy Animator
		player = GameObject.FindWithTag("Player");

		if (player != null)
		{
			playerAnimator = player.GetComponent<Animator>();
		}
		else
		{
			Debug.LogError("Không tìm thấy đối tượng Player với tag 'Player'");
		}

		gameOverCanvas = GameObject.FindWithTag("GameOver");
		gameOverCanvas.SetActive(false);

	}

	// Update is called once per frame
	void Update()
	{
	}

	public void Damage(float damage)
	{
		if ((Health.totalHealth -= damage) >= 0f)
		{
			audioManager.PlaySFX(audioManager.playerHurt, 0.5f);
			playerAnimator.SetTrigger("Hurt");
			Health.totalHealth -= damage;
		}
		else
		{
			Health.totalHealth = 0f;
		}

		SetSize(Health.totalHealth);

		if (Health.totalHealth <= 0.5f)
		{
			var bar = GetComponent<Image>();
			bar.color = Color.red;
		}

		if (Health.totalHealth <= 0 && Health.isDeath == false)
		{
			Health.isDeath = true;
			audioManager.PlaySFX(audioManager.playerDead, 1f);
			playerAnimator.SetTrigger("Death");
			gameOverCanvas.SetActive(true);
			
		}
	}

	public void SetSize(float size)
	{
		bar.localScale = new Vector3(size, 1f);
	}
}
