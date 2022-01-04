using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Part_Outside_Socket_Handler : MonoBehaviour{

    private Plane dragPlane;
    private Vector3 offset;
    private Camera myMainCamera; 
    public Vector3 spawnPosition;
    public bool isTouchingSocket = false, touchedSocketAvailable = false;
    private Socket_Handler socketHandler;
    private Sound_Handler soundHandler;
    void Start()
    {
        socketHandler = GameObject.Find("sockets").GetComponent<Socket_Handler>();
        soundHandler = GameObject.Find("script holder").GetComponent<Sound_Handler>();

        myMainCamera = Camera.main;
        spawnPosition = transform.position;
    }

    void OnMouseDown()
    {
        socketHandler.CheckWhichSocketsYouCanPutAPartIn("core");
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




}
