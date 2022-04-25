using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBlock : MonoBehaviour
{
    private Vector2 originalPosition;

    [SerializeField] private LayerMask dropArea;
    [SerializeField] private float dropRadius = 2.0f;

    void Start()
    {
        originalPosition = transform.position;
    }

    /*
    this function snaps the codeblock to the closest BlockArea within the drop radius
    the block will become a child of the BlockArea
    */
    public void SnapToSpace() {
        //block areas within specified radius
        Collider2D[] areas = Physics2D.OverlapCircleAll(
            new Vector2(transform.position.x, transform.position.y),dropRadius,dropArea);

        if (areas.Length == 0){ //if no areas within radius 
            SnapToGrid();
            transform.parent = null; //player no longer holding block
            return;
        }

        //determine which areas is closest
        Transform area = areas[0].gameObject.transform;
        for (int i = 1; i < areas.Length; i++){
            if (Vector3.Distance(area.position, transform.position) > 
            Vector3.Distance(areas[i].gameObject.transform.position, transform.position)){
                area = areas[i].gameObject.transform;
            }
        }

        //set block to area position then area becomes new parent
        transform.position = area.position;
        transform.parent = area.gameObject.transform;
        
        //play sound effect
        AudioSource audio = transform.parent.GetComponent<AudioSource>();
        if (audio){audio.Play();}
    }

    public void SnapToGrid() 
    {
        this.transform.position = new Vector2(Mathf.RoundToInt(this.transform.position.x),
        Mathf.RoundToInt(this.transform.position.y));
    }

}
