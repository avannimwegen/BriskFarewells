using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallHealthPack : MonoBehaviour
{
    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }


    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player"){
            Debug.Log("Player touched Health pack");
            Heal(20);  
            Destroy(this.gameObject); 
        }        
    }

    public void Heal(int amount){
        if (playerObject != null){
            PlayerShip playerShip = playerObject.GetComponent<PlayerShip>();
            if (playerShip != null){
                // Call the TakeDamage method on the playerShip component
                Debug.Log("Player should heal for " + amount);
                playerShip.Heal(amount);
            }
        }
    }

} // end small Health Pack