using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(playerMovement))]
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 10.0f;
    [SerializeField] private LayerMask switchLayer;
    [SerializeField] private LayerMask dialogueLayer;
    [SerializeField] private LayerMask blockLayer;//layer where code blocks are

    private Vector2 direction; //direction player is facing

    private bool isHolding = false;
    
    private void Update(){
        if (Input.GetKeyDown(KeyCode.Z)){
            var movement = GetComponent<playerMovement>();
            direction = new Vector2(movement.GetLastHorizontal(), movement.GetLastVertical()); 

            if (isHolding){
                foreach (Transform child in transform){
                    if (child.CompareTag("CodeBlock")){
                        child.GetComponent<CodeBlock>().SnapToSpace();
                    }
                }
                isHolding = false;
                return;
            }

            //check if picking up block
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction,raycastDistance,blockLayer);
            
            if (hit.collider != null) {
                hit.collider.transform.parent = this.transform;
                isHolding = true;
                return;
            }


            //check if pressing switch
            hit = Physics2D.Raycast(transform.position, direction,raycastDistance,switchLayer);
            
            if(hit.collider != null){
                hit.collider.GetComponent<executeSwitch>().Execute();
                return;
            } 

            //check if triggering dialogue
            hit = Physics2D.Raycast(transform.position, direction,raycastDistance,dialogueLayer);
            if (hit.collider != null){
                hit.collider.GetComponent<dialogueTrigger>().TriggerDialogue();
            }

        }
    }
}
