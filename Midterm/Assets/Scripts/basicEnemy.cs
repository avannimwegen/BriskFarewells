using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBox : MonoBehaviour
{
    Movement movement;
    [SerializeField] int targetHp = 5;
    private bool SFXplayed = false;
    public ParticleSystem particleBurst;

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
        if (other.CompareTag("Player")){
            // If target hits player. Currently handled in Player script.
            targetHp -= 1;
        }

        // Projectile takes damage when shot by player.
        if(other.tag == "friendlyProjectile"){
            targetHp -= 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (targetHp < 1){
            // Only play sound effect + death explosion effect ONCE!
            if(SFXplayed == false){
                // Instantiate the particle effect (this deletes itself in its own script)
               Instantiate(particleBurst, transform.position, Quaternion.identity); 

                // Explosion SFX
                GetComponent<AudioSource>().Play();
            }
            SFXplayed = true;

            // (Clunky) turn off collider and sprite, then delete when sound effect finish playing
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(this.gameObject,1);
        }

    }
}
