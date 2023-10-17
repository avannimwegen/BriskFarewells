using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] AnimationStateChanger animationStateChanger;
    [SerializeField] Transform playerTransform;

    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        playerTransform = transform;
    }

    public void moveTransform(Vector3 vel){
        transform.position += vel * Time.deltaTime; 
    }

    public void moveRobot(Vector3 vel){
        
        rb.velocity = vel * speed;
        if(vel.magnitude > 0){
            animationStateChanger.ChangeAnimationState("Walk");
        }else{
            animationStateChanger.ChangeAnimationState("Idle");
        }
    }

    public void moveRB(Vector3 vel){
        rb.velocity = vel * speed;
    }

    public void MoveToward(Vector3 target){
        // Look at target
        Quaternion lookRotation = Quaternion.LookRotation(transform.forward, target - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 20);

        // Move to target
        Vector3 direction = (target - transform.position).normalized;
        Vector3 newPosition = playerTransform.position + direction * Time.deltaTime * speed;
        playerTransform.position = newPosition;
    }
}
