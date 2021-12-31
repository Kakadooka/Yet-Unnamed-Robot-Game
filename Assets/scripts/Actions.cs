using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    void Start()
    {
        
    }

    float timePass = 0f;
    public Rigidbody2D rigidBot;

    void goRight(){
        rigidBot.MovePosition(rigidBot.position + new Vector2(10f,0f) * Time.fixedDeltaTime);
        if(timePass > 333f){
            actionNumber = 0;
        }
    }


    int actionNumber = 1;
    void Update()
    {
        timePass += Time.deltaTime;
        Debug.Log(timePass);

        switch(actionNumber){
            case 0:
                //Do nothing
                break;
            case 1:
                goRight();
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
