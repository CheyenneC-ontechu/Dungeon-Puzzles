using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetManager : MonoBehaviour
{
    GameObject[] blocks;
    GameObject[] spirits;

    void Start()
    {
        spirits = GameObject.FindGameObjectsWithTag("Spirit");
        blocks = GameObject.FindGameObjectsWithTag("CodeBlock");
    }

    public void resetPuzzle()
    {
        // foreach (GameObject spirit in spirits){
        //     spirit.transform.position = spirit.GetComponent<spiritMovement>().originalPosition;
        // }

    }

    public void resetBlocks()
    {
        foreach (GameObject block in blocks){
            block.transform.position = block.GetComponent<CodeBlock>().originalPosition;
        }
    }

    private void reset(GameObject[] objects){
        
    }
}
