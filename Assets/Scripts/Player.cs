using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public SnakeTail SnakeTail;
    public Food Food;
    public Block Block;
    public int Length = 1;
    private int value;
    public Controls controls;
    public GameObject GameOverPanel;
    public GameObject FinishPanel;
    public TextMeshProUGUI ScoreText;
    public static int Score = 0;
    public ParticleSystem ParticleSystem;
    public ParticleSystem ParticleBlock;
    private AudioSource _levelUp;
    public AudioManager AudioManager;

    private void Awake()
    {
        _levelUp = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        ScoreText.text = Score.ToString();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            value = collision.gameObject.GetComponent<Food>().Value;
            SnakeTail.Health += value;
            SnakeTail.HealthText.text = SnakeTail.Health.ToString();
            ParticleSystem.Play();
            AudioManager.TakeFood();
            for (int i = 0; i < value; i++)
            {
                Length++;
                SnakeTail.AddCircle();
            }
            Destroy(collision.gameObject);
        }

       else if (collision.gameObject.tag == "Block")
       {
            
            
            value = collision.gameObject.GetComponent<Block>().ValueBlock;

            if (value >= SnakeTail.Health)
            {
                PlayerDied();
            }
            else
            {
                SnakeTail.Health -= value;
                SnakeTail.HealthText.text = SnakeTail.Health.ToString();
                

                for (int i = 0; i < value; i++)
               {
                  Score++;
                  //ScoreText.text = Score.ToString();
                  Length--;
                  SnakeTail.RemoveCircle();
                }

                AudioManager.ExplosionSound();
                Destroy(collision.gameObject);
               
                
            }                

        } 

        else if (collision.gameObject.tag == "Finish")
        {
            controls.enabled = false;
            FinishPanel.SetActive(true);
            AudioManager.RichFinish();
            Debug.Log("Finish");
        }

    }

    public void PlayerDied()
    {

        controls.enabled = false;
        GameOverPanel.SetActive(true);
        AudioManager.GameOverSound();
        Score = 0;
        

        Debug.Log("Game Over!"); 
        
        
    }



}
