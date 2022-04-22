using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(dialogueTrigger))]
public class Instructions : MonoBehaviour
{
    private void OnTriggerEnter2D(){
        GetComponent<dialogueTrigger>().TriggerDialogue();
    }
}
