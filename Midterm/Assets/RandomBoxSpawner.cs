using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoxSpawner : MonoBehaviour
{
    Movement movement;
    [SerializeField] GameObject boxPrefab;

    void Awake(){
        movement = GetComponent<Movement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnBoxesOverTime();
    }

    void SpawnBoxesOverTime(){
        StartCoroutine(SpawnBoxesOverTimeRoutine());

        IEnumerator SpawnBoxesOverTimeRoutine(){
            yield return new WaitForSeconds(2);
            Instantiate(boxPrefab, Vector3.zero, Quaternion.identity);

            yield return null;
        }

    }

    // Update is called once per frame

}
