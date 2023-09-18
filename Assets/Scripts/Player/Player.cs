using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rig2D;

    public Vector2 friction = new Vector2(.1f, 0);

    public float speed;

    public float speedRun;

    public float forceJump = 2;

    private float _currentSpeed;

    public bool _isRunning = false;


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
        }
    }


}
