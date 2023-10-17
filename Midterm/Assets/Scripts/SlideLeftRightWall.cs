using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideLeftRightWall : MonoBehaviour
{

    public float moveDistance = -2.0f;   // Distance to move left and right
    public float moveSpeed = 1.0f;      // Speed at which the wall moves
    public float delayBetweenMoves = 2.0f; // Time to wait before moving in the opposite direction

    private Vector3 startPosition;
    private float timeSinceLastMove;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate how much time has passed since the last move
        timeSinceLastMove += Time.deltaTime;

        // Check if it's time to move in the opposite direction
        if (timeSinceLastMove >= delayBetweenMoves)
        {
            // Calculate the new position for the wall
            float newPositionX = startPosition.x + Mathf.PingPong(Time.time * moveSpeed, moveDistance);

            // Update the wall's position
            transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
        }
    }
}
