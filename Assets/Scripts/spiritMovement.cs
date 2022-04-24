using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class spiritMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject fireball;
    [SerializeField] private GameObject chest;
    [SerializeField] Vector2 direction = Vector2.right;

    private bool isFacingRight;

    private void Start()
    {
        isFacingRight = false;
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
            case "Fire":
                Fire();
                break;
            case "Unlock":
                Unlock();
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

    public void Fire(){
        Instantiate(fireball, transform);
    }

    public void Unlock(){
        chest.GetComponent<Animator>().SetTrigger("Open");
        AudioSource audio = chest.GetComponent<AudioSource>();
        if (audio){audio.Play();}
    }


    void Flip() 
    {
        transform.Rotate(0f,180f,0f);
        isFacingRight = !isFacingRight;
    }


}
