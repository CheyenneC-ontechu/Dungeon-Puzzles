using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    /*
    this function destroys the flame if something that is not the player collides
    */
    private void OnCollisionEnter2D(Collision2D other){
        if (!other.collider.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
}
