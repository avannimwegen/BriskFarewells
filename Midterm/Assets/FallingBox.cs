using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBox : MonoBehaviour
{
    Movement movement;

    // Start is called before the first frame update
    void Awake()
    {
        movement = GetComponent<Movement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 vel = new Vector3(0, -1, 0);
        movement.moveRB(new Vector3(0, -1, 0));
    }
}
