using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoxSpawner : MonoBehaviour
{
    Movement movement;

    // What prefabs to spawn and SpawnerInfo like hitpoints
    [SerializeField] GameObject boxPrefab;
    [SerializeField] int hitPoints = 20;

    // Spawning system
    [SerializeField] float viewRadius = 15;  // don't spawn enemies if player if afk in corner
    public bool spawning; // If spawner is on, don't repeatedly call coroutines.
    private Coroutine spawnCoroutine;

    // only get destroyed once
    private bool SFXplayed = false;
    public ParticleSystem particleBurst;

    // Get player transform to start spawning based on distance
    [SerializeField] Transform playerTransform;

    void Awake(){
        movement = GetComponent<Movement>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //void SpawnBoxesOverTime2(){
    //    StartCoroutine(SpawnBoxesOverTimeRoutine());

    //    IEnumerator SpawnBoxesOverTimeRoutine(){
    //        yield return new WaitForSeconds(2);
    //        Instantiate(boxPrefab, Vector3.zero, Quaternion.identity);

    //        yield return null;
    //    }

    //}


    IEnumerator SpawnBoxesOverTimeRoutine(){

            while(true){
                yield return new WaitForSeconds(1.8f);
                Vector3 randomOffset = new Vector3(transform.position.x + Random.Range(-1f, 1f), transform.position.y + Random.Range(-1f, 1f), 0f);
                GameObject newBox = Instantiate(boxPrefab, new Vector3(randomOffset.x, randomOffset.y, 0), Quaternion.identity);    
            }

            yield return null;
    }


    // Update is called once per frame
    void Update(){
        if(Vector3.Distance(transform.position, playerTransform.position) < viewRadius){
            if(!spawning){
                Debug.Log("Start spawning");
                spawnCoroutine = StartCoroutine(SpawnBoxesOverTimeRoutine());
                spawning = true;
            }
        } else {
            if(spawning){
                Debug.Log("Stop spawning");
                StopCoroutine(spawnCoroutine);
                spawning = false;
            }
        }

        if (hitPoints < 1){
            // Only play sound effect once!
            if(SFXplayed == false){
                Vector3 randomOffset = new Vector3(Random.Range(0f, 2f), Random.Range(0f, 2f), 0f);
                Instantiate(particleBurst, transform.position + randomOffset, Quaternion.identity);
                Instantiate(particleBurst, transform.position - randomOffset, Quaternion.identity);
                Instantiate(particleBurst, transform.position, Quaternion.identity);
                GetComponent<AudioSource>().Play();
            }
            SFXplayed = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(this.gameObject);
        }
    }

        void OnTriggerEnter2D(Collider2D other){
            if (other.tag == "Player"){
                // Is fine to touch
            
            // Projectile takes damage when shot by player.
            } else if(other.tag == "PlayerProjectile"){
                hitPoints -= 1;
            }
    }
}
