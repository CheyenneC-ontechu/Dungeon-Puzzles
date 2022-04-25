using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class executeSwitch : MonoBehaviour
{    
    [SerializeField] private string[] solution;
    [SerializeField] private string[] solutionToPlay;
    [SerializeField] private GameObject[] areas; //where code blocks are to be placed
    [SerializeField] private GameObject codeSpirit;

    /*
    this functions checks if block placement is correct then plays the solution if it is
    if not it will trigger dialogue telling the player their answer was incorrect
    */
    public void Execute(){
        AudioSource audio = GetComponent<AudioSource>();
        if (audio){audio.Play();}

        string[] attempt = GetBlocks();
        if (attempt == null){
            GetComponent<dialogueTrigger>().TriggerDialogue();
            return;
        }
        for (int i = 0; i< attempt.Length; i++){
            if (attempt[i] != solution[i]){
                GetComponent<dialogueTrigger>().TriggerDialogue();
                return;
            }
        }
        codeSpirit.GetComponent<spiritMovement>().PlaySolution(solutionToPlay);
    }

    /*
    this function gets names of blocks that were placed in the areas
    */
    private string[] GetBlocks(){
        string[] blockNames = new string[areas.Length];
        for (int i = 0; i < blockNames.Length; i++){
            //if the area has no child not all spaces were filled
            if (areas[i].transform.childCount < 2){
                return null;
            }
            //get the name of the block in the area
            blockNames[i] = areas[i].transform.GetChild(1).gameObject.name;
        }
        return blockNames;

    }
}
