using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particleSystem;

    private void Awake()
    {
        if(particleSystem != null) 
        {
            particleSystem.transform.SetParent(null);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag(compareTag)) 
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
       gameObject.SetActive(false);
       OnCollect();
    }
    
    protected virtual void OnCollect()
    {
       if(particleSystem != null) 
       {
          particleSystem.Play();
       }
    }

   
}
