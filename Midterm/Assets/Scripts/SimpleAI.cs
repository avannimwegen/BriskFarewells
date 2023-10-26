using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    Movement movement;
    
    //public ParticleSystem particleBurst;
    [SerializeField] float viewRadius = 5;
    [SerializeField] bool activated = false;
    [SerializeField] bool detonated = false;
    [SerializeField] Transform playerTransform;
    public GameObject EnemyProjectile;
    public GameObject Telegraph;

    void Awake(){
        movement = GetComponent<Movement>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    { 
        if(detonated){
            Idle();
        } else if(Vector3.Distance(transform.position, playerTransform.position) < 1){
            Bomb();
        } else if(Vector3.Distance(transform.position, playerTransform.position) < viewRadius){
            FollowPlayer();
        } else if(activated){
            Patrol();
        } else {
            Idle();
        }
    }

    public void FollowPlayer(){
        if(activated == false){
            FireAtPlayer();
        }
        activated = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        movement.MoveToward(playerTransform.position);
    }

    public void FireAtPlayer(){
        //targetPosition.z = 0;
        Vector3 dir = (playerTransform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion bulletAngle = Quaternion.Euler(new Vector3(0, 0, angle));
        Rigidbody2D newProjectileRB = Instantiate(EnemyProjectile, transform.position, bulletAngle).GetComponent<Rigidbody2D>();
    }

    Vector3 patrolPos = Vector3.zero;
    public void Patrol(){
        if(Vector3.Distance(transform.position, patrolPos) < 2){
            GetComponent<SpriteRenderer>().color = Color.yellow;
            patrolPos = transform.position + new Vector3(Random.Range(-1,1), Random.Range(-1,1), 0);
        }
        movement.MoveToward(patrolPos);
    }

    public void Idle(){
        GetComponent<SpriteRenderer>().color = Color.white;
        movement.moveRB(Vector3.zero);
    }

    public void Bomb(){
        if(!detonated){
            Instantiate(Telegraph, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        //Instantiate(particleBurst, transform.position, Quaternion.identity);
        detonated = true;
    }
}
