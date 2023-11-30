using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingBox : MonoBehaviour
{
    Material material;
    Movement movement;

    // Basic enemy fields
    [SerializeField] int targetHp = 5;

    // Enemys are slowly created at portals
    [SerializeField] float teleportTime = 3f;
    private float TeleportFade = 0f; // Initial value for _TeleportFade


    // This is for creating the explosion when ship is destroyed
    public GameObject Telegraph;
    private bool destroyed = false;

    // Start is called before the first frame update
    void Awake()
    {
        movement = GetComponent<Movement>();
        material = GetComponent<SpriteRenderer>().material;
        material.SetFloat("_TeleportFade", TeleportFade);
    }
    // Start is called before the first frame update
    void Start()
    {
        TeleportIn();
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

    void TeleportIn(){
        StartCoroutine(TeleportInRoutine());
        IEnumerator TeleportInRoutine(){
            float timer = 0f;

            while (timer < teleportTime)
            {
                // Calculate the new value for _TeleportFade using Lerp
                TeleportFade = Mathf.Lerp(0f, 1f, timer / teleportTime);
                
                // Update the material property
                material.SetFloat("_TeleportFade", TeleportFade);

                timer += Time.deltaTime;
                yield return null;
            }

            // Ensure the value is exactly 1 at the end
            TeleportFade = 1f;
            material.SetFloat("_TeleportFade", TeleportFade);
        }

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
