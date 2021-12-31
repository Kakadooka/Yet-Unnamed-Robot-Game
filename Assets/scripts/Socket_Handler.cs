using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket_Handler : MonoBehaviour
{
    
    public string[,] sockets = new string[4,4];

    public Single_Socket_Handler[,] singleSocketHandler = new Single_Socket_Handler[4,4];


    void Start(){
    
        for(int i = 0; i <= 2; i++){
            for(int j = 0; j <=2; j++){
                singleSocketHandler[i,j] = GameObject.Find("socket "+i+" "+j).GetComponent<Single_Socket_Handler>();
                sockets[i,j] = "";
            }
        }
    }




        public string part;
        public int x = 0;
        public int y = 0;

        bool CheckIfPartAboveExists(){
            return sockets[x,y+1] != "";
        }
        public bool CanYouPutThePartInThisSocket(){
            if(sockets[x,y] != ""){
                return false;
            }
            switch(part){
                case "core":
                    return true;
                break;
                case "normal":
                    return true;
                break;
                case "wheel":
                    return CheckIfPartAboveExists();
                break;
            }
            return false;
        }

    public void CheckWhichSocketsYouCanPutAPartIn(string part){
        this.part = part;
        for(int i = 0; i <= 2; i++){
            for(int j = 0; j <=2; j++){
                x = i; y = j;
                if(CanYouPutThePartInThisSocket()){
                singleSocketHandler[i,j].SetSocketAppearanceToAvailable();
                }
                else{
                singleSocketHandler[i,j].SetSocketAppearanceToUnavailable();
                }
            }
        }
    }

    public void ResetSocketState(){

    }
    
    
    public void PlacePartIntoSocket(int x, int y, string part){
        if(sockets[x,y] != null){

        }

    }

    public void RemovePartFromSocket(int x, int y){
        sockets[x,y] = null;

    }

}
