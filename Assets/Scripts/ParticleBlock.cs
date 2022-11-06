using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBlock : MonoBehaviour
{

    public ParticleSystem ParticleSystem;

   private void OnTriggerEnter(Collider collider)
    {
        ParticleSystem.Play();
        
        
    }

}
