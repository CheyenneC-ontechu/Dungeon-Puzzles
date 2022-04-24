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

    private void OnCollisionEnter2D(Collision2D other){
        if (!other.collider.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
    private void OnDestroy() {
        Instantiate(destroyVFX, transform.position, Quaternion.identity);
    }
}
