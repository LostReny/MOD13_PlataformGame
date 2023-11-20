using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using TMPro;

public class HealthBase : Singleton<HealthBase>
{
  public Action OnKill;

  public SOInt life;


 // public int startLife = 10;

  public bool _destroyOnTermination = false;

  public int _currentLife;

  private bool _isDead = false;

  [SerializeField] private FlashColor _flashColor;

  public float delayTokill;

    public void Awake(){
    Init();
    if(_flashColor == null){
        _flashColor = GetComponent<FlashColor>(); 
    }
    ResetLife();
  }
  
  public void Init(){
    _isDead = false;

        if (life != null)
        {
            _currentLife = life.value;
        }
        else return;
    }


    public void ResetLife()
    {
        life.value = 20;
    }

  public void TakeDamage(int intDamage){

    if(_isDead) return;

        _currentLife = life.value -= intDamage;

         Debug.Log(_currentLife.ToString());
       

        if (_currentLife <= 0){
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

    protected virtual void OnDamaged() { }

}
 
