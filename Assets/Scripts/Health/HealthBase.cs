using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
  public int startLife = 10;

  public bool _destroyOnTermination = false;

  private float _currentLife;

  private bool _isDead = false;

  public float delayTokill;

  public void Awake(){
    Init();
  }

  
  private void Init(){
    _isDead = false;
    _currentLife = startLife;
  }



  public void TakeDamage(int damage){

    if(_isDead) return;

    _currentLife -= damage;

    if(_currentLife <= 0){
      Die();
    }
  }

  private void Die(){
    _isDead = true;

    if(_destroyOnTermination){
      Destroy(gameObject, delayTokill);
    }
  }

}
 
