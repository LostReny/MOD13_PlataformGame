using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
   public SOInt intDamage;

    public SOInt enemyLife;  

   [Header("Animations")] 
   public Animator anim;
   public string triggerAttack = "Attack";
   public string triggerDead = "Death";

   public float timeToDestroy = 1f;
   public HealthBase health;

    [Header("Sound")]
    public AudioSource enemyAudio;

   private void Awake() {
        if(health != null){
            health.OnKill += OnEnemyKill;
        }

        enemyLife.value = 5;
   }

   private void OnEnemyKill(){
        health.OnKill -= OnEnemyKill;
        DeadAnimation();
        enemyAudio.Play();
        //Destroy(gameObject, timeToDestroy);
        
        if (enemyLife.value == 0)
        {
            enemyLife.value = 5;
        }
        else return;
   }
   
   private void OnCollisionEnter2D(Collision2D collision) {

    // Debug.Log(collision.transform.name);

    var health = collision.gameObject.GetComponent<HealthBase>();

    if(health != null){
        health.TakeDamage(intDamage.value);
        AttackAnimation();
    }
   }

   private void AttackAnimation(){
        anim.SetTrigger(triggerAttack);
   }
   // não se usa a tag - usa uma variavel salva dentro da memória

    private void DeadAnimation(){
        anim.SetTrigger(triggerDead);
    }


    public void Damage(int amount){
        health.TakeDamage(amount);
    }
   
   }
