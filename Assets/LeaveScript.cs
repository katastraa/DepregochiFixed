using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveScript : MonoBehaviour
{
    public TimerScript timerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            timerScript.Leave();
            timerScript.LeavingMechanic();
        }
    }
}
