using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    // Singleton instance
    public static KeyManager singleton;

    // Number of keys collected
    public int keysCollected = 0;

    // The key manager is now a door manager too.
    private List<lockedDoor> activeDoors = new List<lockedDoor>(); // List of active doors

    // Start is called before the first frame update
    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        } else {
            Destroy(this.gameObject);
        }

    }

    // Add door to list 
    public static void AddDoor(lockedDoor door)
    {
        if (!singleton.activeDoors.Contains(door))
        {
            singleton.activeDoors.Add(door);
        }
    }

    // Remove a door when it becomes inactive
    public static void RemoveDoor(lockedDoor door)
    {
        singleton.activeDoors.Remove(door);
    }

    // Notify all active doors that keys have been added
    public static void NotifyKeysAdded()
    {
        foreach (lockedDoor door in singleton.activeDoors)
        {
            door.CheckDoorStatus();
        }
    }

    // Doors can ask if player has enough keys
    public int GetKeysCollected()
    {
        return keysCollected;
    }

    // Method to add keys
    public void AddKeys(int amount)
    {
        keysCollected += amount;
    }
}
