using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

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
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
