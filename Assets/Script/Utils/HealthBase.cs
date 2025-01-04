using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public float StartLife = 10;
    public float _currentLife;

    private bool _isDead = false;
    public bool destroyOnKill = false;
    public float delayToKill = 0f;

    private void Awake()
    {
       Init();
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = StartLife;
    }

    public void Damage(int damage)
    {
        if(_isDead == true) return;

        _currentLife -=damage;

        if(_currentLife <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
      _isDead = true;

      if(destroyOnKill == true)
      {
        Destroy(gameObject, delayToKill);
      }
    }
}
