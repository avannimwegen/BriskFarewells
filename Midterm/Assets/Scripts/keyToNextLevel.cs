using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyToNextLevel : MonoBehaviour
{
    lockedDoor door;
    
    void Start(){
        
    }

    private void OnDestroy()
    {
        // Call the AddKeys method of the KeyManager singleton
        KeyManager.singleton.AddKeys(1);
        //lockedDoor door = GameObject.FindGameObjectWithTag("Door").GetComponent<lockedDoor>();
        // if (door != null)
        // {
        //     door.GetKey(1);
        //}

        // Notify the DoorManager that keys have been added
        KeyManager.NotifyKeysAdded();
    }
}
