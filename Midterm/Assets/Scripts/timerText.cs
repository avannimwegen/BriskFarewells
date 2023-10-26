using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerText : MonoBehaviour
{
    Text textTimer;
    int seconds = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        textTimer = GetComponent<Text>();
        StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine(){
        while(true){
            yield return new WaitForSeconds(1);
            seconds += 1;
            textTimer.text = seconds.ToString();
        }
        yield return null;
    }
}