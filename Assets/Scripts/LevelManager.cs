using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string nextLevel;

    public void LoadMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void ReloadLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadLevel(string level){
        SceneManager.LoadScene(level);
    }

    public void Quit(){
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        LoadLevel(nextLevel);
    }
}
