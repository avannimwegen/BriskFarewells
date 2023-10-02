using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] int hp = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp == 3){
            GetComponent<SpriteRenderer>().color = Color.blue;
        } else if (hp == 2){
           GetComponent<SpriteRenderer>().color = Color.yellow; 
        } else if (hp == 1){
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
