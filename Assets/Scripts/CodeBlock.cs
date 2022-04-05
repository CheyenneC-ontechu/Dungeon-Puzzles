using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBlock : MonoBehaviour
{
    public Vector2 originalPosition;

    [SerializeField] private LayerMask dropArea;

    void Start()
    {
        originalPosition = transform.position;
    }

    public void SnapToSpace() {
        Collider2D[] spaces = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y),
        2.0f,dropArea);
        if (spaces.Length == 0){
            SnapToGrid();
            transform.parent = null;
            return;
        }
        Transform space = spaces[0].gameObject.transform;
        for (int i = 1; i < spaces.Length; i++){
            if (Vector3.Distance(space.position, transform.position) > 
            Vector3.Distance(spaces[i].gameObject.transform.position, transform.position)){
                space = spaces[i].gameObject.transform;
            }
        }
        transform.position = space.position;
        transform.parent = space.gameObject.transform;
    }

    public void SnapToGrid() 
    {
        this.transform.position = new Vector2(Mathf.RoundToInt(this.transform.position.x),
        Mathf.RoundToInt(this.transform.position.y));
    }

    public void Execute(){
        
    }
}
