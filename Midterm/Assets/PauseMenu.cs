using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool optionsMenuOpen = false;
    public GameObject optionsMenuUI;
    public GameObject pauseMenuUI;
    public AudioMixer audioMixer;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (optionsMenuOpen){
                CloseOptionMenu();
            } else if (GameIsPaused){
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause(){
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }

    public void OpenOptionMenu(){
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
        optionsMenuOpen = true;
    }

    public void CloseOptionMenu(){
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
        optionsMenuOpen = false;
    }    

    public void LoadMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start_Menu");
    }

    public void QuitGame(){
        Debug.Log("Quit Game Button Pressed.");
        Application.Quit();
    }

    public void SetMasterVolume(float volume){
        audioMixer.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume(float volume){
        audioMixer.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume(float volume){
        audioMixer.SetFloat("sfxVolume", volume);
    }


}
