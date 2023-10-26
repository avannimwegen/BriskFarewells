using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShip : MonoBehaviour
{
    public HealthBar healthBar;
    
    public int maxHealth = 100;
    public int currentHealth;

    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Enemy"){
            // If target hits player. Currently handled in Player script.
            Debug.Log("Player got touched");
            
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth < 1){
            SceneManager.LoadScene("Start_Menu");
        } 
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
