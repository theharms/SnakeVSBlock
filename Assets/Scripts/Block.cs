using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    public TextMeshProUGUI ValueBlockText;
    public int ValueBlock;
    public SnakeTail SnakeTail;
    Color lerpedColor = Color.white;

    public ParticleSystem ParticleSystem;
 
    
    void Start()
    {
        
        ValueBlockText.text = ValueBlock.ToString();
        
        lerpedColor = Color.Lerp(Color.white, Color.gray, (float)ValueBlock / 10f);
        this.GetComponent<Renderer>().material.color = lerpedColor;
        
    }

     public void RecivedDamage()
    {
        ValueBlock -= SnakeTail.Health;
        ValueBlockText.text = ValueBlock.ToString();
        if (ValueBlock <= 0)
        {
            
            ParticleSystem.Play();
            
        }
    }

    public void DestroyBlock()
    {

      
        
    
    }
}
