using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAim : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Quaternion lookRotation = Quaternion.LookRotation(transform.forward, mousePos - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 20);
    }
}
