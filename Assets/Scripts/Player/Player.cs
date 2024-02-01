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
    public SOFloat SOjumpAnimScaleY;
    public SOFloat SOjumpAnimScaleX;
    public SOFloat SOanimDuration; 

    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string boolRunning = "Running";
    public string boolJumping = "Jumping";
    public string triggerDeath = "Death";
    public Animator animator;
    public float turnPlayerDuration = .1f;

    [Header("Jump collision")]
    public Collider2D _collider2D;
    public float distanceToGround;
    public float distanceFromGround = .1f;
    public ParticleSystem jumpVFX;

    public AudioSource audio_test; 

    private void Awake() {
        if(healthBase != null) {
            healthBase.OnKill += OnPlayerKill;
        }

        if(_collider2D != null)
        {
            distanceToGround = _collider2D.bounds.extents.y;
        }
    }

    private bool isGround()
    {
        Debug.DrawRay(transform.position, -Vector2.up, Color.magenta, distanceToGround * distanceFromGround);
        return Physics2D.Raycast(transform.position, -Vector2.up, distanceToGround * distanceFromGround);
    }

  

    private void OnPlayerKill(){
        healthBase.OnKill -= OnPlayerKill;
        animator.SetTrigger(triggerDeath);
    }

    private void Update(){

        isGround();
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


        if(Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0 ){
            // move to left

             rig2D.velocity = new Vector2(-_currentSpeed, rig2D.velocity.y);

            if(rig2D.transform.localScale.x != -1){
                rig2D.transform.DOScaleX(-1, turnPlayerDuration);
            }

             animator.SetBool(boolRunning, true);

        }
        else if(Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        { //move to right

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
        if(Input.GetKey(KeyCode.Space) && isGround())
          {
            rig2D.velocity = Vector2.up * forceJump;
            rig2D.transform.localScale = Vector2.one;

            animator.SetBool(boolJumping, true);

            DOTween.Kill(rig2D.transform);

            //HandleScaleJump();
            PlayJumpVFX();
            _isJumping = true;
        }
        else{
            _isJumping = false;
            animator.SetBool(boolJumping, false);

        }
    }

    private void PlayJumpVFX()
    {
        if(jumpVFX != null) { jumpVFX.Play(); }
    }

    private void HandleScaleJump(){
        rig2D.transform.DOScaleY(SOjumpAnimScaleY.fValue, SOanimDuration.fValue).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        rig2D.transform.DOScaleX(SOjumpAnimScaleX.fValue, SOanimDuration.fValue).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
