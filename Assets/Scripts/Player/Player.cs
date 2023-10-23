using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Player")]
    public Rigidbody2D rig2D;
    public HealthBase healthBase;
    public Vector2 friction = new Vector2(.1f, 0);
    public bool _isOnFlorr = false;

    public bool _isJumping = false;

    public GameObject floorObject;

    [Header("SpeedSetup")]
    public float speed;
    public float speedRun;
    public float forceJump = 2;
    private float _currentSpeed;
    public bool _isRunning = false;

    [Header("AnimationSetup")]
    public float jumpAnimScaleY = 1.5f;
    public float jumpAnimScaleX = 1.5f;

    public float animDuration = .3f;
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string boolRunning = "Running";
    public string boolJumping = "Jumping";
    public string triggerDeath = "Death";
    public Animator animator;
    public float turnPlayerDuration = .1f;

    private void Awake() {
        if(healthBase != null) {
            healthBase.OnKill += OnPlayerKill;
        }
    }

    private void OnPlayerKill(){
        healthBase.OnKill -= OnPlayerKill;
        animator.SetTrigger(triggerDeath);
    }

    private void Update(){
        
        HandleJump();
        HandleMove();

    }

    private void HandleMove(){

        //chegar velocidade que está usando
        if(Input.GetKey(KeyCode.LeftShift)){
            _currentSpeed = speedRun;
            animator.speed = 1.5f;
        }
        else {
            _currentSpeed = speed;
            animator.speed = 1f;
        }

        _isRunning = (Input.GetKey(KeyCode.LeftShift));


        if(Input.GetKey(KeyCode.A)){

             rig2D.velocity = new Vector2(-_currentSpeed, rig2D.velocity.y);

            if(rig2D.transform.localScale.x != -1){
                rig2D.transform.DOScaleX(-1, turnPlayerDuration);
            }

             animator.SetBool(boolRunning, true);

        }
        else if(Input.GetKey(KeyCode.D)){

            rig2D.velocity = new Vector2(_currentSpeed, rig2D.velocity.y);

            if(rig2D.transform.localScale.x != 1){
                rig2D.transform.DOScaleX(1, turnPlayerDuration);
            }

             animator.SetBool(boolRunning, true);

        }
        else{
            animator.SetBool(boolRunning, false);
        }

        if(rig2D.velocity.x >0){
            rig2D.velocity -= friction;
        }
        else if(rig2D.velocity.x < 0){
            rig2D.velocity += friction;
        }
    }

    private void HandleJump(){
        if(Input.GetKey(KeyCode.Space)){
            rig2D.velocity = Vector2.up * forceJump;
            rig2D.transform.localScale = Vector2.one;

            animator.SetBool(boolJumping, true);

            DOTween.Kill(rig2D.transform);
            
            //HandleScaleJump();
            _isJumping = true;
        }
        else{
            _isJumping = false;
            animator.SetBool(boolJumping, false);

        }
    }

    private void HandleScaleJump(){
        rig2D.transform.DOScaleY(jumpAnimScaleY, animDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        rig2D.transform.DOScaleX(jumpAnimScaleX, animDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
