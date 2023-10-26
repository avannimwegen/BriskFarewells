using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoxSpawner : MonoBehaviour
{
    Movement movement;
    [SerializeField] GameObject boxPrefab;
    [SerializeField] int hitPoints = 50;
    //public Transform spawnTransform;
    private bool SFXplayed = false;
    private int countSpawn;
    public ParticleSystem particleBurst;

    void Awake(){
        movement = GetComponent<Movement>();
        //spawnTransform = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnBoxesOverTime();
    }

    //void SpawnBoxesOverTime2(){
    //    StartCoroutine(SpawnBoxesOverTimeRoutine());

    //    IEnumerator SpawnBoxesOverTimeRoutine(){
    //        yield return new WaitForSeconds(2);
    //        Instantiate(boxPrefab, Vector3.zero, Quaternion.identity);

    //        yield return null;
    //    }

    //}

    void SpawnBoxesOverTime(){
        StartCoroutine(SpawnBoxesOverTimeRoutine());

        IEnumerator SpawnBoxesOverTimeRoutine(){

            while(true){
                yield return new WaitForSeconds(1.8f);
                Vector3 randomOffset = new Vector3(transform.position.x + Random.Range(-1f, 1f), transform.position.y + Random.Range(-1f, 1f), 0f);
                GameObject newBox = Instantiate(boxPrefab, new Vector3(randomOffset.x, randomOffset.y, 0), Quaternion.identity);    
            }

            yield return null;
        }

    }

    // Update is called once per frame
    void Update(){
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
