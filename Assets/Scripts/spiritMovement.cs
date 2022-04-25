using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


/*
this script is attached to the CodeSpirit prefab
*/
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

    /*
    this function takes an array of strings that are the instructions for the spirit
    */
    public async void PlaySolution(string[] instructions) {
        for (int i = 0; i < instructions.Length; i++){
            await Task.Delay(1000);
            PlayAnimation(instructions[i]);
        }
    }

    /*
    this function takes an instruction and calls the respective function
    */
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


    /*
    these movement functions set the animator direction and translate then spirit position
    */
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

    /*
    this function creates a fireball prefab
    */
    public void Fire(){
        Instantiate(fireball, transform);
    }

    /*
    this function plays the open animation and audio for the specified chest in the scene
    */
    public void Unlock(){
        chest.GetComponent<Animator>().SetTrigger("Open");
        AudioSource audio = chest.GetComponent<AudioSource>();
        if (audio){audio.Play();}
    }

    /*
    this function turns the spirit left or right
    */
    void Flip() 
    {
        transform.Rotate(0f,180f,0f);
        isFacingRight = !isFacingRight;
    }


}
