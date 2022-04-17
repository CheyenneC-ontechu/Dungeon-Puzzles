using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    [HideInInspector] public float lastHorizontal;
    [HideInInspector] public float lastVertical;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
