using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockmovement : MonoBehaviour
{
    public bool isBeingHeld = false;
    private float startPosX;
    private float startPosY;

    public Rigidbody2D rb;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld){
            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            movement = new Vector2(mousePos.x-startPosX,mousePos.y-startPosY);
            
        }
        
    }

    void FixedUpdate()
    {
        if (isBeingHeld){
            rb.MovePosition(movement);
            //SnapToGrid();
        }
    }

    private void OnMouseDown() 
    {
        if (Input.GetMouseButtonDown(0)){
            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;
        }

        
    }

    private void OnMouseUp() 
    {
        isBeingHeld = false;
        SnapToGrid();
    }

    private void SnapToGrid() 
    {
        // Vector2 snap = new Vector2(Mathf.RoundToInt(this.transform.position.x),
        // Mathf.RoundToInt(this.transform.position.y)+0.5f);

        // rb.MovePosition(snap);

        this.transform.position = new Vector2(Mathf.RoundToInt(this.transform.position.x),
        Mathf.RoundToInt(this.transform.position.y-0.5f)+0.5f);
    }

}
