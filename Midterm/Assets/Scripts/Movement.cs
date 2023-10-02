using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    public void moveTransform(Vector3 vel){
        transform.position += vel * Time.deltaTime; 
    }

    public void moveRB(Vector3 vel){
        rb.velocity = vel * speed;
    }
}
