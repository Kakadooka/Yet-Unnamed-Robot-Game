using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single_Socket_Handler : MonoBehaviour
{
    public Sprite availableSprite, unavailableSprite, neutralSprite;
    public SpriteRenderer spriteRenderer;
    public bool available = false;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        availableSprite = Resources.Load<Sprite>("sprites/sockets/available");
        unavailableSprite = Resources.Load<Sprite>("sprites/sockets/unavailable");
        neutralSprite = Resources.Load<Sprite>("sprites/sockets/neutral");

        gameObject.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
    }

    public void SetSocketAppearanceToUnavailable(){
        available = false;
        gameObject.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
        spriteRenderer.sprite = unavailableSprite;
    }
    public void SetSocketAppearanceToAvailable(){
        available = true;
        gameObject.transform.localScale = new Vector3(0.35f,0.35f,0.35f);
        spriteRenderer.sprite = availableSprite;
    }
    public void HoverOverAvailable(){
        if (available){
            gameObject.transform.localScale = new Vector3(0.4f,0.4f,0.4f);
        }
    }
    public void UnHover(){
        if (available){
            gameObject.transform.localScale = new Vector3(0.35f,0.35f,0.35f);
        }
    }
    public void SetSocketAppearanceToNeutral(){
         available = false;
         gameObject.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
         spriteRenderer.sprite = neutralSprite;
    }


}
