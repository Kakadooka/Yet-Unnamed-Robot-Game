using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket_Handler : MonoBehaviour
{
    
    public string[,] sockets = new string[3,3];

    public Single_Socket_Handler[,] singleSocketHandler = new Single_Socket_Handler[3,3];


    void Start(){

        for(int i = 0; i <= 2; i++){
            for(int j = 0; j <=2; j++){
                singleSocketHandler[i,j] = GameObject.Find("socket "+i+" "+j).GetComponent<Single_Socket_Handler>();
                sockets[i,j] = "";
            }
        }
    }


        public bool getSocketAvailabilityState(int i, int j){
            return singleSocketHandler[i,j].available;
        }

        public string part;
        public int x = 0;
        public int y = 0;

        bool CheckIfSocketIsOutsideArray(int offsetX, int offsetY){
            return x+offsetX >= 0 && x+offsetX < 3 && y+offsetY >= 0 && y+offsetY < 3;
        }

        bool CheckIfPartAboveExists(){
            if(CheckIfSocketIsOutsideArray(1,0)){     
                return sockets[x+1,y] != "";
            }
            return false;
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
                default:
                    return true;
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

    public void ResetAllSocketStates(){
        for(int i = 0; i <= 2; i++){
            for(int j = 0; j <=2; j++){
                x = i; y = j;
                singleSocketHandler[i,j].SetSocketAppearanceToNeutral();
            }
        }   
    }
    
    public void PlacePartIntoSocket(int x, int y){
        if(singleSocketHandler[x,y].available){

        }

    }

    public void RemovePartFromSocket(int x, int y){
        sockets[x,y] = "";

    }

    public GameObject temp;

    public void PutPrefabInsteadOfSocket(int x, int y, string part){
        GameObject partObject = Instantiate(temp);

        partObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Prefabs/parts/part images/"+part);
        partObject.name = x +" "+ y +" socket " + part;
        partObject.transform.position = singleSocketHandler[x,y].gameObject.transform.position;     

        singleSocketHandler[x,y].gameObject.SetActive(false);


    }

    public void PullPrefabFromSocket(int x, int y, string part){

    }
}
