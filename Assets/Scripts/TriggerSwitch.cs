using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSwitch : MonoBehaviour
{
    [SerializeField] GameObject RemoveCollider;
    
    private void OnTriggerEnter2D(Collider2D other) {
        Collider2D collider = RemoveCollider.gameObject.GetComponent(typeof(Collider2D)) as Collider2D;
        Destroy(collider);
    }
}
