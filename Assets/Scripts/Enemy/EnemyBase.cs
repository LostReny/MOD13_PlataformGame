using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
   public int damage = 10;

   [Header("Animations")] 
   public Animator anim;
   public string triggerAttack = "Attack";

   public HealthBase health;
   
   private void OnCollisionEnter2D(Collision2D collision) {

    Debug.Log(collision.transform.name);

    var health = collision.gameObject.GetComponent<HealthBase>();

    if(health != null){
        health.TakeDamage(damage);
        AttackAnimation();
    }
   }

   private void AttackAnimation(){
        anim.SetTrigger(triggerAttack);
   }
   // não se usa a tag - usa uma variavel salva dentro da memória

    public void Damage(int amount){
        health.TakeDamage(amount);
    }
   
   }
