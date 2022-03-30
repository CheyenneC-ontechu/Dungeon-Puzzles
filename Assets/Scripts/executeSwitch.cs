using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class executeSwitch : MonoBehaviour
{
    string[] blocks;
    [SerializeField] private string[] solution;
    [SerializeField] private GameObject[] areas;
    public void Execute(){
        string[] attempt = GetBlocks();
        for (int i = 0; i< attempt.Length; i++){
            if (attempt[i] != solution[i]){
                Debug.Log("Wrong");
                return;
            }
        }
        PlaySolution();
    }

    public void PlaySolution(){
        Debug.Log("Correct");
    }

    private string[] GetBlocks(){
        string[] blockNames = new string[areas.Length];
        for (int i = 0; i < blockNames.Length; i++){
            blockNames[i] = areas[i].transform.GetChild(0).gameObject.name;
        }
        return blockNames;

    }
}
