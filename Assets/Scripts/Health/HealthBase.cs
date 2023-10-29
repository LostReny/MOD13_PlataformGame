using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class HealthBase : Singleton<HealthBase>
{
  public Action OnKill;

  public SOInt life; 

 // public int startLife = 10;

  public bool _destroyOnTermination = false;

  [SerializeField] private float _currentLife;

  private bool _isDead = false;

  [SerializeField] private FlashColor _flashColor;

  public float delayTokill;

  public void Awake(){
    Init();
    if(_flashColor == null){
        _flashColor = GetComponent<FlashColor>(); 
    }
  }

  
  private void Init(){
    _isDead = false;
    _currentLife = life.value;
  }

  public void TakeDamage(int intDamage){

    if(_isDead) return;

    _currentLife -= intDamage;
     Debug.Log(_currentLife);

    if(_currentLife <= 0){
      Die();
    }

    if(_flashColor != null){
      _flashColor.Flash();
    }
  
    }

    private void Die(){
    _isDead = true;

    if(_destroyOnTermination){
      Destroy(gameObject, delayTokill);
    }

    OnKill?.Invoke();

  }

}
 
