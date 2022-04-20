using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObjectSwitch : MonoBehaviour
{
    [SerializeField] GameObject RemoveObject;
    
    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(RemoveObject);
    }
}
