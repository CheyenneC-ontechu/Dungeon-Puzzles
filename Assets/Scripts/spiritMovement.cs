using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class spiritMovement : MonoBehaviour
{
    public Vector2 originalPosition;
    public Animator animator;

    bool isFacingRight;

    void Start()
    {
        originalPosition = transform.position;
        isFacingRight = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public async void PlaySolution(string[] instructions) {
        for (int i = 0; i < instructions.Length; i++){
            await Task.Delay(1000);
            PlayAnimation(instructions[i]);
            
        }
    }

    private void PlayAnimation(string instruction){
        switch (instruction){
            case "Up":
                moveUp();
                break;
            case "Down":
                moveDown();
                break;
            case "Right":
                moveRight();
                break;
            case "Left":
                moveLeft();
                break;
            default:
                Debug.Log("No Animation To Play");
                break;
        }
    }


    private void moveUp()
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
        } 
        animator.SetBool("Side", true);
        this.transform.position = new Vector2(this.transform.position.x-1, this.transform.position.y);
        
    }
    public void moveRight()
    {
        if (!isFacingRight){
            Flip(); 
        }
        animator.SetBool("Side", true);
        this.transform.position = new Vector2(this.transform.position.x+1, this.transform.position.y);
    }


    void Flip() 
    {
        transform.Rotate(0f,180f,0f);
        isFacingRight = !isFacingRight;
    }


}
