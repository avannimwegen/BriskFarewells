using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextZone2 : MonoBehaviour
{
    public int checkpointID;
    public GameObject player;

    void Start(){
        if(PlayerPrefs.GetInt(SaveFlags.checkpointString) == checkpointID){
            player.transform.position = transform.position;
        }

    }


    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player"){
            PlayerPrefs.SetInt(SaveFlags.checkpointString, checkpointID);
        } 
    }
}
