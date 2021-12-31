using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Drag_Object : MonoBehaviour{

    private Plane dragPlane;
    private Vector3 offset;
    private Camera myMainCamera; 
    public Vector3 spawnPosition;
    public bool isTouchingSocket = false;
    private Socket_Handler socketHandler;
    void Start()
    {
        socketHandler = GameObject.Find("sockets").GetComponent<Socket_Handler>();
        myMainCamera = Camera.main;
        spawnPosition = transform.position;
    }

    void OnMouseDown()
    {
        dragPlane = new Plane(myMainCamera.transform.forward, transform.position); 
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition); 

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist); 
        offset = transform.position - camRay.GetPoint(planeDist);


        socketHandler.CheckWhichSocketsYouCanPutAPartIn("core");
        

    }

    void OnMouseDrag()
    {   
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition); 

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        transform.position = camRay.GetPoint(planeDist) + offset;
    }
    void OnMouseUp(){
        if(!isTouchingSocket){
            transform.position = spawnPosition;
        }
        else{

        }
    }
    

    void OnTriggerEnter2D(Collider2D collided){
        if( collided.gameObject.tag.Equals("Part Socket") == true ){
            isTouchingSocket = true;
            // Debug.Log(collided.transform.gameObject.name);
            // Debug.Log(gameObject.name);

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
