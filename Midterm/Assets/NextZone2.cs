using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextZone2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player"){
            // If target hits player. Currently handled in Player script.
            Debug.Log("Player got touched");
            SceneManager.LoadScene("Level_Two");
        } 
    }
}
