using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyToNextLevel : MonoBehaviour
{
    private void OnDestroy()
    {
        lockedDoor door = GameObject.FindGameObjectWithTag("Door").GetComponent<lockedDoor>();
        if (door != null)
        {
            door.GetKey(1);
        }
    }
}
