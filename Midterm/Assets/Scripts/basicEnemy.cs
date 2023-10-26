using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingBox : MonoBehaviour
{

    //public ParticleSystem particleBurst;
    Movement movement;
    [SerializeField] int targetHp = 5;
    private bool destroyed = false;
    public GameObject Telegraph;

    // Start is called before the first frame update
    void Awake()
    {
        movement = GetComponent<Movement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player"){
            // If target hits player, check radius and explode.
            
        } else if (other.tag == "PlayerProjectile"){
        // Projectile takes damage when shot by player.      
            targetHp -= 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (targetHp < 1){
            // Only play sound effect + death explosion effect ONCE!
            DestroyShip();
        }

    }

    void DestroyShip(){
        if(destroyed == false){
            Instantiate(Telegraph, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        } destroyed = true;
    }

    //public void ExplodeShip(){
    //       if(SFXplayed == false){
    //          Instantiate the particle effect (this deletes itself in its own script)
    //          Instantiate(particleBurst, transform.position, Quaternion.identity); 
    //          Explosion SFX
    //          GetComponent<AudioSource>().Play();
    //       }
    //       (Clunky) turn off collider and sprite, then delete when sound effect finish playing
    //       gameObject.GetComponent<SpriteRenderer>().enabled = false;
    //       gameObject.GetComponent<Collider2D>().enabled = false;
    //       movement.enabled = false;
    //       Destroy(this.gameObject, 0.4f);
    //}
}
