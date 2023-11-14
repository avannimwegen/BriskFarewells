using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockedDoor : MonoBehaviour
{
    private Vector3 startPosition;
    public float moveDistance = 2.0f;   // Distance to move
    public float moveSpeed = 1.0f;      // Speed at which the wall moves
    
    public int keysNeeded = 1;
    private int keysCollected = 0;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Call this method when a portal is destroyed and a key is obtained
    public void GetKey(int amount)
    {
        keysCollected += amount;
        Debug.Log($"Keys Collected: {keysCollected}/{keysNeeded}");

        // Check if enough keys have been collected to open the door
        if (keysCollected >= keysNeeded)
        {
            OpenDoor();
        }
    }

    // Call this method to open the door
    private void OpenDoor()
    {
        Debug.Log("Door is now open!");
        
        MoveWall();
    }

    public void MoveWall(){
        StartCoroutine(MoveWallRoutine());
        IEnumerator MoveWallRoutine(){

            Vector3 targetPosition = new Vector3(startPosition.x + moveDistance, transform.position.y, transform.position.z);

            // Move the wall to the target position
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            yield return null;          
        }
    }
}
