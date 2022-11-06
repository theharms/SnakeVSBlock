using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip Food;
    public AudioClip Explosion;
    public AudioClip Finish;
    public AudioClip GameOver;

    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

     public void ExplosionSound()
    {
        _audio.PlayOneShot(Explosion);
    }

    public void TakeFood()
    {
        _audio.PlayOneShot(Food);
    }

    public void RichFinish()
    {
        _audio.PlayOneShot(Finish);
    }

    public void GameOverSound()
    {
        _audio.PlayOneShot(GameOver);
    }

}
