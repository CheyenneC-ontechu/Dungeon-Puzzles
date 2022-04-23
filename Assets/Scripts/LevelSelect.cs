using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    private void Start(){
        canvas.gameObject.SetActive(false);
    }

    public void ShowSelection(){
        canvas.gameObject.SetActive(true);
    }

    public void CloseSelection(){
        canvas.gameObject.SetActive(false);
    }

}
