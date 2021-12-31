using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public float speed = 0f;
    float timePass = 0f;
    public Rigidbody2D rigidBodyBot;

    void moveRight(){
        if(wheelTouching){
            //rigidBodyBot.MovePosition(rigidBodyBot.position + new Vector2(speed ,0f) * Time.fixedDeltaTime);
            
        }
    }

     bool wheelTouching = false;
     void OnCollisionEnter2D(Collision2D other){ wheelTouching = true; }
     void OnCollisionExit2D(Collision2D other){ wheelTouching = false; }


    int actionNumber = 1;
    void Update()
    {
        timePass += Time.deltaTime;
        //Debug.Log(timePass);

        switch(actionNumber){
            case 0:
                //Do nothing
                break;
            case 1:
                moveRight();
                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;

        }
    }
}
