using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiritMovement : MonoBehaviour
{
    public Vector2 originalPosition;
    public Animator animator;

    bool isFacingRight;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        isFacingRight = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void moveSpirit()
    {
        
        animator.SetBool("Side",true);

    }

    public void moveUp()
    {
        animator.SetBool("Up", true);
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y+1);
    }

    public void moveDown()
    {
        animator.SetBool("Down", true);
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y-1);

    }
    
    public void moveLeft()
    {
        if (isFacingRight){
            Flip();
            animator.SetBool("Side", true);
            this.transform.position = new Vector2(this.transform.position.x-1, this.transform.position.y);
        } else {
            animator.SetBool("Side", true);
            this.transform.position = new Vector2(this.transform.position.x-1, this.transform.position.y);
        }
    }

    public void moveRight()
    {
        if (!isFacingRight){
            Flip();
            animator.SetBool("Side", true);
            this.transform.position = new Vector2(this.transform.position.x+1, this.transform.position.y);
        } else {
            animator.SetBool("Side", true);
            this.transform.position = new Vector2(this.transform.position.x+1, this.transform.position.y);
        }
    }


    void Flip() 
    {
        transform.Rotate(0f,180f,0f);
        isFacingRight = !isFacingRight;
    }
}
