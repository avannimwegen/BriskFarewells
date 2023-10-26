using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{

public GameObject projectilePrefab;
    //[SerializeField] float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Aimed Bullets
    public void Fire(Vector3 targetPosition){      
        targetPosition.z = 0;
        Vector3 dir = (targetPosition - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion bulletAngle = Quaternion.Euler(new Vector3(0, 0, angle));
        Rigidbody2D newProjectileRB = Instantiate(projectilePrefab, transform.position, bulletAngle).GetComponent<Rigidbody2D>();
    }

    public void TripleFire(Vector3 targetPosition){
        targetPosition.z = 0;
        Vector3 dir = (targetPosition - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion bulletAngle1 = Quaternion.Euler(new Vector3(0, 0, angle));
        Quaternion bulletAngle2 = Quaternion.Euler(new Vector3(0, 0, angle + 15));
        Quaternion bulletAngle3 = Quaternion.Euler(new Vector3(0, 0, angle - 15));

        Rigidbody2D newProjectileRB1 = Instantiate(projectilePrefab, transform.position, bulletAngle1).GetComponent<Rigidbody2D>();
        Rigidbody2D newProjectileRB2 = Instantiate(projectilePrefab, transform.position, bulletAngle2).GetComponent<Rigidbody2D>();
        Rigidbody2D newProjectileRB3 = Instantiate(projectilePrefab, transform.position, bulletAngle3).GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
