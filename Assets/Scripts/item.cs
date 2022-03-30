using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public bool isBeingHeld = false;
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
            this.gameObject.transform.localPosition = new Vector2(mousePos.x,mousePos.y);
        }
        
    }

    private void OnMouseDown() {

        if (Input.GetMouseButtonDown(0)){
            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            isBeingHeld = true;
        }

        
    }

    private void OnMouseUp() {
        isBeingHeld = false;
    }
}
