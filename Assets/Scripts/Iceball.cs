using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceball : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 1;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.velocity = Vector2.down * speed;
    }

    private void OnCollisionEnter2D(Collision2D col){
        Destroy(gameObject);
    }
}
