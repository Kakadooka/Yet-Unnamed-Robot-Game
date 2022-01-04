using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part_Inside_Socket_Handler : MonoBehaviour
{

    private Socket_Handler socketHandler;

    int x, y;
    void OnMouseDown()
    {
        socketHandler = GameObject.Find("sockets").GetComponent<Socket_Handler>();
        x = System.Int32.Parse(gameObject.name.Split(' ')[0]);
        y = System.Int32.Parse(gameObject.name.Split(' ')[1]);
        

    }

    
    void OnMouseUp(){
        if(isTouchingSocket && touchedSocketAvailable){
            soundHandler.PlaySound("available");
            socketHandler.PutPrefabInsteadOfSocket(collidedX, collidedY, partName);
        }
        else if(isTouchingSocket && !touchedSocketAvailable){
            soundHandler.PlaySound("unavailable");           
        }
        else{
            soundHandler.PlaySound("screw falling");
        }
        transform.position = spawnPosition;
        socketHandler.ResetAllSocketStates();
    }
    
    int collidedX, collidedY;
    string partName;
    void OnTriggerEnter2D(Collider2D collided){
        if( collided.gameObject.tag.Equals("Part Socket") == true ){

            isTouchingSocket = true;
            collidedX = System.Int32.Parse(collided.transform.gameObject.name.Split(' ')[1]);
            collidedY = System.Int32.Parse(collided.transform.gameObject.name.Split(' ')[2]);
            touchedSocketAvailable = socketHandler.getSocketAvailabilityState(collidedX, collidedY);

            partName = gameObject.name;
        
            collided.transform.gameObject.GetComponent<Single_Socket_Handler>().HoverOverAvailable();

        }
    }
    void OnTriggerExit2D(Collider2D collided){
        if( collided.gameObject.tag.Equals("Part Socket") == true ){
            isTouchingSocket = false;
            collided.transform.gameObject.GetComponent<Single_Socket_Handler>().UnHover();
        }
    }

    //eee no tu prosze jesli no kurwa ten klikasz w wlozony part tooo eee no sie wyciaga i no i sie wlacza socket
}
