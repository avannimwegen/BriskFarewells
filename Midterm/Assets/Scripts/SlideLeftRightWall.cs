using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideLeftRightWall : MonoBehaviour
{
    public float moveDistance = 2.0f;   // Distance to move left and right
    public float moveSpeed = 1.0f;      // Speed at which the wall moves
    public float delayBetweenMoves = 1.5f; // Time to wait before moving in the opposite direction

    private Vector3 startPosition;
    private float timeSinceLastMove;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(MoveWall());
    }

    IEnumerator MoveWall()
    {
        Vector3 targetPosition = new Vector3(startPosition.x + moveDistance, transform.position.y, transform.position.z);
        while (true)
        {
            // Calculate the target position for the wall
            

            // Move the wall to the target position
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            // Wait for the specified delay
            yield return new WaitForSeconds(delayBetweenMoves);

            // Swap the initial and target positions for the next movement
            Vector3 temp = startPosition;
            startPosition = targetPosition;
            targetPosition = temp;
        }
    }
}
