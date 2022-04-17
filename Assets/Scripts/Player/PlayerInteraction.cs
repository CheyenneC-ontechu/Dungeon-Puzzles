using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 10.0f;
    private Vector2 direction;
    [SerializeField] private LayerMask switchLayer;
    [SerializeField] private LayerMask dialogueLayer;
    
    private void Update(){
        if (Input.GetKeyDown(KeyCode.Z)){
            var movement = GetComponent<playerMovement>();
            direction = new Vector2(movement.lastHorizontal, movement.lastVertical); 
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction,raycastDistance,switchLayer);
            
            if(hit.collider != null){
                hit.collider.GetComponent<executeSwitch>().Execute();
            } else {
                hit = Physics2D.Raycast(transform.position, direction,raycastDistance,dialogueLayer);
                if (hit.collider != null){
                    hit.collider.GetComponent<dialogueTrigger>().TriggerDialogue();
                }
            }

        }
    }
}
