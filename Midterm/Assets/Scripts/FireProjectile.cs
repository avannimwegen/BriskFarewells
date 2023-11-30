using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{

public GameObject projectilePrefab;
    
    List<GameObject> pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = new List<GameObject>();
    }

    // Aimed Bullets
    public void Fire(Vector3 targetPosition){      
        targetPosition.z = 0;
        Vector3 dir = (targetPosition - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion bulletAngle = Quaternion.Euler(new Vector3(0, 0, angle));

        GameObject newProjectileRB;
        if(pool.Count > 30){
            newProjectileRB = pool[0];
            pool.RemoveAt(0);
            newProjectileRB.transform.position = transform.position;
            newProjectileRB.SetActive(true);
            playerProjectile projectile = newProjectileRB.GetComponent<playerProjectile>();
            projectile.Launch(bulletAngle);
        } else {
            newProjectileRB = Instantiate(projectilePrefab, transform.position, bulletAngle);
        }
        pool.Add(newProjectileRB);
    }

    public void TripleFire(Vector3 targetPosition){
        targetPosition.z = 0;
        Vector3 dir = (targetPosition - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion bulletAngle1 = Quaternion.Euler(new Vector3(0, 0, angle));
        Quaternion bulletAngle2 = Quaternion.Euler(new Vector3(0, 0, angle + 15));
        Quaternion bulletAngle3 = Quaternion.Euler(new Vector3(0, 0, angle - 15));

        GameObject newProjectileRB1;
        GameObject newProjectileRB2;
        GameObject newProjectileRB3;
        if(pool.Count > 30){
            newProjectileRB1 = pool[0];
            pool.RemoveAt(0);
            newProjectileRB2 = pool[0];
            pool.RemoveAt(0);
            newProjectileRB3 = pool[0];
            pool.RemoveAt(0);
            newProjectileRB1.transform.position = transform.position;
            newProjectileRB2.transform.position = transform.position;
            newProjectileRB3.transform.position = transform.position;
            newProjectileRB1.SetActive(true);
            newProjectileRB2.SetActive(true);
            newProjectileRB3.SetActive(true);

            playerProjectile projectile = newProjectileRB1.GetComponent<playerProjectile>();
            projectile.Launch(bulletAngle1);
            projectile = newProjectileRB2.GetComponent<playerProjectile>();
            projectile.Launch(bulletAngle2);
            projectile = newProjectileRB3.GetComponent<playerProjectile>();
            projectile.Launch(bulletAngle3);
        } else {
            newProjectileRB1 = Instantiate(projectilePrefab, transform.position, bulletAngle1);
            newProjectileRB2 = Instantiate(projectilePrefab, transform.position, bulletAngle2);
            newProjectileRB3 = Instantiate(projectilePrefab, transform.position, bulletAngle3); 
        }
        pool.Add(newProjectileRB1);
        pool.Add(newProjectileRB2);
        pool.Add(newProjectileRB3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
