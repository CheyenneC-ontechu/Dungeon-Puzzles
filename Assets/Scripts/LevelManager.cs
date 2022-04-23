using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string nextLevel;

    public void LoadLevel(string level){
        SceneManager.LoadScene(level);
    }

    public void Quit(){
        Application.Quit();
    }
}
