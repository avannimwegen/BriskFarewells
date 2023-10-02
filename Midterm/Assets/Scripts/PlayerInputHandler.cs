using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    Movement movement;
    FireProjectile fireProjectile;
    public float fireRate = 0.75f;
    private float nextFire = 0.0f;

    // Start is called before the first frame update
    void Awake()
    {
        movement = GetComponent<Movement>();
        fireProjectile = GetComponent<FireProjectile>();
    }

    // Update is called once per frame
    void Update(){
            if(Input.GetKey(KeyCode.Space) && Time.time > nextFire){
                nextFire = Time.time + fireRate;
                fireProjectile.Fire(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
    void FixedUpdate()
    {
        Vector3 vel = Vector3.zero;

        if(Input.GetKey(KeyCode.W)){
            vel.y = 1;
        } else if(Input.GetKey(KeyCode.S)){
            vel.y = -1;
        }
        if(Input.GetKey(KeyCode.A)){
            vel.x = -1;
        } else if(Input.GetKey(KeyCode.D)){
            vel.x = 1;
        }
        movement.moveRB(vel);
    }
}
