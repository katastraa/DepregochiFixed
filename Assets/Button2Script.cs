using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button2Script : MonoBehaviour
{
    public TimerScript timerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            timerScript.OverThinkingMechanic();
            timerScript.Music();
        }

    }
}
