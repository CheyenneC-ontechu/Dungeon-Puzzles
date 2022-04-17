using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyElement : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject destroyVFX;
    //[SerializeField] LayerMask playerLayer;
    private void Awake(){
        animator = GetComponent<Animator>();
    }

    public void FreezeColour(){
        animator.SetTrigger("ColourStay");
    }

    private void OnCollisionEnter2D(Collision2D other){
        // if (other.collider.gameObject.layer != playerLayer){
        //     Destroy(gameObject);
        // }
        Destroy(gameObject);
    }
    private void OnDestroy() {
        Instantiate(destroyVFX, transform.position, Quaternion.identity);
    }
}
