using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObjectTimer : MonoBehaviour
{
    public float deleteTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deleteTimer);
    }
}
