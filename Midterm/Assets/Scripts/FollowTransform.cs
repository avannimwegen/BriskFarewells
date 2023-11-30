using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    [SerializeField] float sensitivity = 0.8f;
    [SerializeField] float moveIncrement = 5.0f;
    [SerializeField] float maxDistance = 10.0f; // Maximum distance the camera can move from the player

    // Update is called once per frame
    void LateUpdate()
    {
        // Calculate the mouse position relative to the player
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 relativeMousePos = new Vector3(mousePos.x - followTarget.position.x, mousePos.y - followTarget.position.y, mousePos.z);

        // Round the relative mouse position to the nearest move increment
        float roundedX = Mathf.Round(relativeMousePos.x / moveIncrement) * moveIncrement;
        float roundedY = Mathf.Round(relativeMousePos.y / moveIncrement) * moveIncrement;

        // Limit the distance to the specified maximum
        float limitedX = Mathf.Clamp(roundedX, -maxDistance, maxDistance);
        float limitedY = Mathf.Clamp(roundedY, -maxDistance, maxDistance);

        Vector3 targetPosition = new Vector3(limitedX + followTarget.position.x, limitedY + followTarget.position.y, mousePos.z);
        Vector3 lerpPos = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * sensitivity);
        transform.position = new Vector3(lerpPos.x, lerpPos.y, transform.position.z);
    }

    /* Update is called once per frame
    void LateUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3((followTarget.position.x + mousePos.x) / 2, (followTarget.position.y + mousePos.y) / 2, mousePos.z);
        // Vector3 targetPosition = new Vector3( mousePos.x, mousePos.y, mousePos.z);

        // Round the target position to the nearest move increment
        targetPosition.x = Mathf.Round(targetPosition.x / moveIncrement) * moveIncrement;
        targetPosition.y = Mathf.Round(targetPosition.y / moveIncrement) * moveIncrement;
        
        Vector3 lerpPos = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * sensitivity);
        transform.position = new Vector3(lerpPos.x, lerpPos.y, transform.position.z);
    }*/
}