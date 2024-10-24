using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[SerializeField] AudioSource musicSource;
	[SerializeField] AudioSource sfxSource;

	public AudioClip enemyHurt;
	public AudioClip enemyDead;
	public AudioClip enemyMoiMoiMoi;
	public AudioClip playerStep;
	public AudioClip playerHurt;
	public AudioClip playerDead;
	public AudioClip playerAttack;

	private void Start()
	{
	}

	public void PlaySFX(AudioClip clip, float volume)
	{
		sfxSource.PlayOneShot(clip, volume);
	}
	public IEnumerator PlaySFXWithDelay(AudioClip clip, float volume)
	{
		float randomDelay = Random.Range(0.1f, 10000f);
		yield return new WaitForSeconds(randomDelay);
		sfxSource.PlayOneShot(clip, volume);
	}
}
