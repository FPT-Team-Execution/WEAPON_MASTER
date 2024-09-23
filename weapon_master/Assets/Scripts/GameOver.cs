using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameOver : MonoBehaviour
{
    public static GameOver instance { get; private set; }
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverAudio;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        instance = this;
    }
 

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOverActive()
    {
        AudioManagement.instance.StopSound();
        gameOverScreen.SetActive(true);
        AudioManagement.instance.PlaySound(gameOverAudio);
    }
}
