using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyElement : MonoBehaviour
{
    private SpriteRenderer spriterenderer;

    [SerializeField] private Color FireColor;
    [SerializeField] private Color IceColor; 

    private void Awake(){
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    private void Start(){
        int rand = Random.Range(0,2);
        Debug.Log(rand);
        if (rand < 1){
            spriterenderer.color = FireColor;
        } else {
            spriterenderer.color = IceColor;
        }
    }
}
