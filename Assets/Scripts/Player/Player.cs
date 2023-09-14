using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rig2D;

    public Vector2 friction = new Vector2(.1f, 0);

    public float speed;

    public float forceJump = 2; 


    private void Update(){
        
        HandleJump();
        HandleMove();

    }

    private void HandleMove(){
        if(Input.GetKey(KeyCode.LeftArrow)){
            //rig2D.MovePosition(rig2D.position - velocity * Time.deltaTime);

            rig2D.velocity = new Vector2(-speed, rig2D.velocity.y);
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
           // rig2D.MovePosition(rig2D.position + velocity * Time.deltaTime);

            rig2D.velocity = new Vector2(speed, rig2D.velocity.y);

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
