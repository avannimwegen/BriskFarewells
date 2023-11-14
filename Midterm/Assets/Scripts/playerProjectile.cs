using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * 10;
        //Destroy(this.gameObject,3);
    }

    public void Launch(Quaternion rotation){
        transform.rotation = rotation;
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * 10;
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            // don't let player destroy their own bullets
        } else if (other.gameObject.tag == "PlayerProjectile"){
            // don't let player projectiles destroy themselves
        } else if (other.gameObject.tag == "VerticalBounce"){
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            Vector2 newVelocity = rb.velocity;
            newVelocity.x = rb.velocity.x * -1;
            rb.velocity = newVelocity;
        } else if (other.gameObject.tag == "HorizontalBounce"){
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            Vector2 newVelocity = rb.velocity;
            newVelocity.y = rb.velocity.y * -1;
            rb.velocity = newVelocity;
        } else if (other.gameObject.tag == "Checkpoint"){

        } else if (other.gameObject.tag == "NoCollisionProjectile"){
            
        } else {
            this.gameObject.SetActive(false);
        }
    }
}
