using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class executeSwitch : MonoBehaviour
{
    string[] blocks;
    [SerializeField] private string[] solution;
    [SerializeField] private string[] solutionToPlay;
    [SerializeField] private GameObject[] areas; //where code blocks are to be placed
    [SerializeField] private GameObject codeSpirit;

    //check if block placement is correct then playsolution if it is
    public void Execute(){
        string[] attempt = GetBlocks();
        if (attempt == null){
            Debug.Log("spaces not filled");
            return;
        }
        for (int i = 0; i< attempt.Length; i++){
            if (attempt[i] != solution[i]){
                Debug.Log("Wrong");
                return;
            }
        }
        Debug.Log("Correct");
        codeSpirit.GetComponent<spiritMovement>().PlaySolution(solutionToPlay);
    }

    //get names of blocks that were placed in the areas
    private string[] GetBlocks(){
        string[] blockNames = new string[areas.Length];
        for (int i = 0; i < blockNames.Length; i++){
            //if the area has no child not all spaces were filled
            if (areas[i].transform.childCount == 0){
                return null;
            }
            blockNames[i] = areas[i].transform.GetChild(1).gameObject.name;
        }
        return blockNames;

    }
}
