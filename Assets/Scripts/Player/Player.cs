using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Player")]
    public Rigidbody2D rig2D;
    public Vector2 friction = new Vector2(.1f, 0);
    public bool _isOnFlorr = false;

    public bool _isJumping = false;

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

    public float setDownAnim = 0.5f;

    private void Update(){
        
        HandleJump();
        HandleMove();

    }

    private void HandleMove(){

        //chegar velocidade que está usando
        if(Input.GetKey(KeyCode.LeftShift)){
            _currentSpeed = speedRun;
        }
        else {
            _currentSpeed = speed;
        }

        _isRunning = (Input.GetKey(KeyCode.LeftShift));


        if(Input.GetKey(KeyCode.LeftArrow)){

             rig2D.velocity = new Vector2(-_currentSpeed, rig2D.velocity.y);
        }
        else if(Input.GetKey(KeyCode.RightArrow)){

            rig2D.velocity = new Vector2(_currentSpeed, rig2D.velocity.y);

        }

        if(rig2D.velocity.x >0){
            rig2D.velocity -= friction;
        }
        else if(rig2D.velocity.x < 0){
            rig2D.velocity += friction;
        }
    }

    private void HandleJump(){
        if(Input.GetKeyDown(KeyCode.Space)){
            rig2D.velocity = Vector2.up * forceJump;
            rig2D.transform.localScale = Vector2.one;

            DOTween.Kill(rig2D.transform);

            HandleScaleJump();
            _isJumping = true;
        }
        else{
            _isJumping = false;
        }
    }

    // quando o player colidir com o chão depois de pular - deve animar para baixo
    // como fazer isso ??
    // necessário para a próxima etapa 
    // ARRUMAR ESSA PARTE DO CÓDIGO
    /*private void HandleScaleArrive(){
        if(GameObject.FindWithTag("Florr")){
            _isOnFlorr = true;
            rig2D.transform.DOScaleY(setDownAnim, animDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        } else _isOnFlorr = false;          

    }*/

    private void HandleScaleArrive(){
    // Verifica se o objeto colidiu com o chão
    GameObject floorObject = GameObject.FindGameObjectWithTag("Florr");
    if (floorObject != null){
        // Se colidiu com o chão
        _isOnFlorr = true;
        _isJumping = false;
        rig2D.transform.DOScaleY(setDownAnim, animDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
    else{
        _isOnFlorr = false;
        _isJumping = true;

    }
}



    private void HandleScaleJump(){
        rig2D.transform.DOScaleY(jumpAnimScaleY, animDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        rig2D.transform.DOScaleX(jumpAnimScaleX, animDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
