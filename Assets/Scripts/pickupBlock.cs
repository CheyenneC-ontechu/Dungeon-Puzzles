using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupBlock : MonoBehaviour
{   
    public float raycastDistance = 10.0f;
    [SerializeField] private LayerMask blockLayer;//layer where code blocks are
    bool isHolding = false;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)){
            if (isHolding){
                foreach (Transform child in transform){
                    if (child.CompareTag("CodeBlock")){
                        child.GetComponent<CodeBlock>().SnapToSpace();
                    }
                }
                isHolding = false;
            } else {
                var movement = GetComponent<playerMovement>();
                direction = new Vector2(movement.lastHorizontal, movement.lastVertical); 
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction,raycastDistance,blockLayer);
                
                if(hit.collider != null){
                    hit.collider.transform.parent = this.transform;
                    isHolding = true;
                }
            }
        }
    }


}
