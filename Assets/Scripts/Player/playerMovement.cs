using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
allows the user to control player movement
*/
public class playerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private float lastHorizontal;
    private float lastVertical;

    private Vector2 movement;

    public float GetLastHorizontal(){return lastHorizontal;}
    public float GetLastVertical(){return lastVertical;}

    private void Update(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");  

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x != 0 || movement.y != 0 ){
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", movement.y);

            lastHorizontal = movement.x;
            lastVertical = movement.y;
        }
    
}

    private void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
