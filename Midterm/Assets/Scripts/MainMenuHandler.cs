using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuHandler : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("Level_Two");
    }

    public void PlayTutorial(){
        SceneManager.LoadScene("Level_One");
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
