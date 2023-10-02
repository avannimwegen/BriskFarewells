using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{

    public GameObject projectilePrefab;
    [SerializeField] float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Aimed Bullets
    public void Fire(Vector3 targetPosition){
        Rigidbody2D newProjectileRB = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        targetPosition.z = 0;
        newProjectileRB.velocity = (targetPosition - transform.position).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
