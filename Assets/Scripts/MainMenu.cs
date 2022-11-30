using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PickDifficulty(string difficulty){
        SceneManager.LoadScene(difficulty);
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void Quit(){
        Debug.Log("Quit");
        Application.Quit();
        //Application.OpenURL("about:blank");
    }
}
