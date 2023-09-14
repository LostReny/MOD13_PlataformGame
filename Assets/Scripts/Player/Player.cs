using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rig2D;

    public Vector2 velocity;

    public float speed;


    private void Update(){
        if(Input.GetKey(KeyCode.LeftArrow)){
            //rig2D.MovePosition(rig2D.position - velocity * Time.deltaTime);

            rig2D.velocity = new Vector2(-speed, rig2D.velocity.y);
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
           // rig2D.MovePosition(rig2D.position + velocity * Time.deltaTime);

            rig2D.velocity = new Vector2(speed, rig2D.velocity.y);

        }

    }
}
