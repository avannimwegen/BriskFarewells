using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelegraphExplosion : MonoBehaviour
{
    public Transform playerTransform;
    [SerializeField] float fuseTime = 0.5f;
    public ParticleSystem particleBurst;
    public GameObject playerObject;

    [Header("Telegraph timer that grows")]
    public Transform spriteTransform; // Reference to the telegraph that grows

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        Telegraph();
    }

public void Telegraph(){
        StartCoroutine(StartTelegraph());
        IEnumerator StartTelegraph(){
            float timer = 0f;
            Vector3 initialScale = spriteTransform.localScale;
            Vector3 targetScale = new Vector3(6.5f, 6.5f, 1.0f);

            while(timer < fuseTime){
                spriteTransform.localScale = Vector3.Lerp(initialScale, targetScale, timer / fuseTime);
                timer += Time.deltaTime;
                yield return null;
            }
            spriteTransform.localScale = targetScale;

            // Check to see if player is hit
            if(Vector3.Distance(transform.position, playerTransform.position) < 1.5f){
                if (playerObject != null){
                    PlayerShip playerShip = playerObject.GetComponent<PlayerShip>();
                    if (playerShip != null){
                        // Call the TakeDamage method on the playerShip component
                        playerShip.TakeDamage(20);
                    }
                }
                //SceneManager.LoadScene("Start_Menu");
            }
            // Explode
            ExplodeShip();
            yield return null;
        }
    }

    public void ExplodeShip(){
        // Play Explosion ParticleEffect
        Instantiate(particleBurst, transform.position, Quaternion.identity); 
        // Explosion SFX
        GetComponent<AudioSource>().Play();
    }
}
