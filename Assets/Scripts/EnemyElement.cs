using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyElement : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject destroyVFX;

    private void Awake(){
        animator = GetComponent<Animator>();
    }

    /*
    this function destroys the enemy if it collides with something that is not the player
    */
    private void OnCollisionEnter2D(Collision2D other){
        if (!other.collider.gameObject.CompareTag("Player")){
            Instantiate(destroyVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
