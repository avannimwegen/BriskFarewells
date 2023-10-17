using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * 3;
        Destroy(this.gameObject,8);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            Destroy(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }
}
