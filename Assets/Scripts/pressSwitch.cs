using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressSwitch : MonoBehaviour
{   
    public float raycastDistance = 10.0f;
    Vector2 direction;
    int layerMask = 1 << 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)){
            var movement = GetComponent<playerMovement>();
            direction = new Vector2(movement.lastHorizontal, movement.lastVertical); 
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction,raycastDistance,layerMask);
            
            if(hit.collider != null){
                hit.collider.GetComponent<executeSwitch>().Execute();
            }
        }
    }

}
